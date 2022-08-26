using System.Linq;

namespace SudokuSolver
{
    internal class Solver
    {
        public int?[,] Sudoku { get; set; }

        public Solver(string sudokuContent)
        {
            Sudoku = ParseSudoku(sudokuContent);
        }

        internal bool IsSolved
        {
            get
            {
                for (int i = 0; i < 9; i++)
                {
                    for (int j = 0; j < 9; j++)
                    {
                        if (Sudoku[i, j] == null)
                            return false;
                    }
                }
                return true;
            }
        }

        private int?[,] ParseSudoku(string sudokuContent)
        {
            var sudoku = new int?[9, 9];

            for (var r = 0; r < 9; r++)
            {
                var row = sudokuContent.Split(";")[r];
                var splittedRow = row.Split(",");
                for (var c = 0; c < 9; c++)
                {
                    sudoku[r, c] = splittedRow[c] != "*" ? int.Parse(splittedRow[c]) : null;
                }
            }

            return sudoku;
        }

        public void PrintSudoku()
        {
            Console.WriteLine();

            for (var i = 0; i < 9; i++)
            {
                if (i % 3 == 0)
                {
                    Console.WriteLine("-----------------------------");
                }
                for (var j = 0; j < 9; j++)
                {
                    if (j % 3 == 0)
                    {
                        Console.Write("|");
                    }
                    var number = Sudoku[i, j].HasValue ? Sudoku[i, j].Value.ToString() : "-";
                    Console.Write($" {number} ");
                }
                Console.WriteLine("");
            }

            Console.WriteLine("-----------------------------");
        }

        internal static int[] SolveColumn(int?[] col)
        {
            var possibleSolutions = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            for (int i = 0; i < col.Length; i++)
            {
                if (col[i] != null)
                {
                    possibleSolutions.Remove((int)col[i]);
                }
            }

            return possibleSolutions.ToArray();
        }


        internal static int[] SolveRow(int?[] row)
        {
            var possibleSolutions = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            for (int i = 0; i < row.Length; i++)
            {
                if (row[i] != null)
                {
                    possibleSolutions.Remove((int)row[i]);
                }
            }

            return possibleSolutions.ToArray();
        }

        internal static int[] SolveSquare(int?[,] square)
        {
            var possibleSolutions = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (square[i, j] != null)
                    {
                        possibleSolutions.Remove((int)square[i, j]);
                    }
                }
            }

            return possibleSolutions.ToArray();
        }

        internal int?[] GetColumn(int c)
        {
            var result = new List<int?>();

            for (int i = 0; i < 9; i++)
            {
                result.Add(Sudoku[i, c]);
            }

            return result.ToArray();
        }

        internal int?[] GetRow(int r)
        {
            var result = new List<int?>();

            for (int i = 0; i < 9; i++)
            {
                result.Add(Sudoku[r, i]);
            }

            return result.ToArray();
        }

        internal int?[,] GetSquare(int row, int col)
        {
            var result = new int?[3, 3];

            var initial_row = (row / 3);
            var initial_col = (col / 3);

            for (int r = 0; r < 3; r++)
            {
                for (int c = 0; c < 3; c++)
                {
                    result[r, c] = Sudoku[(initial_row * 3) + r, (initial_col * 3) + c];
                }
            }
            return result;
        }

        private IEnumerable<int> GetBoxPossibleResults(int r, int c)
        {
            var col = GetColumn(c);
            var colResults = SolveColumn(col);
            var row = GetRow(r);
            var rowResults = SolveRow(row);
            var square = GetSquare(r, c);
            var squareResults = SolveSquare(square);

            var colAndRowResults = colResults.Intersect(rowResults);
            var possibleResults = colAndRowResults.Intersect(squareResults);
            return possibleResults;
        }

        internal void Solve()
        {
            Dictionary<int, int> options;
            var solvedLastIteration = 0;
            var iteration = 0;
            while (!IsSolved)
            {
                options = new Dictionary<int, int>();
                solvedLastIteration = 0;
                for (int r = 0; r < 9; r++)
                {
                    for (int c = 0; c < 9; c++)
                    {
                        if (Sudoku[r, c] != null)
                            continue;
                        var possibleResults = GetBoxPossibleResults(r, c);

                        if (!options.ContainsKey(possibleResults.Count()))
                        {
                            options.Add(possibleResults.Count(), 0);
                        }
                        options[possibleResults.Count()]++;

                        if (possibleResults.Count() == 1)
                        {
                            solvedLastIteration++;
                            Sudoku[r, c] = possibleResults.First();
                            continue;
                        }

                        // Look for other solution options. Try to cheack all the rest of boxes in the column, row or square,
                        // if any othercan have some of the numbers selected as solution for this box.

                        // Check in the row.
                        var list = new List<IEnumerable<int>>();
                        var rowPossibleResults = possibleResults;
                        for (int i = 0; i < 9; i++)
                        {
                            if (Sudoku[r, i].HasValue || c == i)
                                continue;

                            var boxPossibleResults = GetBoxPossibleResults(r, i);
                            list.Add(boxPossibleResults);
                        }

                        var allResultsForRow = list.SelectMany(x => x).Distinct();
                        rowPossibleResults = rowPossibleResults.Except(allResultsForRow);

                        if (rowPossibleResults.Count() == 1)
                        {
                            solvedLastIteration++;
                            Sudoku[r, c] = rowPossibleResults.First();
                            continue;
                        }

                        // Check in the column.
                        list = new List<IEnumerable<int>>();
                        var colPossibleResults = possibleResults;
                        for (int i = 0; i < 9; i++)
                        {
                            if (Sudoku[i, c].HasValue || r == i)
                                continue;

                            var boxPossibleResults = GetBoxPossibleResults(i, c);
                            list.Add(boxPossibleResults);
                        }

                        var allResultsForColumn = list.SelectMany(x => x).Distinct();
                        colPossibleResults = colPossibleResults.Except(allResultsForColumn);

                        if (colPossibleResults.Count() == 1)
                        {
                            solvedLastIteration++;
                            Sudoku[r, c] = colPossibleResults.First();
                            continue;
                        }
                    }
                }

                Console.WriteLine($"Options:");
                foreach (var item in options.OrderBy(x => x.Key))
                {
                    Console.WriteLine($"{item.Key}: {item.Value}");
                }

                iteration++;
                Console.WriteLine($"Round {iteration}:");
                Console.WriteLine($"Solved this iteration: {solvedLastIteration}");
                PrintSudoku();
                Console.WriteLine("#########################################################");
            }
        }

    }
}

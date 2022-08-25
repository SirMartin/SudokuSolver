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
            for (var i = 0; i < 9; i++)
            {
                for (var j = 0; j < 9; j++)
                {
                    Console.Write($" {Sudoku[i, j]} ");
                }
                Console.WriteLine("");
            }
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

        internal void Solve()
        {
            while (!IsSolved)
            {
                for (int i = 0; i < 9; i++)
                {

                }
            }
        }
    }
}

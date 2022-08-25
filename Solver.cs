namespace SudokuSolver
{
    internal class Solver
    {
        public int?[,] Sudoku { get; set; }

        public Solver(string sudokuContent)
        {
            Sudoku = ParseSudoku(sudokuContent);
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

        internal void Solve()
        {
            throw new NotImplementedException();
        }
    }
}

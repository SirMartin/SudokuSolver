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

        internal void Solve()
        {
            throw new NotImplementedException();
        }
    }
}

using NUnit.Framework;
using SudokuSolver;

namespace Tests
{
    [TestFixture]
    public class SudokuTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void SudokuColumn()
        {
            var col = new int?[] { 1, 2, 3, null, 5, 6, 7, 8, 9 };
            int[] possibleSolutions = Solver.SolveColumn(col);

            Assert.AreEqual(1, possibleSolutions.Length);
            Assert.AreEqual(new int[] { 4 }, possibleSolutions);
        }

        [Test]
        public void SudokuColumnMultipleSolutions()
        {
            var col = new int?[] { null, 2, 3, null, 5, 6, null, 8, null };
            int[] possibleSolutions = Solver.SolveColumn(col);

            Assert.AreEqual(4, possibleSolutions.Length);
            Assert.AreEqual(new int[] { 1, 4, 7, 9 }, possibleSolutions);
        }

        [Test]
        public void SudokuRow()
        {
            var row = new int?[] { 1, 2, 3, null, 5, 6, 7, 8, 9 };
            int[] possibleSolutions = Solver.SolveRow(row);

            Assert.AreEqual(1, possibleSolutions.Length);
            Assert.AreEqual(new int[] { 4 }, possibleSolutions);
        }

        [Test]
        public void SudokuRowMultipleSolutions()
        {
            var row = new int?[] { null, 2, 3, null, 5, 6, null, 8, null };
            int[] possibleSolutions = Solver.SolveRow(row);

            Assert.AreEqual(4, possibleSolutions.Length);
            Assert.AreEqual(new int[] { 1, 4, 7, 9 }, possibleSolutions);
        }


        [Test]
        public void SudokuSquare()
        {
            var square = new int?[3, 3] { { 1, 2, 3 }, { null, 5, 6 }, { 7, 8, 9 } };
            int[] possibleSolutions = Solver.SolveSquare(square);

            Assert.AreEqual(1, possibleSolutions.Length);
            Assert.AreEqual(new int[] { 4 }, possibleSolutions);
        }


        [Test]
        public void SudokuSquareMultipleSolutions()
        {
            var square = new int?[3, 3] { { null, 2, 3 }, { null, 5, 6 }, { null, 8, null } };
            int[] possibleSolutions = Solver.SolveSquare(square);

            Assert.AreEqual(4, possibleSolutions.Length);
            Assert.AreEqual(new int[] { 1, 4, 7, 9 }, possibleSolutions);
        }

        [Test]
        public void GetSudokuRowTest()
        {
            var solver = new Solver(GetEasySudokuContent());

            var selectedRow = solver.GetRow(1);

            Assert.AreEqual(new int?[] { null, null, 1, 6, null, null, 8, 9, null }, selectedRow);
        }

        [Test]
        public void GetSudokuColumnTest()
        {
            var solver = new Solver(GetEasySudokuContent());

            var selectedColumn = solver.GetColumn(4);

            Assert.AreEqual(new int?[] { 4, null, 3, 5, null, null, 1, 6, 2 }, selectedColumn);
        }

        [Test]
        public void GetSudokuSquareTest()
        {
            var solver = new Solver(GetEasySudokuContent());

            var selectedSquare = solver.GetSquare(1, 1);

            Assert.AreEqual(new int?[,] { { 8, 2, null }, { null, null, 1 }, { null, null, 9 } }, selectedSquare);
        }

        [Test]
        public void AnotherGetSudokuSquareTest()
        {
            var solver = new Solver(GetEasySudokuContent());

            var selectedSquare = solver.GetSquare(5, 5);

            Assert.AreEqual(new int?[,] { { 1, 5, 7 }, { null, null, null }, { null, null, 4 } }, selectedSquare);
        }


        [Test]
        public void OneMoreGetSudokuSquareTest()
        {
            var solver = new Solver(GetEasySudokuContent());

            var selectedSquare = solver.GetSquare(6, 3);

            Assert.AreEqual(new int?[,] { { 4, 1, 5 }, { 7, 6, 3 }, { null, 2, 8 } }, selectedSquare);
        }

        [Test]
        public void EvenOneMoreGetSudokuSquareTest()
        {
            var solver = new Solver(GetEasySudokuContent());

            var selectedSquare = solver.GetSquare(8, 7);

            Assert.AreEqual(new int?[,] { { null, null, 8 }, { 2, null, null }, { null, 5, 1 } }, selectedSquare);
        }
                

        [Test]
        public void NotSolvedSudokuTest()
        {
            var solver = new Solver(GetEasySudokuContent());

            Assert.IsFalse(solver.IsSolved);
        }

        [Test]
        public void SolvedSudokuTest()
        {
            var solver = new Solver(GetEasySudokuSolution());

            Assert.IsTrue(solver.IsSolved);
        }

        [Test]
        public void EasySudokuTest()
        {
            var solver = new Solver(GetEasySudokuContent());
            solver.Solve();

            var solution = new Solver(GetEasySudokuSolution());

            Assert.AreEqual(solver.Sudoku, solution.Sudoku);
        }

        [Test]
        public void HardSudokuTest()
        {
            var solver = new Solver(GetHardSudokuContent());
            solver.Solve();

            var solution = new Solver(GetHardSudokuSolution());

            Assert.AreEqual(solver.Sudoku, solution.Sudoku);
        }

        private string GetEasySudokuContent()
        {
            return "8,2,*,*,4,*,*,6,*;" +
                   "*,*,1,6,*,*,8,9,*;" +
                   "*,*,9,8,3,1,5,*,7;" +
                   "4,9,*,1,5,7,*,*,*;" +
                   "*,*,*,*,*,*,*,*,*;" +
                   "*,5,3,*,*,4,*,*,*;" +
                   "9,6,*,4,1,5,*,*,8;" +
                   "1,*,*,7,6,3,2,*,*;" +
                   "3,*,*,*,2,8,*,5,1;";
        }

        private string GetEasySudokuSolution()
        {
            return "8,2,7,5,4,9,1,6,3;" +
                   "5,3,1,6,7,2,8,9,4;" +
                   "6,4,9,8,3,1,5,2,7;" +
                   "4,9,6,1,5,7,3,8,2;" +
                   "2,1,8,3,9,6,4,7,5;" +
                   "7,5,3,2,8,4,9,1,6;" +
                   "9,6,2,4,1,5,7,3,8;" +
                   "1,8,5,7,6,3,2,4,9;" +
                   "3,7,4,9,2,8,6,5,1;";
        }

        private string GetHardSudokuContent()
        {
            return "*,7,*,9,*,*,*,*,1;" +
                   "*,*,*,2,5,*,*,4,*;" +
                   "5,*,*,*,*,*,8,*,7;" +
                   "*,*,*,*,*,*,*,*,5;" +
                   "9,*,8,*,6,*,3,*,*;" +
                   "*,*,5,3,*,8,*,*,2;" +
                   "*,*,*,*,*,*,*,9,*;" +
                   "*,9,6,*,4,*,*,*,*;" +
                   "*,*,4,1,*,*,*,*,3;";
        }

        private string GetHardSudokuSolution()
        {
            return "6,7,2,9,8,4,5,3,1;" +
                   "8,3,1,2,5,7,6,4,9;" +
                   "5,4,9,6,1,3,8,2,7;" +
                   "7,6,3,4,2,9,1,8,5;" +
                   "9,2,8,5,6,1,3,7,4;" +
                   "4,1,5,3,7,8,9,6,2;" +
                   "1,5,7,8,3,2,4,9,6;" +
                   "3,9,6,7,4,5,2,1,8;" +
                   "2,8,4,1,9,6,7,5,3;";
        }
    }
}
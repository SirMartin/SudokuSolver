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
    }
}
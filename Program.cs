// See https://aka.ms/new-console-template for more information
using SudokuSolver;

Console.WriteLine("Hello, World!");

var content = "8,2,*,*,4,*,*,6,*;" +
            "*,*,1,6,*,*,8,9,*;" +
            "*,*,9,8,3,1,5,*,7;" +
            "4,9,*,1,5,7,*,*,*;" +
            "*,*,*,*,*,*,*,*,*;" +
            "*,5,3,*,*,4,*,*,*;" +
            "9,6,*,4,1,5,*,*,8;" +
            "1,*,*,7,6,3,2,*,*;" +
            "3,*,*,*,2,8,*,5,1;";

var solver = new Solver(content);
solver.PrintSudoku();
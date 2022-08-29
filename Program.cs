// See https://aka.ms/new-console-template for more information
using SudokuSolver;

var content = "5,*,2,3,*,7,8,*,1;" +
              "*,*,*,*,*,*,*,*,*;" +
              "6,*,*,8,*,2,*,*,9;" +
              "3,*,7,*,*,*,2,*,8;" +
              "*,*,*,*,5,*,*,*,*;" +
              "2,*,1,*,*,*,4,*,5;" +
              "4,*,*,1,*,6,*,*,3;" +
              "*,*,*,*,*,*,*,*,*;" +
              "7,*,5,4,*,8,6,*,2;";

var solver = new Solver(content);
solver.Solve();
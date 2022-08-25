// See https://aka.ms/new-console-template for more information
using SudokuSolver;

var content = "*,7,*,9,*,*,*,*,1;" +
                   "*,*,*,2,5,*,*,4,*;" +
                   "5,*,*,*,*,*,8,*,7;" +
                   "*,*,*,*,*,*,*,*,5;" +
                   "9,*,8,*,6,*,3,*,*;" +
                   "*,*,5,3,*,8,*,*,2;" +
                   "*,*,*,*,*,*,*,9,*;" +
                   "*,9,6,*,4,*,*,*,*;" +
                   "*,*,4,1,*,*,*,*,3;";

var solver = new Solver(content);
solver.Solve();
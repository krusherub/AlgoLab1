using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace AlgoritmsLab1
{
    class Program
    {
        static void Main(string[] args)
        {
            Board board = new Board();
            board.PrintTable();

            Solver solver = new Solver();
            solver.DepthLimitedSearch(board,3);
        }
    }
}
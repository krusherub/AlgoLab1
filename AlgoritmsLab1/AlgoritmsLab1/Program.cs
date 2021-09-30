using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Timers;

namespace AlgoritmsLab1
{
    class Program
    {
        static void Main(string[] args)
        {
            Board board = new Board();
            board.PrintTable();
            
            Solver solver = new Solver();
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            solver.RecursiveBestFirstSearch(board);
            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;
            string elapsedTime = String.Format("{0:00}:{1:00}.{2:00}",
                 ts.Minutes, ts.Seconds,
                ts.Milliseconds / 10);
            Console.WriteLine(elapsedTime, "RunTime");
             
        }
    }
}
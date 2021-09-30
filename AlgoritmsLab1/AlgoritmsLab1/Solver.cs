using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Xml;

namespace AlgoritmsLab1
{
    public class Solver
    {
        public static int MaxDepth = 10;
        
        public Board RecursiveBestFirstSearch(Board initialBoard)
        {
            initialBoard.Collisions = F1(initialBoard);
            
            Console.WriteLine(initialBoard.Collisions);
            var result = RBFS(initialBoard, int.MaxValue) ;
            if (result is null)
            {
                throw new Exception();
            }
            result.PrintTable();
            Console.WriteLine(result.IsRight());
            Console.WriteLine(F1(result));
            return result;
        }
        
        private Queue<Board> lastTenBoards = new Queue<Board>();
        private bool CheckOverFlow(Board board)
        {
            foreach (var bb in lastTenBoards)
            {
                if (bb.Equals(board) )
                {
                    return true;
                }
            }

            lastTenBoards.Enqueue(board);
               
            if (lastTenBoards.Count == 50)
            {
                lastTenBoards.Dequeue();
            }
            return false;
        }

        private Board prev = new Board() {_board = new ChessFigure[8,8]};
        private Board RBFS(Board board, int limitF)
        {
            if (board.Collisions == 0)
            {
                return board;
            }

            if (CheckOverFlow(board))
            {
                board.Collisions += 3;
                return board;
            }
            
            // board.PrintTable();
            
            var queue = new Queue<Board>(GetNewBoards(board).OrderBy(x => x.Collisions));
            while (queue.Any())
            {
                var newBoard = queue.Peek();
 
                if (newBoard.Collisions > limitF)
                {
                    return board;
                }
                
                prev = newBoard;
                
                var dumpBoard =  RBFS(newBoard, newBoard.Collisions);
                
                if (dumpBoard.Collisions == 0)
                {
                    return dumpBoard;
                }
                newBoard.Collisions = dumpBoard.Collisions;
                queue = new Queue<Board>(queue.OrderBy(x => x.Collisions).ToArray());
            }
            return null;
        }
           private bool Check(Board.Direction direction, int stepSize, int initialPositionX, int initialPositionY)
        {
            if (direction is Board.Direction.Up)
            {
                if (initialPositionY - stepSize  < 0)
                {
                    return false;
                }

                if (initialPositionY == 0)
                {
                    return false;
                }
            }
            if (direction is Board.Direction.Down)
            {
                if (initialPositionY + stepSize  > 7)
                {
                    return false;
                }

                if (initialPositionY == 7)
                {
                    return false;
                }
            }
            
            if (direction is Board.Direction.Left)
            {
                if (initialPositionX == 0)
                    return false;
                if (initialPositionX - stepSize < 0)
                    return false;
            }
            
            if (direction is Board.Direction.Right)
            {
                if (initialPositionX == 7)
                    return false;
                if (initialPositionX + stepSize > 7)
                    return false;
            }

          
            if (direction is Board.Direction.UpLeft)
            {
                if (initialPositionX == 0 || initialPositionY==0)
                    return false;
                if (initialPositionX - stepSize < 0 || initialPositionY - stepSize < 0 )
                    return false;
            }

            if (direction is Board.Direction.DownLeft)
            {
                if (initialPositionX == 0 || initialPositionY==7)
                    return false;
                if (initialPositionX - stepSize < 0 || initialPositionY + stepSize > 7 )
                    return false;
            }
            
            if (direction is Board.Direction.UpRight)
            {
                if (initialPositionX == 7)
                    return false;
                if (initialPositionY == 0)
                    return false;
                if (initialPositionX + stepSize > 7)
                    return false;
                if (initialPositionY - stepSize < 0)
                    return false;
            }
            
            if (direction is Board.Direction.DownRight)
            {
                if (initialPositionX == 7)
                    return false;
                if (initialPositionY == 7)
                    return false;
                if (initialPositionX + stepSize > 7)
                    return false;
                if (initialPositionY + stepSize > 7)
                    return false;
            }
            return true;
        }

        public Board IterativeDeependingSearch(Board board)
        {
   
            for (var depth = 0; depth < MaxDepth; depth++)
            {
                Console.WriteLine(depth);
                var result = DepthLimitedSearch(new Board(board._board), depth);
                if (result != null)
                {
                    return board;
                }
            }
            return null;
        }

        private int F1(Board board)
        {
            var collisions = 0;
            foreach (var queen in board._board)
            {
                if (queen==null)
                {
                    continue;
                }
                for (int y = 0; y < 8; y++)
                {
                    for (int x = 0; x < 8; x++)
                    {
                        if (board._board[y,x] == queen)
                        {
                            for (int option = 0; option < 8; option++)
                            {
                                for (var i = 1; i < 8; i++)
                                {
                                    if (collisions == 5 && x == 0 && y== 3 && option == 4)
                                    {
                                                    
                                    }
                                    var newBoard = new Board(board._board);

                                    if (Check((Board.Direction) option,i,x,y))
                                    {
                                        if(!newBoard.moveFigure((Queen)queen,(Board.Direction)option,i))
                                        {
                                            collisions++;
                                            break;
                                        }
                                    }
                            
                                }
                                //ОБНОВЛЯТЬ МАССИВ КВИН
                            }
                            //  break; // наверх
                            
                        }
                    }
                }
            }
            return collisions/2;
        }


         public Board DepthLimitedSearch(Board board, int maxDepth)
         {
             var result =  RecursiveDls(board, maxDepth);
             if (result is Cutoff)
             {
                 
             }

             if (result is Solved)
             {
                 Solved sl = (Solved) result;
                 return sl.Board;
             }
             return null ;
         }

         class Cutoff
         {
             
         }
         class Failure
         {
             
         }

         class Solved
         {
             public Board Board { get; set; }

             public Solved(Board board)
             {
                 Board = board;
             }
         }
         
         private object RecursiveDls( Board board, int maxDepth)
         {
             // board.PrintTable();
             // Console.WriteLine("aaaaa");
             if (board.IsRight())
             {
                 Console.WriteLine("Found ");
                 Console.WriteLine();
                 board.PrintTable();
                 Environment.Exit(1);
                 return new Solved(board);
             }
             
             if ( maxDepth == 0 )
             {
                 return new Cutoff();
             }

             foreach (var newBoard in GetNewBoards(board))
             {
                
                  RecursiveDls(newBoard, maxDepth - 1);
             }

             return new Failure();
         }

         private List<Board> GetNewBoards(Board board)
         {
             var list = new List<Board>();
             foreach (var queen in board._board)
             {
                 if (queen == null)
                 {
                     continue;
                 }
                 for (var i = 1; i < 8; i++)
                 {
                     for (int option = 0; option < 8; option++)
                     {
                         var newBoard = new Board(board._board);
                         // newBoard.PrintTable();
                         newBoard.moveFigure((Queen) queen, (Board.Direction) option, i);
                         // Console.WriteLine((Board.Direction) option);
                         // newBoard.PrintTable();
                         // Console.WriteLine("11111111111111111111111111111");
                         newBoard.Collisions = F1(newBoard);
                         
                         // if (!newBoard.Contains(5))
                         // {
                         //     Console.WriteLine( ((Queen) queen).number + "qqqqqq");
                         //     newBoard.PrintTable();
                         //     Console.WriteLine(5);
                         // }
                         list.Add(newBoard);
                     }
                 }
             }
             return list;
         } 
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;

namespace AlgoritmsLab1
{
    public class Board
    {
        private static int QueenAmount = 8;
        private static int BoardSize = 8;

        public int Collisions { get; set; }

        public ChessFigure[,] _board = new ChessFigure[BoardSize,BoardSize];
        
        public Board()
        {
             //Initialize();
             InitializeAlmostDone();
        }

        private void InitializeAlmostDone()
        {
            /*_board[0, 0] = new Queen(0,1,0); 
            _board[0, 1] = new Queen(1, 7,1);
            _board[0, 2] = new Queen(2, 3,2); 
            _board[1, 0] = new Queen(3,0,3); 
            _board[1, 1] = new Queen(4,7,4);
            _board[1, 2] = new Queen(5,4,5); 
            _board[2, 0] = new Queen(6,5,6); 
            _board[2, 1] = new Queen(7,3,7); */
            
             _board[0, 2] = new Queen(0,1,0); 
             _board[1, 7] = new Queen(1, 7,1);
             _board[2, 3] = new Queen(2, 3,2); 
             _board[3, 0] = new Queen(3,0,3); 
             _board[4, 7] = new Queen(4,7,4);
             _board[5, 4] = new Queen(5,4,5); 
             _board[6, 6] = new Queen(6,5,6); 
             _board[7, 1] = new Queen(7,1,7); 
            
            // _board[0, 2] = new Queen(); 
            // _board[1, 5] = new Queen();//
            // _board[2, 3] = new Queen(); //
            // _board[3, 0] = new Queen(); //
            // _board[4, 7] = new Queen();//
            // _board[5, 4] = new Queen(); //
            // _board[6, 6] = new Queen(); //
            // _board[7, 1] = new Queen(); //
        }
        public Board(ChessFigure[,] board )
        {
            _board = (ChessFigure[,]) board.Clone();
        }

        public bool IsRight()
        {
            int row = 0;
            int column = 0;
            
            // Проверка по рядкам и столбцам
            for (int i = 0; i < BoardSize; i++)
            {
                for (int j = 0; j < BoardSize; j++)
                {
                    if (_board[i, j] is Queen)
                    {
                        row++;
                    }
                    if (_board[j, i] is Queen)
                    {
                        column++;
                    }
                }

                if (row != 1 || column != 1)
                {
                    return false;
                }

                row = 0;
                column = 0;
            }

            int n = 0;
            // Проверка по диоганалям 
            
            // Центральная диагональ
            for (int i = 0, j = 0; i < BoardSize && j < BoardSize; i++, j++)
            {
                if (_board[i, j] is Queen)
                {
                    n++;
                }

                if (n > 1)
                    return false;
            }
            // 2 диагональ
            n = 0;
            for (int i = 1, j = 0; i < BoardSize || j < BoardSize-1; i++, j++)
            {
                if (_board[i, j] is Queen)
                {
                    n++;
                }

                if (n > 1)
                    return false;
            }
            // 3 диагональ
            n = 0;
            for (int i = 2, j = 0; i < BoardSize || j < BoardSize-2; i++, j++)
            {
                if (_board[i, j] is Queen)
                {
                    n++;
                }

                if (n > 1)
                    return false;
            }
            // 4 диагональ
            n = 0;
            for (int i = 3, j = 0; i < BoardSize || j < BoardSize-3; i++, j++)
            {
                if (_board[i, j] is Queen)
                {
                    n++;
                }

                if (n > 1)
                    return false;
            }
            // 5 диагональ
            n = 0;
            for (int i = 4, j = 0; i < BoardSize || j < BoardSize-4; i++, j++)
            {
                if (_board[i, j] is Queen)
                {
                    n++;
                }

                if (n > 1)
                    return false;
            }
            // 6 диагональ
            n = 0;
            for (int i = 5, j = 0; i < BoardSize || j < BoardSize-5; i++, j++)
            {
                if (_board[i, j] is Queen)
                {
                    n++;
                }

                if (n > 1)
                    return false;
            }
            // 7 диагональ
            n = 0;
            for (int i = 6, j = 0; i < BoardSize || j < BoardSize-6; i++, j++)
            {
                if (_board[i, j] is Queen)
                {
                    n++;
                }

                if (n > 1)
                    return false;
            }
            
            // нижння диагональ
            
            // -1 диагональ
            n = 0;
            for (int i = 0, j = 1; i < BoardSize-1 || j < BoardSize; i++, j++)
            {
                if (_board[i, j] is Queen)
                {
                    n++;
                }

                if (n > 1)
                    return false;
            }
            // -2 диагональ
            n = 0;
            for (int i = 0, j = 2; i < BoardSize-2 || j < BoardSize; i++, j++)
            {
                if (_board[i, j] is Queen)
                {
                    n++;
                }

                if (n > 1) 
                    return false;
            }
            // -3 диагональ
            n = 0;
            for (int i = 0, j = 3; i < BoardSize-3 || j < BoardSize; i++, j++)
            {
                if (_board[i, j] is Queen)
                {
                    n++;
                }
                if (n > 1)
                    return false;
            }
            // -4 диагональ
            n = 0;
            for (int i = 0, j = 4; i < BoardSize-4 || j < BoardSize; i++, j++)
            {
                if (_board[i, j] is Queen)
                {
                    n++;
                }

                if (n > 1)
                    return false;
            }
            // -5 диагональ
            n = 0;
            for (int i = 0, j = 5; i < BoardSize-5 || j < BoardSize; i++, j++)
            {
                if (_board[i, j] is Queen)
                {
                    n++;
                }

                if (n > 1)
                    return false;
            }
            // -6 диагональ
            n = 0;
            for (int i = 0, j = 6; i < BoardSize-6 || j < BoardSize; i++, j++)
            {
                if (_board[i, j] is Queen)
                {
                    n++;
                }

                if (n > 1)
                    return false;
            }
            // -7 диагональ
            n = 0;
            for (int i = 0, j = 7; i < BoardSize-7 || j < BoardSize; i++, j++)
            {
                if (_board[i, j] is Queen)
                {
                    n++;
                }

                if (n > 1)
                    return false;
            } 

            return true;
        }
        
        public enum Direction
        {
            Right,
            Left,
            Up,
            Down,
            UpRight,
            UpLeft,
            DownLeft,
            DownRight
        }

        public bool moveFigure(Queen queen, Direction direction, int stepSize)
        {
            int initialPositionX = -1;
            int initialPositionY = -1;
            
            // находим начальный координаты нашей фигуры на доске.
            for (int y = 0; y < BoardSize; y++)
            {
                for (int x = 0; x < BoardSize; x++)
                {
                    if (_board[y,x] == queen)
                    {
                        initialPositionX = x;
                        initialPositionY = y;
                        break;
                    }
                }
            }

            // Console.WriteLine(initialPositionX+" "+ initialPositionY);

            if (direction is Direction.Up)
            {
                if (initialPositionY - stepSize  < 0)
                {
                    return false;
                }

                if (initialPositionY == 0)
                {
                    return false;
                }

                if (_board[initialPositionY-1, initialPositionX] != null)
                {
                    return false;
                }
                
                for (int y = initialPositionY-1; y >= initialPositionY-stepSize; y--)
                {
                    if (_board[y,initialPositionX] != null)
                    {
                        return false;
                    }
                }
                _board[ initialPositionY, initialPositionX] = null;
                _board[initialPositionY - stepSize, initialPositionX] = queen;
            }
            
            if (direction is Direction.Down)
            {
                if (initialPositionY + stepSize  > 7)
                {
                    return false;
                }

                if (initialPositionY == 7)
                {
                    return false;
                }

                for (int y = initialPositionY+1; y <= initialPositionY+stepSize; y++)
                {
                    if (_board[y,initialPositionX] != null)
                    {
                        return false;
                    }
                }
                _board[ initialPositionY, initialPositionX] = null;
                _board[initialPositionY + stepSize, initialPositionX] = queen;
            }
            
            if (direction is Direction.Left)
            {
                if (initialPositionX == 0)
                    return false;
                if (initialPositionX - stepSize < 0)
                    return false;

                if (_board[initialPositionY, initialPositionX-1] != null)
                {
                    return false;
                }
                
                for (int x = initialPositionX - 1; x >= initialPositionX - stepSize; x--)
                {
                    if (_board[initialPositionY, x] != null)
                    {
                        return false;
                    }

                  
                }
                _board[initialPositionY, initialPositionX] = null;
                _board[initialPositionY, initialPositionX - stepSize] = queen;
            }
            
            if (direction is Direction.Right)
            {
                if (initialPositionX == 7)
                    return false;
                if (initialPositionX + stepSize > 7)
                    return false;
                
                
                
                for (int x = initialPositionX + 1; x <= initialPositionX + stepSize; x++)
                {
                    if (_board[initialPositionY, x] != null)
                    {
                        return false;
                    }
                }
                _board[initialPositionY, initialPositionX] = null;
                _board[initialPositionY, initialPositionX + stepSize] = queen;
            }

          
            if (direction is Direction.UpLeft)
            {
                if (initialPositionX == 0 || initialPositionY==0)
                    return false;
                if (initialPositionX - stepSize < 0 || initialPositionY - stepSize < 0 )
                    return false;
                
                if (_board[initialPositionY-1, initialPositionX-1] != null)
                {
                    return false;
                }

                
                var y = initialPositionY - 1;
                for (int x = initialPositionX - 1; x >= initialPositionX - stepSize; x--, y--)
                {
                    if (_board[y, x] != null)
                    {
                        return false;
                    }
                }
                _board[initialPositionY, initialPositionX] = null;
                _board[initialPositionY - stepSize, initialPositionX - stepSize] = queen;
            }

            if (direction is Direction.DownLeft)
            {
                if (initialPositionX == 0 || initialPositionY==7)
                    return false;
                if (initialPositionX - stepSize < 0 || initialPositionY + stepSize > 7 )
                    return false;
                
                if (_board[initialPositionY+1, initialPositionX-1] != null)
                {
                    return false;
                }

                var y = initialPositionY + 1;
                for (int x = initialPositionX - 1; x >= initialPositionX - stepSize; x--, y++)
                {
                    if (_board[y, x] != null)
                    {
                        return false;
                    }
                }
                _board[initialPositionY, initialPositionX] = null;
                _board[initialPositionY + stepSize, initialPositionX - stepSize] = queen;
            }
            
            if (direction is Direction.UpRight)
            {
                if (initialPositionX == 7)
                    return false;
                if (initialPositionY == 0)
                    return false;
                if (initialPositionX + stepSize > 7)
                    return false;
                if (initialPositionY - stepSize < 0)
                    return false;

                
                     
                if (_board[initialPositionY-1, initialPositionX+1] != null)
                {
                    return false;
                }
                
                var y = initialPositionY - 1;
                for (int x = initialPositionX + 1; x <= initialPositionX + stepSize; x++, y--)
                {
                    if (_board[y, x] != null)
                    {
                        return false;
                    }
                }
                
                _board[initialPositionY, initialPositionX] = null;
                _board[initialPositionY - stepSize, initialPositionX + stepSize] = queen;
            }
            
            if (direction is Direction.DownRight)
            {
                if (initialPositionX == 7)
                    return false;
                if (initialPositionY == 7)
                    return false;
                if (initialPositionX + stepSize > 7)
                    return false;
                if (initialPositionY + stepSize > 7)
                    return false;
                
                if (_board[initialPositionY+1, initialPositionX+1] != null)
                {
                    return false;
                }
                
                var y = initialPositionY + 1;
                for (int x = initialPositionX + 1; x <= initialPositionX + stepSize; x++, y++)
                {
                    if (_board[y, x] != null)
                    {
                        return false;
                    }
                }
                _board[initialPositionY, initialPositionX] = null;
                _board[initialPositionY + stepSize, initialPositionX + stepSize] = queen;
            }
            return true;
        }


        public override bool Equals(object? obj)
        {
            var boa = (Board) obj;
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (_board[i,j] != boa._board[i,j])
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        private void Initialize()
        {
            var generator = new Random();
            for (var counter = 0; counter < QueenAmount; counter++)
            {
                var x = generator.Next(8);
                var y = generator.Next(8);
                
                if (_board[x,y] != null)
                {
                    counter--;
                    continue;    
                }
                 _board[x, y] = new Queen(x,y,counter);
            }
        }

        public bool Contains(int number)
        {
            foreach (var figure in _board)
            {
                if (figure!=null)
                {
                    if (((Queen) figure).number == number)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public void PrintTable()
        {
            Console.WriteLine("##########");
            for (var columnIndex = 0; columnIndex < BoardSize; columnIndex++)
            {
                Console.Write("#");
                for (var rowIndex = 0; rowIndex < BoardSize; rowIndex++)
                {
                    if (_board[columnIndex,rowIndex] == null)
                    {
                        Console.Write(" ");
                    }
                    else
                    {
                        Console.Write("Q");
                      //  Console.Write(((Queen) _board[columnIndex, rowIndex]).number);
                    }
                }
                Console.WriteLine("#");
            }
            Console.WriteLine("##########");
        }
    }
}
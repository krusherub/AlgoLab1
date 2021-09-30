using System;

namespace AlgoritmsLab1
{
    public class Queen : ChessFigure
    {
        public int x, y;
         public int number;

         public Queen(int y,int x , int number)
         {
             this.x = x;
             this.y = y;
             this.number = number;
         }
         public Queen(int y,int x )
         {
             this.x = x;
             this.y = y;
             this.number = 0;
         }
    }
}
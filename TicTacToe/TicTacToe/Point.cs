using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe
{
    class Point
    {
        private int _x;
        private int _y;

        public int X { get; set; }
        public int Y { get; set; }

        public Point(int y, int x)
        {
            this.X = x;
            this.Y = y;
        }
    }
}

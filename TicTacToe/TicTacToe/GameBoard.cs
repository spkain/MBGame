using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe
{
    class GameBoard
    {
        private IPlay _winner;
        private int[,] _field = {
                {0, 0, 0},
                {0, 0, 0},
                {0, 0, 0}
        };

        private Dictionary<Int32, Point> dic = new Dictionary<Int32, Point>();

        public GameBoard()
        {
            dic.Add(1, new Point(0, 0));
            dic.Add(2, new Point(0, 1));
            dic.Add(3, new Point(0, 2));
            dic.Add(4, new Point(1, 0));
            dic.Add(5, new Point(1, 1));
            dic.Add(6, new Point(1, 2));
            dic.Add(7, new Point(2, 0));
            dic.Add(8, new Point(2, 1));
            dic.Add(9, new Point(2, 2));
        }

        public bool IsCellEmpty(int num)
        {
            Point pos = GetCell(num);

            if (_field[pos.Y, pos.X] != 0)
            {
                return false;
            }
            return true;
        }

        public bool IsAllCellEmpty()
        {
            for (int y = 0; y < 10; ++y)
            {
                for (int x = 0; x < 10; ++x)
                {
                    if (_field[y, x] == 0)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public Point GetCell(int num)
        {
            return dic[num];
        }


        public void UpdateCell(Point pos, int num)
        {
            _field[pos.Y, pos.X] = num;
        }

        internal void startgame()
        {
            puts("### game start! ###");
        }

        public bool IsFinished { 
            get
            {
                return IsFinish();
            }
        }

        private bool IsFinish()
        {
            throw new NotImplementedException();
        }

        internal void endgame()
        {
            if (HasWinner)
                _winner.WinInfo();

            puts("### game is end. Otsukaresama Deshita. ###");
        }

        private void print(string str)
        {
            Console.Write(str);
        }

        private void puts(string str)
        {
            Console.WriteLine(str);
        }

        public bool HasWinner {
            get
            {
                if (_winner == null)
                    return false;

                return true;
            }
        }
    }
}

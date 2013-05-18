using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe
{
    class GameBoard : IBoard
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

        public void Display()
        {
            for (int y = 0; y < 3; ++y)
            {
                puts("+---+---+---+");
                for (int x = 0; x < 3; ++x)
                {
                    print("|");
                    PrintCell(_field[y, x]);
                }
                
                puts("|");
            }
            puts("+---+---+---+");
            puts("");
        }

        public void DisplayForSelectNumber()
        {
            puts("+---+---+---+");
            puts("| 1 | 2 | 3 |");
            puts("+---+---+---+");
            puts("| 4 | 5 | 6 |");
            puts("+---+---+---+");
            puts("| 7 | 8 | 9 |");
            puts("+---+---+---+");
            puts("");
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
            for (int y = 0; y < 3; ++y)
            {
                for (int x = 0; x < 3; ++x)
                {
                    if (_field[y, x] == 0)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public void GetCellValInfo(int num)
        {
            if (0 < num && num < 10)
            {
                puts(String.Format("select number[{0}] is {1}", num, GetCellStr(num)));
            }
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


        internal void endgame()
        {
            if (HasWinner)
            {
                _winner.WinInfo();
            }
            else
            {
                puts("game is draw.");
            }

            
            puts("### game is end. Otsukaresama Deshita. ###");
        }

        public bool IsWInner(IPlay p)
        {
            for (int y = 0; y < 3; ++y)
            {
                if (_field[y, 0] == p.GetHand() &&
                    _field[y, 1] == p.GetHand() &&
                    _field[y, 2] == p.GetHand())
                {
                    _winner = p;
                    return true;
                }

            }

            for (int x = 0; x < 3; ++x)
            {
                if (_field[0, x] == p.GetHand() &&
                    _field[1, x] == p.GetHand() &&
                    _field[2, x] == p.GetHand())
                {
                    _winner = p;
                    return true;
                }

            }

            if (_field[0, 0] == p.GetHand() &&
                _field[1, 1] == p.GetHand() &&
                _field[2, 2] == p.GetHand())
            {
                _winner = p;
                return true;
            }

            if (_field[0, 2] == p.GetHand() &&
                _field[1, 1] == p.GetHand() &&
                _field[2, 0] == p.GetHand())
            {
                _winner = p;
                return true;
            }

            return false;
        }

        public bool HasWinner
        {
            get
            {
                if (_winner == null)
                    return false;

                return true;
            }
        }

#region private methods
        private void print(string str)
        {
            Console.Write(str);
        }

        private void puts(string str)
        {
            Console.WriteLine(str);
        }

        private void PrintCell(int p)
        {
            print(GetCellStr(p));
        }

        private string GetCellStr(int p)
        {
            switch (p)
            {
                case 0:
                    return "   ";
                case 1:
                    return " o ";
                case 2:
                    return " x ";
                default:
                    return "   ";
            }
        }

        private bool IsFinish()
        {
            if (HasWinner || IsAllCellEmpty())
            {
                return true;
            }
            return false;
        }
#endregion
    }
}

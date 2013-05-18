using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace TicTacToe
{
	class Player : IPlay
	{
        private string _name;
        private HandType _hand;
        private PlayerType _type;
        private IPlayLogic _logic;

        public Player(PlayerType type)
        {
            this._type = type;
            switch (type)
            {
                case PlayerType.CPU:
                    _name = "CPU";
                    _hand = HandType.Cross;
                    _logic = SelectLogic();
                    break;
                case PlayerType.USER:
                    _name = InputYourName();
                    _hand = HandType.Circle;
                    break;
            }
        }

        #region IPlay member

        public void Play(GameBoard board)
        {
            board.DisplayForSelectNumber();
            int result = 0;
            if (_type == PlayerType.CPU)
            {
                result = getNumberForLogic(board);
            }
            else
            {
                result = normalSelect(board);
            }

            board.UpdateCell(board.GetCell(result), (int)_hand);
            board.Display();
        }

        public void WinInfo()
        {
            Console.WriteLine("{0} is winner.", _name);
            if (_type == PlayerType.CPU)
            {
                Console.WriteLine("you are lose....  λ....");
                Console.WriteLine("Kuyashiidesu!!!");
            }
        }

        public int GetHand()
        {
            return (int)_hand;
        }

        #endregion

#region private methods
        private IPlayLogic SelectLogic()
        {
            PlugManager manager = new PlugManager();

            int i = 0;
            foreach (IPlayLogic p in manager.getPlugList())
            {
                Console.WriteLine("{0}: {1}", i, p.GetName());
                i++;
            }

            if (manager.getPlugList().Count == 1)
            {
                return manager.getPlugList()[0];
            }

            while (true)
            {
                Console.Write("select cpu logic: ");
                string pluginnum = Console.ReadLine();
                int logicnum = 0;
                if (Int32.TryParse(pluginnum, out logicnum))
                {
                    List<IPlayLogic> list = manager.getPlugList();
                    Thread.Sleep(1000);
                    if (list.Count > logicnum)
                    {
                        Console.WriteLine("ok load plugin {0}", list[logicnum].GetName());
                        return list[logicnum];
                    }
                    else
                    {
                        continue;
                    }

                }
                else
                {
                    continue;
                }
            }
        }

        private string InputYourName()
        {
            Console.Write("input player name: ");


            string name = Console.ReadLine();

            while (name.Length == 0)
            {
                Console.WriteLine("error, retry input");
                Console.Write("input player name: ");
                name = Console.ReadLine();
            }

            return name;
        }

        private bool IsGameNumeric(int num)
        {
            return 0 < num && num < 10;
        }

        private int getNumberForLogic(GameBoard board)
        {
            int result = _logic.GetNumber((IBoard)board);

            while (IsGameNumeric(result) == false ||
                board.IsCellEmpty(result) == false)
            {
                result = _logic.GetNumber((IBoard)board);
            }
            return result;
        }

        private int normalSelect(GameBoard board)
        {
            return InputYourNumber(board);
        }

        private int InputYourNumber(GameBoard board)
        {
            int num = 0;

            while (true)
            {
                Console.Write("input area number.: ");
                string numstr = Console.ReadLine();
                if (Int32.TryParse(numstr, out num) == false)
                {
                    Console.WriteLine("error input. plz retry...");
                    continue;
                }

                if (num < 1 || 9 < num)
                {
                    Console.WriteLine("error number. plz retry.");
                    continue;
                }

                if (board.IsCellEmpty(num) == false)
                {
                    Console.WriteLine("sorry, not empty. plz retry...");
                    continue;
                }

                break;
            }

            return num;
        }
#endregion
    }
}

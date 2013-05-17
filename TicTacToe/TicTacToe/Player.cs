using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe
{
	class Player : IPlay
	{
        private string _name;
        private HandType _hand;
        private PlayerType _type;

        public Player(PlayerType type)
        {
            this._type = type;
            switch (type)
            {
                case PlayerType.CPU:
                    _name = "CPU";
                    _hand = HandType.Cross;
                    break;
                case PlayerType.USER:
                    _name = InputYourName();
                    _hand = HandType.Circle;
                    break;
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


        #region IPlay メンバー

        public void Play(GameBoard board)
        {
            if (_type == PlayerType.CPU)
            {
                randomPlay(board);
            }
            else
            {
                normalPlay(board);
            }
        }

        private void normalPlay(GameBoard board)
        {
            int num = InputYourNumber(board);

            throw new NotImplementedException();
        }

        private int InputYourNumber(GameBoard board)
        {
            int num = 0;

            while (true) 
            {
                Console.WriteLine("input area number.: ");
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

        private void randomPlay(GameBoard board)
        {
            Random rnd = new Random();
            int num = rnd.Next(1, 10);

            while(board.IsCellEmpty(num) == false)
            {
                num = rnd.Next(1, 10);

            }

            board.UpdateCell(board.GetCell(num), (int)_hand);
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

        #endregion

    }
}

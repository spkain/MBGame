using System;
using System.Threading;

namespace TicTacToe
{
    class GameMain
    {

        public GameMain()
        {
        }

        static void Main()
        {
            new GameMain().MainLoop();
        }

        void MainLoop()
        {
            Console.WriteLine("### Tic Tac Toe game! :-) ###");
            Console.WriteLine();

            Player mainPlayer = new Player(PlayerType.USER);
            Player cpuPlayer = new Player(PlayerType.CPU);

            GameBoard board = new GameBoard();
            Judge judge = new Judge(board);

            board.startgame();
            while (board.IsFinished == false) 
            {
                board.Display();

                mainPlayer.Play(board);
                if (judge.judgegame(mainPlayer) == true) {
                    break;
                }

                cpuPlayer.Play(board);
                if (judge.judgegame(cpuPlayer) == true)
                {
                    break;
                }
            }
            board.endgame();
            Thread.Sleep(3000);   
        }

    }
}

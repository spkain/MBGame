using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe
{
    interface IPlay
    {
        void Play(GameBoard board);
        void WinInfo();
        int GetHand();
    }
}

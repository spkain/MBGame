using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe
{
    class Judge
    {
        private GameBoard _board;

        public Judge(GameBoard board)
        {
            this._board = board;
        }

        internal bool judgegame(Player mainPlayer)
        {
            if (_board.IsWInner(mainPlayer))
                return true;

            if (_board.IsFinished)
                return true;

            return false;
        }
    }
}

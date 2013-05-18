using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe
{
    public interface IBoard
    {
        /// <summary>
        /// print cell-value of board
        /// </summary>
        /// <param name="num">cell number</param>
        void GetCellValInfo(int num);
    }
}

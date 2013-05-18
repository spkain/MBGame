using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe
{
    public interface IPlayLogic
    {
        /// <summary>
        /// pugin name
        /// </summary>
        /// <returns></returns>
        string GetName();

        /// <summary>
        /// Craete Your Return Number from 1 to 9 logic
        /// </summary>
        /// <param name="board"></param>
        /// <returns></returns>
        int GetNumber(IBoard board);
    }
}

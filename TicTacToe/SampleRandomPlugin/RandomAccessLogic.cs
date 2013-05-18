using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe
{
    public class RandomAccessLogic : IPlayLogic
    {

        #region IPlayLogic member
        public string GetName()
        {
            return "RandomAccessLogic";
        }

        public int GetNumber(IBoard board)
        {
            Random rnd = new Random();
            return rnd.Next(1, 10);
        }

        #endregion
    }
}

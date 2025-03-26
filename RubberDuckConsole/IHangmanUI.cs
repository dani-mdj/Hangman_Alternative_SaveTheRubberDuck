using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RubberDuckConsole
{
    interface IHangmanUI
    {
        void DrawBoard();
        void DrawCountDown();
        bool PlayerTurn();
        void Introduction();
        bool PlayAgain();
    }
}

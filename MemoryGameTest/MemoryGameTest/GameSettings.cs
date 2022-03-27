using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryGameTest
{
    public class GameSettings
    {
        public int boardSize
        {
            get; private set;
        }

        public int timeToRemember
        {
            get; private set;
        }
        public int timeToHide
        {
            get; private set;
        }
        public GameSettings(int boardSize, int timeToRemember, int timeToHide)
        {
            this.boardSize = boardSize;
            this.timeToRemember = timeToRemember;
            this.timeToHide = timeToHide;
        }
        public GameSettings()
        {
            this.boardSize = 16;
            this.timeToRemember = 10;
            this.timeToHide = 2;
        }

    }
}

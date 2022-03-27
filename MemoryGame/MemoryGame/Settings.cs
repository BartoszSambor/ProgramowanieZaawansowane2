using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryGame
{
    public class Settings
    {
        public string nick
        {
            get; private set;
        }
        public int cardCount
        {
            get; private set;
        }
        public int timeToRemember
        {
            get; private set;
        }
        public float hideTime
        {
            get; private set;
        }

        public Settings(string nick, int cardCount, int timeToRemember, float hideTime)
        {
            this.nick = nick;
            this.cardCount = cardCount;
            this.timeToRemember = timeToRemember;
            this.hideTime = hideTime;
        }

        public Settings(string nick) : this(nick, 16, 5, 1f) { }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlackJackLibrary;

namespace BlackJackGame
{
    public class RoundEndException : Exception
    {
        public bool IsDealerWin { get; set; }

        public RoundEndException(Player player) : base("Победил " + player.Name)
        {
            IsDealerWin = player is Dealer;
        }
    }
}

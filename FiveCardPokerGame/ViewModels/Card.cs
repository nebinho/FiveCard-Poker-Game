using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiveCardPokerGame.ViewModels
{
    public class Card
    {
            /// <summary>
            /// Type of card
            /// </summary>
            public string Type { get; set; }
            /// <summary>
            /// Color of card
            /// </summary>
            public string Suit { get; set; }
            /// <summary>
            /// Value of card
            /// </summary>
            public int Rank { get; set; }
 
    }
}

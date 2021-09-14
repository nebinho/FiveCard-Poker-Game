using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiveCardPokerGame.ViewModels
{
    public class Card : BaseViewModel
    {
        public enum Suit
        {
            Clubs,
            Diamonds,
            Hearts,
            Spades,
        }
        public enum Value
        {   
            Ace,
            Two,
            Three,
            Four,
            Five,
            Six,
            Seven,
            Eight,
            Nine,
            Ten,
            Jack,
            Queen,
            King,
        }
        public Suit Cardsuit { get; set; }
        public Value Cardvalue { get; set; }
            /// <summary>
            /// Type of card
            /// </summary>
            //public string Type { get; set; }
            ///// <summary>
            ///// Color of card
            ///// </summary>
            //public string Suit { get; set; }
            ///// <summary>
            ///// Value of card
            ///// </summary>
            //public int Rank { get; set; }
 
    }
}

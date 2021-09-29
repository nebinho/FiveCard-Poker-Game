using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiveCardPokerGame.ViewModels
{
    public class Card : BaseViewModel
    {
        /// <summary>
        /// Enum of every suit a card can have.
        /// </summary>
        public enum Suit
        {
            Clubs,
            Diamonds,
            Hearts,
            Spades,
        }
        /// <summary>
        /// Enum of all values a card can have.
        /// </summary>
        public enum Value
        {
            Two ,
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
            Ace,
        }

        public Suit Cardsuit { get; set; }
        public Value Cardvalue { get; set; }
        /// <summary>
        /// Returns this string when displaying this type of object.
        /// </summary>
        /// <returns>string</returns>
        public override string ToString()
        {
            return $"{Cardsuit} {Cardvalue}";
        }

    }
}

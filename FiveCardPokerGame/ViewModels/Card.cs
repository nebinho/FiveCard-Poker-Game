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

        public override string ToString()
        {
            return $"{Cardsuit} {Cardvalue}";
        }

    }
}

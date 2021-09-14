using FiveCardPokerGame.ViewModels;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media.Imaging;
using static FiveCardPokerGame.ViewModels.Card;

namespace FiveCardPokerGame.Converter
{
    
    public class SuitToImgCon : IValueConverter
    {
        
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is Suit && value != null)
            {
                switch (value)
                {
                    case Suit.Spades:
                        return new Uri(@"/Resources/Images Cards/Diamonds Nine.png", UriKind.Relative);
                    case Suit.Hearts:
                        return new Uri(@"/Resources/Images Cards/Spades Eight.png", UriKind.Relative);
                    case Suit.Diamonds:
                        return new Uri(@"/Resources/Images Cards/Clubs Jack.png", UriKind.Relative);
                    case Suit.Clubs:
                        return new Uri(@"/Resources/Images Cards/Clubs Queen.png", UriKind.Relative);
                }
            }
            return null;
        }



        

        //public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        //{
        //    foreach (Card card in deckOfCards.Hand)
        //    {
        //        suit = card.Cardsuit.ToString();
        //        cardValue = card.Cardvalue.ToString();
        //        if (suit == "Spades")
        //        {
        //            if (cardValue == "Ace")
        //            {
        //                return new Uri(@"/Resources/Images Cards/Spades Ace.png", UriKind.Relative);
        //            }
        //            else if (card.Cardvalue == Value.Eight)
        //            {
        //                return new Uri(@"/Resources/Images Cards/Spades Eight.png", UriKind.Relative);
        //            }
        //            else if (card.Cardvalue == Value.Five)
        //            {
        //                return new Uri(@"/Resources/Images Cards/Spades Five.png", UriKind.Relative);
        //            }
        //            else if (card.Cardvalue == Value.Four)
        //            {
        //                return new Uri(@"/Resources/Images Cards/Spades Four.png", UriKind.Relative);
        //            }
        //            else if (card.Cardvalue == Value.Jack)
        //            {
        //                return new Uri(@"/Resources/Images Cards/Spades Jack.png", UriKind.Relative);
        //            }
        //            else if (card.Cardvalue == Value.King)
        //            {
        //                return new Uri(@"/Resources/Images Cards/Spades King.png", UriKind.Relative);
        //            }
        //            else if (card.Cardvalue == Value.Nine)
        //            {
        //                return new Uri(@"/Resources/Images Cards/Spades Nine.png", UriKind.Relative);
        //            }
        //            else if (card.Cardvalue == Value.Queen)
        //            {
        //                return new Uri(@"/Resources/Images Cards/Spades Queen.png", UriKind.Relative);
        //            }
        //            else if (card.Cardvalue == Value.Seven)
        //            {
        //                return new Uri(@"/Resources/Images Cards/Spades Seven.png", UriKind.Relative);
        //            }
        //            else if (card.Cardvalue == Value.Six)
        //            {
        //                return new Uri(@"/Resources/Images Cards/Spades Six.png", UriKind.Relative);
        //            }
        //            else if (card.Cardvalue == Value.Ten)
        //            {
        //                return new Uri(@"/Resources/Images Cards/Spades Ten.png", UriKind.Relative);
        //            }
        //            else if (card.Cardvalue == Value.Three)
        //            {
        //                return new Uri(@"/Resources/Images Cards/Spades Three.png", UriKind.Relative);
        //            }
        //            else
        //            {
        //                return new Uri(@"/Resources/Images Cards/Spades Two.png", UriKind.Relative);
        //            }
        //        }
        //        else if (suit == "Clubs")
        //        {
        //            if (card.Cardvalue == Value.Ace)
        //            {
        //                return new Uri(@"/Resources/Images Cards/Clubs Ace.png", UriKind.Relative);
        //            }
        //            else if (card.Cardvalue == Value.Eight)
        //            {
        //                return new Uri(@"/Resources/Images Cards/Clubs Eight.png", UriKind.Relative);
        //            }
        //            else if (card.Cardvalue == Value.Five)
        //            {
        //                return new Uri(@"/Resources/Images Cards/Clubs Five.png", UriKind.Relative);
        //            }
        //            else if (card.Cardvalue == Value.Four)
        //            {
        //                return new Uri(@"/Resources/Images Cards/Clubs Four.png", UriKind.Relative);
        //            }
        //            else if (card.Cardvalue == Value.Jack)
        //            {
        //                return new Uri(@"/Resources/Images Cards/Clubs Jack.png", UriKind.Relative);
        //            }
        //            else if (card.Cardvalue == Value.King)
        //            {
        //                return new Uri(@"/Resources/Images Cards/Clubs King.png", UriKind.Relative);
        //            }
        //            else if (card.Cardvalue == Value.Nine)
        //            {
        //                return new Uri(@"/Resources/Images Cards/Clubs Nine.png", UriKind.Relative);
        //            }
        //            else if (card.Cardvalue == Value.Queen)
        //            {
        //                return new Uri(@"/Resources/Images Cards/Clubs Queen.png", UriKind.Relative);
        //            }
        //            else if (card.Cardvalue == Value.Seven)
        //            {
        //                return new Uri(@"/Resources/Images Cards/Clubs Seven.png", UriKind.Relative);
        //            }
        //            else if (card.Cardvalue == Value.Six)
        //            {
        //                return new Uri(@"/Resources/Images Cards/Clubs Six.png", UriKind.Relative);
        //            }
        //            else if (card.Cardvalue == Value.Ten)
        //            {
        //                return new Uri(@"/Resources/Images Cards/Clubs Ten.png", UriKind.Relative);
        //            }
        //            else if (card.Cardvalue == Value.Three)
        //            {
        //                return new Uri(@"/Resources/Images Cards/Clubs Three.png", UriKind.Relative);
        //            }
        //            else
        //            {
        //                return new Uri(@"/Resources/Images Cards/Clubs Two.png", UriKind.Relative);
        //            }
        //        }
        //        else if (suit == "Diamonds")
        //        {
        //            if (card.Cardvalue == Value.Ace)
        //            {
        //                return new Uri(@"/Resources/Images Cards/Diamonds Ace.png", UriKind.Relative);
        //            }
        //            else if (card.Cardvalue == Value.Eight)
        //            {
        //                return new Uri(@"/Resources/Images Cards/Diamonds Eight.png", UriKind.Relative);
        //            }
        //            else if (card.Cardvalue == Value.Five)
        //            {
        //                return new Uri(@"/Resources/Images Cards/Diamonds Five.png", UriKind.Relative);
        //            }
        //            else if (card.Cardvalue == Value.Four)
        //            {
        //                return new Uri(@"/Resources/Images Cards/Diamonds Four.png", UriKind.Relative);
        //            }
        //            else if (card.Cardvalue == Value.Jack)
        //            {
        //                return new Uri(@"/Resources/Images Cards/Diamonds Jack.png", UriKind.Relative);
        //            }
        //            else if (card.Cardvalue == Value.King)
        //            {
        //                return new Uri(@"/Resources/Images Cards/Diamonds King.png", UriKind.Relative);
        //            }
        //            else if (card.Cardvalue == Value.Nine)
        //            {
        //                return new Uri(@"/Resources/Images Cards/Diamonds Nine.png", UriKind.Relative);
        //            }
        //            else if (card.Cardvalue == Value.Queen)
        //            {
        //                return new Uri(@"/Resources/Images Cards/Diamonds Queen.png", UriKind.Relative);
        //            }
        //            else if (card.Cardvalue == Value.Seven)
        //            {
        //                return new Uri(@"/Resources/Images Cards/Diamonds Seven.png", UriKind.Relative);
        //            }
        //            else if (card.Cardvalue == Value.Six)
        //            {
        //                return new Uri(@"/Resources/Images Cards/Diamonds Six.png", UriKind.Relative);
        //            }
        //            else if (card.Cardvalue == Value.Ten)
        //            {
        //                return new Uri(@"/Resources/Images Cards/Diamonds Ten.png", UriKind.Relative);
        //            }
        //            else if (card.Cardvalue == Value.Three)
        //            {
        //                return new Uri(@"/Resources/Images Cards/Diamonds Three.png", UriKind.Relative);
        //            }
        //            else
        //            {
        //                return new Uri(@"/Resources/Images Cards/Diamonds Two.png", UriKind.Relative);
        //            }
        //        }
        //        else if (suit == "Hearts")
        //        {
        //            if (card.Cardvalue == Value.Ace)
        //            {
        //                return new Uri(@"/Resources/Images Cards/Hearts Ace.png", UriKind.Relative);
        //            }
        //            else if (card.Cardvalue == Value.Eight)
        //            {
        //                return new Uri(@"/Resources/Images Cards/Hearts Eight.png", UriKind.Relative);
        //            }
        //            else if (card.Cardvalue == Value.Five)
        //            {
        //                return new Uri(@"/Resources/Images Cards/Hearts Five.png", UriKind.Relative);
        //            }
        //            else if (card.Cardvalue == Value.Four)
        //            {
        //                return new Uri(@"/Resources/Images Cards/Hearts Four.png", UriKind.Relative);
        //            }
        //            else if (card.Cardvalue == Value.Jack)
        //            {
        //                return new Uri(@"/Resources/Images Cards/Hearts Jack.png", UriKind.Relative);
        //            }
        //            else if (card.Cardvalue == Value.King)
        //            {
        //                return new Uri(@"/Resources/Images Cards/Hearts King.png", UriKind.Relative);
        //            }
        //            else if (card.Cardvalue == Value.Nine)
        //            {
        //                return new Uri(@"/Resources/Images Cards/Hearts Nine.png", UriKind.Relative);
        //            }
        //            else if (card.Cardvalue == Value.Queen)
        //            {
        //                return new Uri(@"/Resources/Images Cards/Hearts Queen.png", UriKind.Relative);
        //            }
        //            else if (card.Cardvalue == Value.Seven)
        //            {
        //                return new Uri(@"/Resources/Images Cards/Hearts Seven.png", UriKind.Relative);
        //            }
        //            else if (card.Cardvalue == Value.Six)
        //            {
        //                return new Uri(@"/Resources/Images Cards/Hearts Six.png", UriKind.Relative);
        //            }
        //            else if (card.Cardvalue == Value.Ten)
        //            {
        //                return new Uri(@"/Resources/Images Cards/Hearts Ten.png", UriKind.Relative);
        //            }
        //            else if (card.Cardvalue == Value.Three)
        //            {
        //                return new Uri(@"/Resources/Images Cards/Hearts Three.png", UriKind.Relative);
        //            }
        //            else
        //            {
        //                return new Uri(@"/Resources/Images Cards/Hearts Two.png", UriKind.Relative);
        //            }
        //        }
        //    }
        //    return null;
        //}

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

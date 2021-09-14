using FiveCardPokerGame.ViewModels;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using static FiveCardPokerGame.ViewModels.Card;

namespace FiveCardPokerGame.Converter
{
    public class IntToImgCon :  IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {



            if (value is Suit && value != null)
            {
                switch (value)
                {
                    case Suit.Clubs:
                        return new Uri(@"C:\Users\keeew\Source\Repos\SUP21_Grupp2\FiveCardPokerGame\Resources\Images Cards\Clubs Ace.png", UriKind.Relative);

                    case Suit.Hearts:
                        return new Uri(@"C:\Users\keeew\Source\Repos\SUP21_Grupp2\FiveCardPokerGame\Resources\Images Cards\Clubs Ace.png", UriKind.Relative);
                    case Suit.Diamonds:
                        return new Uri(@"C:\Users\keeew\Source\Repos\SUP21_Grupp2\FiveCardPokerGame\Resources\Images Cards\Clubs Ace.png", UriKind.Relative);
                    case Suit.Spades:
                        return new Uri(@"C:\Users\keeew\Source\Repos\SUP21_Grupp2\FiveCardPokerGame\Resources\Images Cards\Clubs Ace.png", UriKind.Relative);
                    default:
                        break;
                }
                
            }
            return null;

            //switch (value)
            //{
            //    case Suit.Clubs:
            //        return new Uri(@"C:\Users\keeew\Source\Repos\SUP21_Grupp2\FiveCardPokerGame\Resources\Images Cards\Clubs Ace.png", UriKind.Relative);

            //    case Suit.Hearts:
            //        return new Uri(@"C:\Users\keeew\Source\Repos\SUP21_Grupp2\FiveCardPokerGame\Resources\Images Cards\Clubs Ace.png", UriKind.Relative);
            //    case Suit.Diamonds:
            //        return new Uri(@"C:\Users\keeew\Source\Repos\SUP21_Grupp2\FiveCardPokerGame\Resources\Images Cards\Clubs Ace.png", UriKind.Relative);
            //    case Suit.Spades:
            //        return new Uri(@"C:\Users\keeew\Source\Repos\SUP21_Grupp2\FiveCardPokerGame\Resources\Images Cards\Clubs Ace.png", UriKind.Relative);
            //    default:
            //        break;
            //}
            //return null;



            //var suit = (Suit)value;
            //var path = String.Empty;
            //switch (suit)
            //{
            //    case Suit.Clubs:
            //        path = "C:/Users/keeew/Source/Repos/SUP21_Grupp2/FiveCardPokerGame/Resources/Images Cards/Clubs Ace.png";
            //        break;
            //    case Suit.Diamonds:
            //        path = "C:/Users/keeew/Source/Repos/SUP21_Grupp2/FiveCardPokerGame/Resources/Images Cards/Clubs Ace.png";
            //        break;
            //    case Suit.Hearts:
            //        path = "C:/Users/keeew/Source/Repos/SUP21_Grupp2/FiveCardPokerGame/Resources/Images Cards/Clubs Ace.png";
            //        break;
            //    case Suit.Spades:
            //        path = "C:/Users/keeew/Source/Repos/SUP21_Grupp2/FiveCardPokerGame/Resources/Images Cards/Clubs Ace.png";
            //        break;
            //}
            //return path;


        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

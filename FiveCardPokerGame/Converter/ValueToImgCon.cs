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
    class ValueToImgCon : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is Value && value != null)
            {
                switch (value)
                {
                    case Value.Ace:
                        return new Uri(@"/Resources/Images Cards/Hearts Ace.png", UriKind.Relative);
                    case Value.Eight:
                        return new Uri(@"/Resources/Images Cards/Hearts Eight.png", UriKind.Relative);
                    case Value.Five:
                        return new Uri(@"/Resources/Images Cards/Hearts Five.png", UriKind.Relative);
                    case Value.Four:
                        return new Uri(@"/Resources/Images Cards/Hearts Four.png", UriKind.Relative);
                    case Value.Jack:
                        return new Uri(@"/Resources/Images Cards/Hearts Jack.png", UriKind.Relative);
                    case Value.King:
                        return new Uri(@"/Resources/Images Cards/Hearts King.png", UriKind.Relative);
                    case Value.Nine:
                        return new Uri(@"/Resources/Images Cards/Hearts Nine.png", UriKind.Relative);
                    case Value.Queen:
                        return new Uri(@"/Resources/Images Cards/Hearts Queen.png", UriKind.Relative);
                    case Value.Seven:
                        return new Uri(@"/Resources/Images Cards/Hearts Seven.png", UriKind.Relative);
                    case Value.Six:
                        return new Uri(@"/Resources/Images Cards/Hearts Six.png", UriKind.Relative);
                    case Value.Ten:
                        return new Uri(@"/Resources/Images Cards/Hearts Ten.png", UriKind.Relative);
                    case Value.Three:
                        return new Uri(@"/Resources/Images Cards/Hearts Three.png", UriKind.Relative);
                    case Value.Two:
                        return new Uri(@"/Resources/Images Cards/Hearts Two.png", UriKind.Relative);
                }
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

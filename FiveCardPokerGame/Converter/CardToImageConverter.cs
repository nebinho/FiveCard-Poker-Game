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
    
    public class CardToImageConverter : IValueConverter
    {
        
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var imageBit = new BitmapImage();

            if (value is Card && value != null)
            {

                return imageBit = new BitmapImage(new Uri(@"/Resources/Images Cards/" + value.ToString() + ".png", UriKind.Relative));
                    
                               
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

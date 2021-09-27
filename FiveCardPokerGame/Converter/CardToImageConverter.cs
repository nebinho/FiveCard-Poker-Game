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
        /// <summary>
        /// Converts the value of a Card to a string and uses the propertys to find the right picture and display that on a CardView.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var imageBit = new BitmapImage();

            if (value is Card && value != null)
            {
                return imageBit = new BitmapImage(new Uri(@"/Resources/ImagesCards/" + value.ToString() + ".png", UriKind.Relative));
            }
            return null;
        }
        /// <summary>
        /// Is not used
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

    }
}

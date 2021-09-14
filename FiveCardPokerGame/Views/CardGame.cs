using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using static FiveCardPokerGame.ViewModels.Card;

namespace FiveCardPokerGame.Views
{
    public class CardGame : UserControl
    {
        public Suit CurrentSuit
        {
            get { return (Suit)GetValue(CurrentSuitProperty); }
            set { SetValue(CurrentSuitProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CurrentSuit.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CurrentSuitProperty =
            DependencyProperty.Register("CurrentSuit", typeof(Suit), typeof(CardView), new PropertyMetadata(Suit.Hearts));
    }
}

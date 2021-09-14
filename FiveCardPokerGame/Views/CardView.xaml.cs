using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static FiveCardPokerGame.ViewModels.Card;

namespace FiveCardPokerGame.Views
{
    /// <summary>
    /// Interaction logic for CardView.xaml
    /// </summary>
    public partial class CardView : UserControl
    {






        public Suit CurrentSuit
        {
            get { return (Suit)GetValue(CurrentSuitProperty); }
            set { SetValue(CurrentSuitProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CurrentSuit.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CurrentSuitProperty =
            DependencyProperty.Register("CurrentSuit", typeof(Suit), typeof(CardView), new PropertyMetadata(Suit.Hearts));





        //public SolidColorBrush CardColor
        //{
        //    get { return (SolidColorBrush)GetValue(CardColorProperty); }
        //    set { SetValue(CardColorProperty, value); }
        //}

        //// Using a DependencyProperty as the backing store for CardColor.  This enables animation, styling, binding, etc...
        //public static readonly DependencyProperty CardColorProperty =
        //    DependencyProperty.Register("CardColor", typeof(SolidColorBrush), typeof(CardView), new PropertyMetadata(Brushes.Yellow));


        public CardView()
        {
            InitializeComponent();
        }
    }
}

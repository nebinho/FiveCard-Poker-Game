using FiveCardPokerGame.ViewModels;
using System;
using System.Collections;
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
        

        public Suit GetCardSuit
        {
            get { return (Suit)GetValue(GetSuitProperty); }
            set { SetValue(GetSuitProperty, value); }
        }

        // Using a DependencyProperty as the backing store for GetSuit.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty GetSuitProperty =
            DependencyProperty.Register("GetSuit", typeof(Suit), typeof(CardGame), new PropertyMetadata(Suit.Spades));



        public Value GetCardValue
        {
            get { return (Value)GetValue(GetValueProperty); }
            set { SetValue(GetValueProperty, value); }
        }

        // Using a DependencyProperty as the backing store for GetValue.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty GetValueProperty =
            DependencyProperty.Register("GetValue", typeof(Value), typeof(CardGame), new PropertyMetadata(Value.Ace));







    }
}

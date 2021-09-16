using FiveCardPokerGame.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace FiveCardPokerGame.Views
{
    /// <summary>
    /// Interaction logic for GameView.xaml
    /// </summary>
    public partial class GameView : UserControl
    {
        public GameView()
        {
            InitializeComponent();            
        }

        public GameViewModel gameVM { get; set; }
        public bool IsButtonEnabled
        {
            get { return (bool)GetValue(IsButtonEnabledProperty); }
            set { SetValue(IsButtonEnabledProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IsButtonEnabled.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsButtonEnabledProperty =
            DependencyProperty.Register("IsButtonEnabled", typeof(bool), typeof(GameView), new PropertyMetadata(false));


        // @"/Resources/Images Cards/Clubs Two.png"
        private void card_DragOver(object sender, DragEventArgs e)
        {            
            GameViewModel gameViewModel = (GameViewModel)DataContext;
            object data = e.Data.GetData(DataFormats.Serializable);
            if (data is CardView cardView)
            {
                Point dropPosition = e.GetPosition(dropZone);
                Canvas.SetLeft(cardView, dropPosition.X);
                Canvas.SetTop(cardView, dropPosition.Y);
                if (!gameViewModel.DeckOfCards.ThrownCards.Contains(cardView))
                {
                    gameViewModel.DeckOfCards.ThrowCard(gameViewModel.DeckOfCards.CardViews.IndexOf(cardView));
                    gameViewModel.DeckOfCards.CardViews.Remove(cardView);
                    myCards.Children.Remove(cardView);
                    gameViewModel.DeckOfCards.ThrownCards.Add(cardView);
                    //dropZone.Children.Add(cardView);
                    IsButtonEnabledLol(gameViewModel);
                }
            }
        }

        public void IsButtonEnabledLol(GameViewModel gameViewModel)
        {         
            if (gameViewModel.DeckOfCards.Hand.Count <5)
            {
                DrawNewCards.IsEnabled = true; 
            }

            else
            {
                DrawNewCards.IsEnabled = false;
            }
        }

        private void card_Drop(object sender, DragEventArgs e)
        {
            if (e.Source is CardView cardView)
            {
                var left = Canvas.GetLeft(cardView);
                var top = Canvas.GetTop(cardView);
                var viewModel = (GameViewModel)DataContext;
            }            
        }
    }
}

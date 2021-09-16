using FiveCardPokerGame.ViewModels;
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

namespace FiveCardPokerGame.Views
{
    /// <summary>
    /// Interaction logic for GameView.xaml
    /// </summary>
    public partial class GameView : UserControl
    {



        public string SetScore
        {
            get { return (string)GetValue(SetScoreProperty); }
            set { SetValue(SetScoreProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SetScore.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SetScoreProperty =
            DependencyProperty.Register("SetScore", typeof(string), typeof(GameView), new PropertyMetadata("0"));

        



        public GameView()
        {
            InitializeComponent();
            
        }

        private void card_DragOver(object sender, DragEventArgs e)
        {            
            object data = e.Data.GetData(DataFormats.Serializable);
            if (data is CardView cardView)
            {
                Point dropPosition = e.GetPosition(dropZone);
                Canvas.SetLeft(cardView, dropPosition.X);
                Canvas.SetTop(cardView, dropPosition.Y);
                if (!dropZone.Children.Contains(cardView))
                {
                    GameViewModel gameViewModel = (GameViewModel)DataContext;
                    gameViewModel.DeckOfCards.ThrowCard(gameViewModel.DeckOfCards.CardViews.IndexOf(cardView));
                    gameViewModel.DeckOfCards.CardViews.Remove(cardView);
                    myCards.Children.Remove(cardView);
                    gameViewModel.DeckOfCards.ThrownCards.Add(cardView);
                    //dropZone.Children.Add(cardView);
                }
               
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

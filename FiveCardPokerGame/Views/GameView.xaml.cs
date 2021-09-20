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
        private void card_DragOver(object sender, DragEventArgs e)
        {
            GameViewModel gameViewModel = (GameViewModel)DataContext;
            object data = e.Data.GetData(DataFormats.Serializable);

            if (gameViewModel.IsButtonEnabled = gameViewModel.DeckOfCards.CanDrawNewCard() == true) //Man får bara flytta kort om man har byten kvar.
            {
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
                    }
                }
                gameViewModel.IsButtonEnabled = gameViewModel.DeckOfCards.IsHandFiveOrLess();
                gameViewModel.IsButtonEnabled = gameViewModel.DeckOfCards.CanDrawNewCard();  //Kallar på metoden för att kolla antal byten.              
            }

            else
            {
                MessageBox.Show("Du har förbrukat dina byten"); //Försöker man ändå att slänga kort får man upp en ruta om att man inte får.
            }
        }        

        private void card_Drop(object sender, DragEventArgs e)
        {
            GameViewModel gameViewModel = (GameViewModel)DataContext;
            if (e.Source is CardView cardView)
            {
                var left = Canvas.GetLeft(cardView);
                var top = Canvas.GetTop(cardView);
                var viewModel = (GameViewModel)DataContext;                
            }    
        }

        private void myCards_DragOver(object sender, DragEventArgs e)
        {
            GameViewModel gameViewModel = (GameViewModel)DataContext;
            object data = e.Data.GetData(DataFormats.Serializable);

            if (data is CardView cardView)
            {
                if (!gameViewModel.DeckOfCards.CardViews.Contains(cardView))
                {
                    gameViewModel.DeckOfCards.ThrownCards.Remove(cardView);
                    gameViewModel.DeckOfCards.CardViews.Add(cardView);
                    gameViewModel.DeckOfCards.Hand.Add(gameViewModel.DeckOfCards.Card(cardView));

                    gameViewModel.IsButtonEnabled = gameViewModel.DeckOfCards.IsHandFiveOrLess();
    
                }

            }
        }

        private void myCards_Drop(object sender, DragEventArgs e)
        {
            GameViewModel gameViewModel = (GameViewModel)DataContext;
            if (e.Source is CardView cardView)
            {
                var left = Canvas.GetLeft(cardView);
                var top = Canvas.GetTop(cardView);
                var viewModel = (GameViewModel)DataContext;
            }
        }
    }
}

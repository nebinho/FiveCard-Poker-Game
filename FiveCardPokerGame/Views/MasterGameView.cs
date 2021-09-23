using FiveCardPokerGame.Data;
using FiveCardPokerGame.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Resources;
using static FiveCardPokerGame.ViewModels.PlayerViewModel;

namespace FiveCardPokerGame.Views
{
    public class MasterGameView : UserControl
    {
        public CardView CardView { get; set; }
        public GameView GameView { get; set; }
        public StartView StartView { get; set; }
        //public ICommand SetPlayerCommand { get; set; }

        //public Player Player { get; set; } = new Player();
        public MasterGameView()
        {
            
        }
        public void card_DragOver(object sender, DragEventArgs e)
        {
            GameViewModel gameViewModel = (GameViewModel)DataContext;
            object data = e.Data.GetData(DataFormats.Serializable);

            if (gameViewModel.IsButtonEnabled = gameViewModel.DeckOfCards.CanDrawNewCard() == true) //Man får bara flytta kort om man har byten kvar.
            {
                if (data is CardView cardView)
                {
                    
                    if (!gameViewModel.DeckOfCards.ThrownCards.Contains(cardView))
                    {
                        gameViewModel.DeckOfCards.ThrowCard(gameViewModel.DeckOfCards.CardViews.IndexOf(cardView));
                        gameViewModel.DeckOfCards.CardViews.Remove(cardView);
                        gameViewModel.DeckOfCards.ThrownCards.Add(cardView);
                    }
                }
                gameViewModel.IsButtonEnabled = gameViewModel.DeckOfCards.IsHandFiveOrLess();
                gameViewModel.IsButtonEnabled = gameViewModel.DeckOfCards.CanDrawNewCard();  //Kallar på metoden för att kolla antal byten.
                gameViewModel.IsCardEnabled = gameViewModel.CardEnabler();
                
            }
            else
            {
                //MessageBox.Show("Du har förbrukat dina byten"); //Försöker man ändå att slänga kort får man upp en ruta om att man inte får.
            }

        }
        public void card_Drop(object sender, DragEventArgs e)
        {
            GameViewModel gameViewModel = (GameViewModel)DataContext;
            if (e.Source is CardView cardView)
            {
                var left = Canvas.GetLeft(cardView);
                var top = Canvas.GetTop(cardView);
                var viewModel = (GameViewModel)DataContext;
            }
        }

        

        public void myCards_DragOver(object sender, DragEventArgs e)
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
                    gameViewModel.IsCardEnabled = gameViewModel.CardEnabler();

                }

            }
        }

        public void ChangeCursorGiveFeedback(object sender, GiveFeedbackEventArgs e)
        {
            GameViewModel gameViewModel = (GameViewModel)DataContext;
            if (e.Effects.HasFlag(DragDropEffects.Move))
            {
                if (!gameViewModel.DeckOfCards.CanDrawNewCard()==false)
                {
                    StreamResourceInfo cardCurs = Application.GetResourceStream(new Uri("/Resources/Cursor/x-CardBack.cur", UriKind.Relative));
                    Mouse.SetCursor(new Cursor(cardCurs.Stream));
                }
            }
            e.Handled = true;
        }

        public void myCards_Drop(object sender, DragEventArgs e)
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

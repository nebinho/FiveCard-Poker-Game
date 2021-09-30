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

namespace FiveCardPokerGame.Views
{
    public class MasterGameView : UserControl
    {
        

        public MasterGameView()
        {
            
        }
        /// <summary>
        /// Removes the card from the players hand and adds it in another observable collection.
        /// This incase the player changes their mind and wants to undo the throw.
        /// Used for Drag and drop
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Card_DragOver(object sender, DragEventArgs e)
        {
            GameViewModel gameViewModel = (GameViewModel)DataContext;
            object data = e.Data.GetData(DataFormats.Serializable);

            if (gameViewModel.IsButtonEnabled = gameViewModel.DeckOfCards.CanDrawNewCard() == true)
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
                gameViewModel.IsButtonEnabled = gameViewModel.DeckOfCards.CanDrawNewCard();
                gameViewModel.IsCardEnabled = gameViewModel.CardEnabler();

            }
            else
            {
            }
        }
        /// <summary>
        /// Plays a sound when player drops a card in the UI.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Card_Drop(object sender, DragEventArgs e)
        {
            Global.PlayDragAndDropSound();            
        }
        /// <summary>
        /// Recreates the thrown card and adds it in the players hand.
        /// Used for drag and drop
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void MyCards_DragOver(object sender, DragEventArgs e)
        {
            GameViewModel gameViewModel = (GameViewModel)DataContext;
            object data = e.Data.GetData(DataFormats.Serializable);

            if (data is CardView cardView)
            {
                if (!gameViewModel.DeckOfCards.CardViews.Contains(cardView))
                {
                    gameViewModel.DeckOfCards.ThrownCards.Remove(cardView);
                    gameViewModel.DeckOfCards.CardViews.Add(cardView);
                    gameViewModel.DeckOfCards.Hand.Add(GameEngine.Card(cardView));

                    gameViewModel.IsButtonEnabled = gameViewModel.DeckOfCards.IsHandFiveOrLess();
                    gameViewModel.IsCardEnabled = gameViewModel.CardEnabler();
                }
            }
        }
        /// <summary>
        /// Changes the cursor image (.cur) to a image of a card when the player has draws left.
        /// Uses drag and drop.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void ChangeCursorGiveFeedback(object sender, GiveFeedbackEventArgs e)
        {
            GameViewModel gameViewModel = (GameViewModel)DataContext;
            if (e.Effects.HasFlag(DragDropEffects.Move))
            {
                if (!gameViewModel.DeckOfCards.CanDrawNewCard()==false)
                {
                    
                    StreamResourceInfo cardCurs = Application.GetResourceStream(new Uri("/Resources/Cursor/xCard.cur", UriKind.Relative));
                    Mouse.SetCursor(new Cursor(cardCurs.Stream));                    
                }
                
            }
            e.Handled = true;
        }
    }
}

using FiveCardPokerGame.ViewModels;
using FiveCardPokerGame.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FiveCardPokerGame.Commands
{
    public class DrawCardCommand : ICommand
    {
        private GameViewModel gameViewModel;

        public DrawCardCommand(GameViewModel gameViewModel)
        {
            this.gameViewModel = gameViewModel;
        }

        public event EventHandler CanExecuteChanged;
        /// <summary>
        /// Can always execute
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public bool CanExecute(object parameter) => true;
        /// <summary>
        /// Deals new cards from the deck.
        /// Creates new CardViews that displays the cards for the player.
        /// Clears the ThrownCards observable collection so that they are removed from the game.
        /// Sets the IsEnable of a button by running a method.
        /// Sets the picture on the button depending on if a player can draw a card (depending on cards in hand) or not.
        /// </summary>
        /// <param name="parameter"></param>
        public void Execute(object parameter)
        {
            gameViewModel.DeckOfCards.DealCards();
            gameViewModel.DeckOfCards.CreateCardViews();
            gameViewModel.DeckOfCards.ThrownCards.Clear();
            gameViewModel.IsButtonEnabled = gameViewModel.DeckOfCards.IsHandFiveOrLess();
            gameViewModel.IsCardEnabled = gameViewModel.CardEnabler();
            gameViewModel.DeckOfCards.DrawsLeft--;

        }

    }
}

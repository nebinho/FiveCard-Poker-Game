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
    public class RemoveCardCommand : ICommand
    {
        private GameViewModel gameViewModel;

        public RemoveCardCommand(GameViewModel gameViewModel)
        {
            this.gameViewModel = gameViewModel;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter) => true;
        

        public void Execute(object parameter)
        {
            var cardView = (CardView)parameter;
            gameViewModel.DeckOfCards.CardViews.Remove(cardView);
        }
    }
}

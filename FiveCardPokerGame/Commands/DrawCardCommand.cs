using FiveCardPokerGame.ViewModels;
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

        public bool CanExecute(object parameter) => true;

        public void Execute(object parameter)
        {
            gameViewModel.DeckOfCards.DealCards();
            gameViewModel.DeckOfCards.CreateCardViews();
            gameViewModel.DeckOfCards.ThrownCards.Clear();
        }
    }
}

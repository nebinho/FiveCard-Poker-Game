using FiveCardPokerGame.Data;
using FiveCardPokerGame.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FiveCardPokerGame.Commands
{
    class EndViewCommand : ICommand
    {
        private GameViewModel gameViewModel;

        public EndViewCommand(GameViewModel gameViewModel)
        {
            this.gameViewModel = gameViewModel;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            Global.EndScore = gameViewModel.DeckOfCards.PokerHands.Score;
            gameViewModel.SelectedViewModel = new EndOfGameViewModel();
            
            
        }
    }
}

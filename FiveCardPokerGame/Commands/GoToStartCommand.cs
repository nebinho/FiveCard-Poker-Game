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
    class GoToStartCommand : ICommand
    {
        private EndOfGameViewModel endOfGameViewModel;

        public GoToStartCommand(EndOfGameViewModel endOfGameViewModel)
        {
            this.endOfGameViewModel = endOfGameViewModel;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            endOfGameViewModel.SelectedViewModel = new PlayerDb();
        }
    }
}

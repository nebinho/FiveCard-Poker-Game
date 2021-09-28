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
    class ReturnToStartCommand : ICommand
    {
        private HighScoreViewModel highScoreViewModel;

        public ReturnToStartCommand(HighScoreViewModel highScoreViewModel)
        {
            this.highScoreViewModel = highScoreViewModel;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true ;
        }

        public void Execute(object parameter)
        {
            highScoreViewModel.SelectedViewModel = new PlayerDb();
        }
    }
}

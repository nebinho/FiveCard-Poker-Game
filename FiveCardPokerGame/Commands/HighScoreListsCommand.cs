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
    class HighScoreListsCommand : ICommand
    {
        private HighScoreViewModel highScoreViewModel;
        private PlayerDb playerDb;

        public HighScoreListsCommand(PlayerDb playerDb)
        {
            this.playerDb = playerDb;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
           return true;
        }

        public void Execute(object parameter)
        {
            Global.PlayClickSound();
            playerDb.SelectedViewModel = new HighScoreViewModel();
        }
    }
}

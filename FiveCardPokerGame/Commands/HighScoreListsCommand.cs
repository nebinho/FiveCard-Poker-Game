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
        private PlayerDbViewModel playerDb;

        public HighScoreListsCommand(PlayerDbViewModel playerDb)
        {
            this.playerDb = playerDb;
        }

        public event EventHandler CanExecuteChanged;
        /// <summary>
        /// Can always execute.
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public bool CanExecute(object parameter) => true;
        /// <summary>
        /// Plays a sound when command is used.
        /// Displays the HighScoreView when command is used.
        /// </summary>
        /// <param name="parameter"></param>
        public void Execute(object parameter)
        {
            Global.PlayClickSound();
            playerDb.SelectedViewModel = new HighScoreViewModel();
        }
    }
}

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
        private readonly HighScoreViewModel highScoreViewModel;

        public ReturnToStartCommand(HighScoreViewModel highScoreViewModel)
        {
            this.highScoreViewModel = highScoreViewModel;
        }

        public event EventHandler CanExecuteChanged
        {
            add { }
            remove { }
        }

        /// <summary>
        /// Can always execute.
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public bool CanExecute(object parameter) => true;
        /// <summary>
        /// Restarts the game, displays  the StartView.
        /// </summary>
        /// <param name="parameter"></param>
        public void Execute(object parameter)
        {
            Global.PlayClickSound();
            highScoreViewModel.SelectedViewModel = new PlayerDbViewModel();
        }
    }
}

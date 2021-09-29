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
    class RestartCommand : ICommand
    {
        private HowToPlayViewModel howToPlayViewModel;

        public RestartCommand(HowToPlayViewModel howToPlayViewModel)
        {
            this.howToPlayViewModel = howToPlayViewModel;
        }

        public event EventHandler CanExecuteChanged;
        /// <summary>
        /// Can always execute
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public bool CanExecute(object parameter) => true;
        /// <summary>
        /// Restarts the game and displays the StartView.
        /// </summary>
        /// <param name="parameter"></param>
        public void Execute(object parameter)
        {
            howToPlayViewModel.SelectedViewModel = new PlayerDb();
            Global.PlayClickSound();
        }
    }
}

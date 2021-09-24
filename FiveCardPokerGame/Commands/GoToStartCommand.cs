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
        /// <summary>
        /// Can always execute.
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public bool CanExecute(object parameter) => true;
        /// <summary>
        /// Returns the player to the startscreen by setting the SelectedViewModel (Binded to contentcontrol in XAML) to a new PlayerDb.
        /// </summary>
        /// <param name="parameter"></param>
        public void Execute(object parameter)
        {
            endOfGameViewModel.SelectedViewModel = new PlayerDb();
        }

    }
}

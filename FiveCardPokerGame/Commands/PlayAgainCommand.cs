using FiveCardPokerGame.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FiveCardPokerGame.Commands
{
    class PlayAgainCommand : ICommand
    {
        private EndOfGameViewModel endOfGameViewModel;

        public PlayAgainCommand(EndOfGameViewModel endOfGameViewModel)
        {
            this.endOfGameViewModel = endOfGameViewModel;
        }

        public event EventHandler CanExecuteChanged;
        /// <summary>
        /// Always returns true. Can always execute.
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public bool CanExecute(object parameter) => true;
        /// <summary>
        /// Returns the player to the GameView so the player can play again. This by simply setting the SelectedViewModel (binded to contentcontrol in XAML) to a new GameViewModel.
        /// </summary>
        /// <param name="parameter"></param>
        public void Execute(object parameter)
        {
            endOfGameViewModel.SelectedViewModel = new GameViewModel();
        }
    }
}

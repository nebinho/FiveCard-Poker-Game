using FiveCardPokerGame.Data;
using FiveCardPokerGame.ViewModels;
using FiveCardPokerGame.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace FiveCardPokerGame.Commands
{
    class UpdateViewAndSaveDataCommand : ICommand
    {
        private readonly PlayerDbViewModel playerDb;

        public UpdateViewAndSaveDataCommand(PlayerDbViewModel playerDb)
        {
            this.playerDb = playerDb;
        }

        public event EventHandler CanExecuteChanged
        {
            add { }
            remove { }
        }

        /// <summary>
        /// Can always execute
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public bool CanExecute(object parameter) => true;
        /// <summary>
        /// Method the executes when pressing the button that is binded to this command. First checks so that there is a player and a difficulty selected, if not then it returns feedback to the user.
        /// Else it sets the difficulty to a global property that can be used everywhere, same goes for the selected player.
        /// Updates the viewmodel when it sets the SelectedViewModel to a new GameViewModel();
        /// </summary>
        /// <param name="parameter"></param>
        public void Execute(object parameter)
        {
            Global.PlayClickSound();

            if (playerDb.SelectedPlayer == null || playerDb.SelectedDifficulty == 0)
            {
                playerDb.FeedbackString = "A player and difficulty must be selected";
            }
            else
            {
                Global.Difficulty = playerDb.SelectedDifficulty;
                Global.MyPlayer = playerDb.SelectedPlayer;
                playerDb.SelectedViewModel = new GameViewModel();
            }
        }

    }
}

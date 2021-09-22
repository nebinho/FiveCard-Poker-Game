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
        private PlayerDb playerDb;

        public UpdateViewAndSaveDataCommand(PlayerDb playerDb)
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
            Global.Difficulty = playerDb.SelectedDifficulty;
            Global.MyPlayer = playerDb.SelectedPlayer;
            playerDb.SelectedViewModel = new GameViewModel();                      
        }
    }
}

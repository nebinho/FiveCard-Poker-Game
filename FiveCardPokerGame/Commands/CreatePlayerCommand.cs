using FiveCardPokerGame.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FiveCardPokerGame.Commands
{
    class CreatePlayerCommand : ICommand
    {
        private PlayerDb playerDb;

        public CreatePlayerCommand(PlayerDb playerDb)
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
            playerDb.CreatePlayer(playerDb.NewPlayer);
            playerDb.GetPlayers();
        }

    }
}

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
    class RulesCommand : ICommand
    {
        private PlayerDb playerDb;

        public RulesCommand(PlayerDb playerDb)
        {
            this.playerDb = playerDb;
        }

        public event EventHandler CanExecuteChanged;
        /// <summary>
        /// Can always execute
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns>true</returns>
        public bool CanExecute(object parameter) => true;
        /// <summary>
        /// Displays the HowToPlayView and plays a sound
        /// </summary>
        /// <param name="parameter"></param>
        public void Execute(object parameter)
        {
            playerDb.SelectedViewModel = new HowToPlayViewModel();
            Global.PlayClickSound();
        }
    }
}

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

        public bool CanExecute(object parameter) => true;

        public void Execute(object parameter)
        {
            howToPlayViewModel.SelectedViewModel = new PlayerDb();
            Global.PlayClickSound();
        }
    }
}

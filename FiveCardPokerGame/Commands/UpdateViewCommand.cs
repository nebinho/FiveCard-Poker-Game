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
    class UpdateViewCommand : ICommand
    {
        private readonly BaseViewModel mainViewModel;
        private readonly PlayerDb playerDB;

        public UpdateViewCommand(BaseViewModel mainViewModel)
        {
            this.mainViewModel = mainViewModel;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            
            if (parameter.ToString() == "GameViewModel")
            {
                mainViewModel.SelectedViewModel = new GameViewModel();
                
            }
        }

    }
}

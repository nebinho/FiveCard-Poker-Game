using FiveCardPokerGame.ViewModels;
using FiveCardPokerGame.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FiveCardPokerGame.Commands
{
    class UpdateViewCommand : ICommand
    {
        private BaseViewModel mainViewModel;

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
            if (parameter.ToString() == "CardOneView")
            {
                mainViewModel.SelectedViewModel = new CardOneView();
            }

            //else if (parameter.ToString() == "CardView")
            //{
            //    mainViewModel.SelectedViewModel = new CardView();
            //}
        }

    }
}

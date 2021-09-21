using FiveCardPokerGame.Commands;
using FiveCardPokerGame.Data;
using FiveCardPokerGame.Views;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using static FiveCardPokerGame.ViewModels.PlayerViewModel;

namespace FiveCardPokerGame.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class BaseViewModel
    {
        public BaseViewModel SelectedViewModel { get; set; }
        
        //public PlayerDb PlayerDb { get; set; } = new PlayerDb();
        public Player Player { get; set; }
        public ICommand UpdateViewCommand { get; set; }

        public BaseViewModel()
        {
            UpdateViewCommand = new UpdateViewCommand(this);
            
        }


    }
}

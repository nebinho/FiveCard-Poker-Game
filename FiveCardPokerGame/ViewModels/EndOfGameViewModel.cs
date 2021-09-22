using FiveCardPokerGame.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FiveCardPokerGame.ViewModels
{
   public class EndOfGameViewModel : BaseViewModel
    {
        public string EndScore { get; set; }

        public ICommand PlayAgainCommand { get; set; }

        public ICommand GoToStartCommand { get; set; }

        public BaseViewModel SelectedViewModel { get; set; }

        public EndOfGameViewModel()
        {
            EndScore = Global.EndScore.ToString();
            PlayAgainCommand = new PlayAgainCommand(this);
            GoToStartCommand = new GoToStartCommand(this);
        }
    }
}

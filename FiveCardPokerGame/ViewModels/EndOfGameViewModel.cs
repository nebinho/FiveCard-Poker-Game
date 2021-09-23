using FiveCardPokerGame.Commands;
using FiveCardPokerGame.Data;
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
        public HighScoreDb highScoreDb = new HighScoreDb();
        public ICommand PlayAgainCommand { get; set; }

        public ICommand GoToStartCommand { get; set; }

        public BaseViewModel SelectedViewModel { get; set; }

        public EndOfGameViewModel()
        {
            highScoreDb.SetHighscore();
            highScoreDb.GetHighscores();
            EndScore = Global.EndScore.ToString();
            PlayAgainCommand = new PlayAgainCommand(this);
            GoToStartCommand = new GoToStartCommand(this);
        }
    }
}

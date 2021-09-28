using FiveCardPokerGame.Commands;
using FiveCardPokerGame.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FiveCardPokerGame.ViewModels
{
    public class HighScoreViewModel : BaseViewModel
    {
        public ICommand ReturnToStartCommand { get; set; }
        public BaseViewModel SelectedViewModel { get; set; }
        public HighScoreDb HighScoreDb { get; set; } = new HighScoreDb();
        public  ObservableCollection<Highscore> HighScoreListHard { get; set; }
        public  ObservableCollection<Highscore> HigscoreListMedium { get; set; }
        public  ObservableCollection<Highscore> HighscoreListEasy { get; set; }
        public HighScoreViewModel()
        {
            ReturnToStartCommand = new ReturnToStartCommand(this);
            HighscoreListEasy = HighScoreDb.GetEasyHighScore();
            HigscoreListMedium = HighScoreDb.GetMediumHighScore();
            HighScoreListHard = HighScoreDb.GetHardHighScore();


        }

    }
}

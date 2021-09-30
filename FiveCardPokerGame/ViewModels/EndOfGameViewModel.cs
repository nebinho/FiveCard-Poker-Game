using FiveCardPokerGame.Commands;
using FiveCardPokerGame.Data;
using FiveCardPokerGame.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FiveCardPokerGame.ViewModels
{
   public class EndOfGameViewModel : BaseViewModel
    {
        public string EndScore { get; set; }
        public string EndHand { get; set; }
        public static string ShowDifficulty { get { return HighScoreDb.Dif; } set { HighScoreDb.Dif = value; } }
        public HighScoreDb highScoreDb = new();
        public static ObservableCollection<Highscore> HighscoreList { get; set; }
        public ICommand PlayAgainCommand { get; set; }        
        public ICommand GoToStartCommand { get; set; }
        public BaseViewModel SelectedViewModel { get; set; }
        public ObservableCollection<CardView> FinalHand { get; set; }

        public EndOfGameViewModel()
        {
            FinalHand = Global.FinalHand;
            HighScoreDb.SetHighscore();
            HighScoreDb.GetHighscores();            
            EndScore = Global.EndScore.ToString();
            EndHand = Global.EndHand.ToString();
            PlayAgainCommand = new PlayAgainCommand(this);
            GoToStartCommand = new GoToStartCommand(this);
        }
    }
}

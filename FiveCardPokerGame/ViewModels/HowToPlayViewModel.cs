using FiveCardPokerGame.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FiveCardPokerGame.ViewModels
{
    public class HowToPlayViewModel : BaseViewModel
    {
        public HowToPlayViewModel()
        {
            RestartCommand = new RestartCommand(this);
        }
        public ICommand RestartCommand { get; set; }
        public BaseViewModel SelectedViewModel { get; set; }
        public string HowToPlay { get; set; } = "You play the game by first selecting what difficulty you want to play (Number of Draws). You also have to select which player you want to play as by selecting a existing player or creating a new one. Then you press 'Start Game'. When the game has started you have as many draws as you chose on the first page to get as many points as possible and land yourself on the leaderboard! You play by getting 5 random cards from the deck. You then drag the ones you want to change to the 'Throw here zone' and then click on the red card with the writing 'Draw Card' on it to get new cards!";
        public string Rules { get; set; } = "Pair = 5 points, Two Pairs = 10 Points, Three of a kind = 15 Points, Straight = 20 Points, Flush = 25 Points, Full House = 30 Points, Four of a kind = 35 Points, Straight flush = 40 Points, Royal Straight Flush = 50 Points!";
    }
}

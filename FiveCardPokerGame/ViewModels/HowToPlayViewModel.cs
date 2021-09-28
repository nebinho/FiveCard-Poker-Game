using FiveCardPokerGame.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        public ObservableCollection<string> Rules { get; set; } = new ObservableCollection<string>
        {
            "Pair = 5 points", "Two Pairs = 10 Points", "Three of a kind = 15 Points", "Straight = 20 Points", "Flush = 25 Points", "Full House = 30 Points", "Four of a kind = 35 Points", "Straight flush = 40 Points", "Royal Straight Flush = 50 Points!"
        };
        
        public ObservableCollection<string> HowToPlay { get; set; } = new ObservableCollection<string>
        {
            "You play the game by first selecting what difficulty you want to play (Number of Draws).",
            "You also have to select which player you want to play as by selecting a existing player or creating a new one.",
            "Then you press 'Start Game'.",
            "When the game starts your difficulty is determed by your choice on the starting page",
            "You play by getting 5 random cards from the deck",
            "You then drag the ones you want to change to the 'Throw here zone'", 
            "To draw new cards you click on the red card with the writing 'Draw Card' and you will be delt new cards.",
            "The point of the game is to get as good of a hand as possible."
        };
    }
}

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
        /// <summary>
        /// A Command for going back to the startview
        /// </summary>
        public ICommand RestartCommand { get; set; }
        public BaseViewModel SelectedViewModel { get; set; }
        /// <summary>
        /// A ObservableCollection made for displaying the values of diffrent combinations of cards.
        /// </summary>
        public ObservableCollection<string> Rules { get; set; } = new ObservableCollection<string>
        {
            "Pair (Two cards of one rank) = 5 points", "Two Pairs (Two cards of one rank and two cards of another rank) = 10 Points", 
            "Three of a kind (Three cards of one rank) = 15 Points", "Straight (Five cards of sequential rank, not all of same suit) = 20 Points", 
            "Flush (Five cards of the same suit, not all of sequential rank) = 25 Points", "Full House (Three cards of one rank and two cards of another rank) = 30 Points", 
            "Four of a kind (Four cards of one rank) = 35 Points", "Straight flush (Five cards of sequential rank and of the same suit) = 40 Points",
            "Royal Straight Flush (Five cards of the highest sequential rank (10 to A) and of the same suit) = 50 Points!"
        };
        /// <summary>
        /// Instruction for new players. Can be used in listboxes (we made this choice because you can select strings and make it easier to read)
        /// </summary>
        public ObservableCollection<string> HowToPlay { get; set; } = new ObservableCollection<string>
        {
            "'Five-Card-Poker' is a card game where the goal is to set a 'hand' of as good rank as possible",
            "A 'hand' consists of five cards", 
            "The player tries to set the 'hand' by swapping out cards - Throwing undesired and drawing new random cards",
            "The different 'hands' a player can set are ranked - See 'hand'-ranking below",
            "Each 'hand' gives the player a certain amount of points",
            "The player tries to set a 'hand' of highest score possible",
            "Before the player starts the game a desired difficulty must be selected", 
            "The difficulty is based on the number of draws the player can make (1, 2 or 3)",
            "You have to select which player you want to play as by selecting an existing player or creating a new one",
            "Then you press 'Start Game'",
            "The game starts by dealing 5 random cards from the deck",
            "Current points and 'hand'-rank are shown on top of the screen",
            "You then drag and drop the cards you want to swap out to the 'Throw here'-zone", 
            "To draw new cards from the deck you click on the upside down card with the writing 'Draw Card'",
            "If you´re satisified with the set hand and still have draws left you can click the 'Finish game' button",
            "When the game finishes the score of your 'hand' and place on the highscore-list are shown"
        };
    }
}

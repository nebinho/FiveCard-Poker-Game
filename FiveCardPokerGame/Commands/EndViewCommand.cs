using FiveCardPokerGame.Data;
using FiveCardPokerGame.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FiveCardPokerGame.Commands
{
    class EndViewCommand : ICommand
    {
        private readonly GameViewModel gameViewModel;

        public EndViewCommand(GameViewModel gameViewModel)
        {
            this.gameViewModel = gameViewModel;
        }

        public event EventHandler CanExecuteChanged
        {
            add { }
            remove { }
        }

        /// <summary>
        /// Can always execute
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public bool CanExecute(object parameter) => true;
        /// <summary>
        /// Takes the player to the ScoreScreen and saves the players score and sets it to a global property used in the score screen.
        /// </summary>
        /// <param name="parameter"></param>
        public void Execute(object parameter)
        {
            Global.PlayClickSound();
            Global.FinalHand = gameViewModel.DeckOfCards.CardViews;
            Global.EndScore = gameViewModel.DeckOfCards.PokerHands.Score;
            Global.EndHand = gameViewModel.DeckOfCards.PokerHands.CurrentPokerHand.ToString();
            gameViewModel.SelectedViewModel = new EndOfGameViewModel();
            GameViewModel.PlaySoundBasedOnScore();
        }


    }
}

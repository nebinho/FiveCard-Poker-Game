using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static FiveCardPokerGame.ViewModels.PlayerViewModel;

namespace FiveCardPokerGame.ViewModels
{
    public class GameViewModel : BaseViewModel
    {

        public PlayerViewModel P1 { get; set; } = new Player();

        public DeckOfCards Deck { get; set; } = new DeckOfCards();
        
        public GameViewModel()
        {
            
           
        }
    }
}

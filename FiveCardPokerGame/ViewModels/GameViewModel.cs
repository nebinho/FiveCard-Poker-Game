using FiveCardPokerGame.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using static FiveCardPokerGame.ViewModels.PlayerViewModel;

namespace FiveCardPokerGame.ViewModels
{
    public partial class GameViewModel : BaseViewModel
    {
        public PlayerViewModel P1 { get; set; } = new Player();

        public DeckOfCards DeckOfCards { get; set; } = new DeckOfCards();
        

        public ICommand RemoveCardCommand { get; set; }

        public ICommand DrawCardCommand { get; set; }

        public GameViewModel()
        {
            RemoveCardCommand = new RemoveCardCommand(this);
            DrawCardCommand = new DrawCardCommand(this);
        }     
    }
}

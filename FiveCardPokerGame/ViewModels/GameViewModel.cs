using FiveCardPokerGame.Commands;
using FiveCardPokerGame.Data;
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
        public DeckOfCards DeckOfCards { get; set; } = new DeckOfCards();
        public bool IsButtonEnabled { get; set; }
        public ICommand RemoveCardCommand { get; set; }
        public ICommand DrawCardCommand { get; set; }
        public string IsCardEnabled { get; set; }
        public int NumberOfDraws { get; set; }
        public Player SetPlayer { get; set; }
        public ICommand EndViewCommand { get; set; }
        public BaseViewModel SelectedViewModel { get; set; }

        public string CardEnabler()
        {
            if (DeckOfCards.IsHandFiveOrLess() == true)
            {
                return IsCardEnabled = "/Resources/ImagesCards/xCardBack.png";
            }
            else
            {
                return IsCardEnabled = "/Resources/ImagesCards/xCardBackDisabled.png";
            }
        }

        public GameViewModel()
        {            
            RemoveCardCommand = new RemoveCardCommand(this);
            DrawCardCommand = new DrawCardCommand(this);
            IsCardEnabled = CardEnabler();
            EndViewCommand = new EndViewCommand(this);            
        }
    }
}

using FiveCardPokerGame.Views;
using FiveCardPokerGame.Views.CardViews;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiveCardPokerGame.ViewModels
{
    public partial class PlayerViewModel : BaseViewModel
    {
        public ObservableCollection<CardOne> PresentedCard { get; set; } = new ObservableCollection<CardOne>();

       

        public PlayerViewModel()
        {
            CardOne cardOne = new CardOne();
            PresentedCard.Add(cardOne);
        }
       
    }
}

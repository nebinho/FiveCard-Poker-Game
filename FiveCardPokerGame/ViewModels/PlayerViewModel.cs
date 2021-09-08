using FiveCardPokerGame.Views;
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
        public ObservableCollection<CardView> PresentedCards { get; set; } = new ObservableCollection<CardView>();

        

        
        


        
    }
}

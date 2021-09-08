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

        /// <summary>
        /// Creates a list of five card views.
        /// </summary>
        private void FillHand()
        {
            for (int i = 0; i < 5; i++)
            {
                var piece = new CardView();
                PresentedCards.Add(piece);
            }
        }
        public PlayerViewModel()
        {
            FillHand();
        }
    }
}

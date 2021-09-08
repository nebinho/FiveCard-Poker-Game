using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiveCardPokerGame.ViewModels
{
    public class GameViewModel : BaseViewModel
    {
        private static readonly Random random = new Random();
        DeckOfCards deckOfCards = new DeckOfCards();
        ObservableCollection<Card> Hand { get; set; } = new ObservableCollection<Card>();
        
            
        private void GetFiveCards()
        {
            for (int i = 0; i < 5; i++)
            {
                var magicNumber = random.Next(52);

                Hand.Add(deckOfCards.Cards[magicNumber]);
            }
        }

        
        public GameViewModel()
        {
            GetFiveCards();
        }
    }
}

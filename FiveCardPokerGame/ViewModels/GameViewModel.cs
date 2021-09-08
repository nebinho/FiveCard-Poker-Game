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
        int NumberOfCards = 52;
            
        private int GetFiveCards()
        {
            
            for (int i = 0; i < 5; i++)
            {
                var magicNumber = random.Next(NumberOfCards);
                Hand.Add(deckOfCards.Cards[magicNumber]);
                deckOfCards.Cards.RemoveAt(magicNumber);
                NumberOfCards--;
                
            }
            return NumberOfCards;
        }
        private void ThrowCardsFromHand()
        {
            Hand.RemoveAt(1);
            Hand.RemoveAt(3);
            for (int i = 0; i < 2; i++)
            {
                var magicNumber = random.Next(NumberOfCards);
                Hand.Add(deckOfCards.Cards[magicNumber]);
                deckOfCards.Cards.RemoveAt(magicNumber);
                NumberOfCards--;

            }
        }
        

        
        public GameViewModel()
        {
            GetFiveCards();
            ThrowCardsFromHand();
        }
    }
}

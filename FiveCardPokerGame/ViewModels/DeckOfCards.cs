using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiveCardPokerGame.ViewModels
{
    public class DeckOfCards : Card
    {
        private static readonly Random random = new Random();

        public ObservableCollection<Card> Deck { get; set; } = new ObservableCollection<Card>();
        public ObservableCollection<Card> Hand { get; set; } = new ObservableCollection<Card>();
        

        public List<Card> Cards { get; set; }
        int NumberOfCards = 52;
        
        public DeckOfCards()
        {
            SetUpDeck();
            DealCards();
        }

        public void SetUpDeck()
        {
            foreach (Suit s in Enum.GetValues(typeof(Suit)))
            {
                foreach (Value v in Enum.GetValues(typeof(Value)))
                {
                    var newcard = new Card { Cardsuit = s, Cardvalue = v };
                    Deck.Add(newcard);
                }
            }
           
        }

        public void DealCards()
        {
            do
            {
                int randomNr = random.Next(NumberOfCards);
                var newCard = Deck[randomNr];
                Hand.Add(newCard);
                Deck.RemoveAt(randomNr);
                NumberOfCards--;
            } while (Hand.Count <= 4);
            this.Hand = new ObservableCollection<Card>(Hand.OrderBy(o => o.Cardvalue));
        }

    }
}


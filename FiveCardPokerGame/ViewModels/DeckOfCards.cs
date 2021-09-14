using FiveCardPokerGame.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiveCardPokerGame.ViewModels
{
    public class DeckOfCards : BaseViewModel
    {
        private static readonly Random random = new();

        public ObservableCollection<Card> Deck { get; set; } = new ObservableCollection<Card>();
        public ObservableCollection<Card> Hand { get; set; } = new ObservableCollection<Card>();
        public ObservableCollection<CardView> CardViews { get; set; } = new ObservableCollection<CardView>();
        
        public PokerHands pokerHands = new();
        public List<Card> Cards { get; set; }
        
        

        public DeckOfCards()
        {
            SetUpDeck();
            DealCards();
            CreateCardViews();
        }

        public void SetUpDeck()
        {
            foreach (Card.Suit s in Enum.GetValues(typeof(Card.Suit)))
            {
                foreach (Card.Value v in Enum.GetValues(typeof(Card.Value)))
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
                int randomNr = random.Next(Deck.Count);
                var newCard = Deck[randomNr];
                Hand.Add(newCard);
                Deck.RemoveAt(randomNr);
                
            } while (Hand.Count <= 4);
            this.Hand = new ObservableCollection<Card>(Hand.OrderBy(o => o.Cardvalue));
        }

        public void CreateCardViews()
        {
            foreach (Card card in Hand)
            {
                var cardView = new CardView();
                /*cardView.CurrentSuit = Card.Suit.Clubs*/;
                
                CardViews.Add(cardView);
            }
        }
        
    }
}


using FiveCardPokerGame.Data;
using FiveCardPokerGame.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FiveCardPokerGame.ViewModels
{
    public class GameEngine : BaseViewModel
    {
        private static readonly Random random = new();

        public ObservableCollection<Card> Deck { get; set; } = new ObservableCollection<Card>();
        public ObservableCollection<Card> Hand { get; set; } = new ObservableCollection<Card>();
        public ObservableCollection<CardView> CardViews { get; set; }
        public ObservableCollection<CardView> ThrownCards { get; set; } = new();
        public PokerHands PokerHands { get; set; } = new PokerHands();
        public List<Card> Cards { get; set; }
        public int SelectedDifficulty { get; set; }
        public int NumberOfThrows { get; set; }
        public int DrawsLeft { get; set; } = Global.Difficulty;

        public GameEngine()
        {
            SetUpDeck();
            DealCards();
            CreateCardViews();
            SelectedDifficulty = Global.Difficulty;
            
        }
        /// <summary>
        /// Sets up a deck of cards containing 52 cards.
        /// </summary>
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
        /// <summary>
        /// Deals cards from the deck randomly to a players hand. 5 cards total.
        /// </summary>
        public void DealCards()
        {
            do
            {
                int randomNr = random.Next(Deck.Count);
                var newCard = Deck[randomNr];
                Hand.Add(newCard);
                Deck.RemoveAt(randomNr);
                
            } while (Hand.Count <= 4);        
            EvaluateHand.CheckPokerHand(Hand, PokerHands);
            IsHandFiveOrLess();
            NumberOfThrows++;
        }
        /// <summary>
        /// Creates a view for each card in hand that displays the cards.
        /// </summary>
        public void CreateCardViews()
        {
            CardViews = new();
            foreach (Card card in Hand)
            {
                var cardView = new CardView();
                cardView.GetCard = card;

                CardViews.Add(cardView);
                
            }
        }
        /// <summary>
        /// Removes one card from the Hand when a player throws a card.
        /// </summary>
        /// <param name="cardViewNumber"></param>
        public void ThrowCard(int cardViewNumber)
        {
            Hand.RemoveAt(cardViewNumber);
            IsHandFiveOrLess();
        }
        /// <summary>
        /// Checks if there are fice cards or less on hand.
        /// </summary>
        /// <returns></returns>
        public bool IsHandFiveOrLess()
        {
            if (Hand.Count < 5)
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// Method to see if the player can continue to draw cards.
        /// Based on difficulty from the StartPage.
        /// </summary>
        /// <returns></returns>
        public bool CanDrawNewCard()
        {
            if (NumberOfThrows >= SelectedDifficulty+1)
            {
                
                return false;
            }
            return true;
        }
        /// <summary>
        /// Used for recreating a thrown card.
        /// </summary>
        /// <param name="cardView"></param>
        /// <returns></returns>
        public Card Card(CardView cardView)
        {
            var suit = cardView.GetCard.Cardsuit;
            var value = cardView.GetCard.Cardvalue;

            Card card = new Card
            {
                Cardsuit = suit,
                Cardvalue = value
            };
            return card;
        }
        
    }
}


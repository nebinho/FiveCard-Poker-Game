using FiveCardPokerGame.Data;
using FiveCardPokerGame.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static FiveCardPokerGame.ViewModels.PlayerViewModel;

namespace FiveCardPokerGame.ViewModels
{
    public class DeckOfCards : BaseViewModel
    {
        private static readonly Random random = new();

        public ObservableCollection<Card> Deck { get; set; } = new ObservableCollection<Card>();
        public ObservableCollection<Card> Hand { get; set; } = new ObservableCollection<Card>();
        public ObservableCollection<CardView> CardViews { get; set; }
        public ObservableCollection<CardView> ThrownCards { get; set; } = new();
        public Player Player { get; set; } = new Player();

        public PokerHands PokerHands { get; set; } = new PokerHands();
        public List<Card> Cards { get; set; }        
        public int NumberOfThrows { get; set; } //private int numberOfThrows; //Int för att räkna antal byten
        public PlayerDb playerDb = new PlayerDb();
        private GameViewModel gameViewModel;

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
            EvaluateHand.CheckPokerHand(Hand, PokerHands);
            //Player.HighScore = PokerHands.Score;
            IsHandFiveOrLess();
            NumberOfThrows++; //Varje gång man får nya kort räknas det som ett byte
            //playerDb.CreatePlayer(Player);
            //playerDb.UpdateHighScore(Player);
            //playerDb.GetPlayers();

        }        

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

        public void ThrowCard(int cardViewNumber)
        {
            Hand.RemoveAt(cardViewNumber);
            IsHandFiveOrLess();            
        }

        public bool IsHandFiveOrLess()
        {          
            if (Hand.Count < 5)
            {
                
                return true;
            }
            
            return false;
        }

        public bool CanDrawNewCard() //Metod för att kolla så man inte får för många byten
        {
            if (NumberOfThrows >= 4)
            {
                return false;      
            }
            return true;
        }

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


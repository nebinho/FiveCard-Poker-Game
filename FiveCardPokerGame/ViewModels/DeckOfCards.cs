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
        
        public PokerHands pokerHands = new PokerHands();
        public List<Card> Cards { get; set; }
        
        

        public DeckOfCards()
        {
            SetUpDeck();
            DealCards();
            SetScore();
            ThrowCard();
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

            //CardGame.GetCardProperty
            
            EvaluateHand.CheckPokerHand(Hand, pokerHands);          

        }
        

        public void CreateCardViews()
        {
            foreach (Card card in Hand)
            {
                var cardView = new CardView();
                cardView.GetCard = card;

                CardViews.Add(cardView);
            }
        }



        public void ThrowCard()
        {
            int throwC = 1;
            this.Hand.RemoveAt(throwC);
            DealCards();

        }

        public void SetScore()
        {
            var gameView = new GameView();

            gameView.SetScore = pokerHands.Score.ToString();
        }

    }
}


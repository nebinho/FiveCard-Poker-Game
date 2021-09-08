using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiveCardPokerGame.ViewModels
{
    public class DeckOfCards
    {
        private static readonly Random random = new Random();
        public List<Card> Cards { get; set; }

        public DeckOfCards()
        {
            FillDeckWithCards();
        }

        public Card GetRandomCard()
        {
            if (Cards.Count <= 0)
                return null;

            int randomIndex = random.Next(Cards.Count);
            Card card = Cards[randomIndex];
            Cards.RemoveAt(randomIndex);
            return card;
        }

        #region Private method
        private void FillDeckWithCards()
        {
            Cards = new List<Card>();
            for (int i = 1; i < 5; i++) //4 suits
            {
                for (int j = 2; j < 15; j++) //13 cards per suit (total 52 (4*13))
                {
                    Card card = new Card(); //creates new card

                    //set suit
                    if (i == 1)
                    {
                        card.Suit = "Spader";
                    }
                    else if (i == 2)
                    {
                        card.Suit = "Klöver";
                    }
                    else if (i == 3)
                    {
                        card.Suit = "Hjärter";
                    }
                    else if (i == 4)
                    {
                        card.Suit = "Ruter";
                    }
                    // set value
                    card.Rank = j;
                    //set type
                    if (j == 14)
                    {
                        card.Type = "Ess";
                    }
                    else if (j == 13)
                    {
                        card.Type = "Kung";
                    }
                    else if (j == 12)
                    {
                        card.Type = "Dam";
                    }
                    else if (j == 11)
                    {
                        card.Type = "Knekt";
                    }
                    else if (j <= 10 && j >= 2)
                    {
                        card.Type = j.ToString();
                    }
                    //Add to deck
                    Cards.Add(card);
                }
            }

        }
        #endregion

    }
}

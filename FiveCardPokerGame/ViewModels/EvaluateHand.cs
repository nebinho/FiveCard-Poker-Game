using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiveCardPokerGame.ViewModels
{
    public class EvaluateHand : DeckOfCards
    {

        public EvaluateHand()
        {

        }

        public static bool IsPair(ObservableCollection<Card> hand)
        {

            //hand.OrderBy(item => (int)item.Cardvalue).ToArray();

            bool lowPair = (int)hand[0].Cardvalue == (int)hand[1].Cardvalue;
            bool lowerMiddlePair = (int)hand[1].Cardvalue == (int)hand[2].Cardvalue;
            bool higherMiddlePair = (int)hand[2].Cardvalue == (int)hand[3].Cardvalue;
            bool higherPair = (int)hand[3].Cardvalue == (int)hand[4].Cardvalue;

            return lowPair || lowerMiddlePair || higherMiddlePair || higherPair;
            
        }

        

    }
}

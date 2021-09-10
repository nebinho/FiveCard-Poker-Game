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
        public static bool CheckPokerHand(ObservableCollection<Card> hand, PokerHands pokerHands) // om denna alltid kollar först den metoden som är värd mest poäng så kanske det funkar?
        {
            
            if (IsFlush(hand))
            {
                pokerHands.pokerHand = PokerHands.PokerHand.Flush;
                return true;
            }
            if (IsStraight(hand))
            {
                pokerHands.pokerHand = PokerHands.PokerHand.Straight;
                return true;
            }
            if (IsThree(hand))
            {
                pokerHands.pokerHand = PokerHands.PokerHand.ThreeOfAKind;
                return true;
            }
            if (IsPair(hand))
            {
                pokerHands.pokerHand = PokerHands.PokerHand.Pair;
                return true;
            }
            return false;


        }

        public static bool IsPair(ObservableCollection<Card> hand)
        {

            
            bool pair = (int)hand[0].Cardvalue == (int)hand[1].Cardvalue || (int)hand[1].Cardvalue == (int)hand[2].Cardvalue || 
                        (int)hand[2].Cardvalue == (int)hand[3].Cardvalue || (int)hand[3].Cardvalue == (int)hand[4].Cardvalue;
            return pair;

            //hand.OrderBy(item => (int)item.Cardvalue).ToArray();
            //bool lowPair = (int)hand[0].Cardvalue == (int)hand[1].Cardvalue;
            //bool lowerMiddlePair = (int)hand[1].Cardvalue == (int)hand[2].Cardvalue;
            //bool higherMiddlePair = (int)hand[2].Cardvalue == (int)hand[3].Cardvalue;
            //bool higherPair = (int)hand[3].Cardvalue == (int)hand[4].Cardvalue;

            //return lowPair || lowerMiddlePair || higherMiddlePair || higherPair;

        }
        public static bool IsThree(ObservableCollection<Card> hand) // denna funkar inte om man får in en kåk på tex, men eftersom kåk är värd mer så bör den metoden köras innan
        {
            bool three = (int)hand[0].Cardvalue == (int)hand[1].Cardvalue &&
                        (int)hand[1].Cardvalue == (int)hand[2].Cardvalue;
            return three;
        }
        public static bool IsStraight(ObservableCollection<Card> hand)
        {
           
            bool straight = (int)hand[0].Cardvalue % 13 == (int)hand[1].Cardvalue % 13 - 1 && // ser ut att funka "The remainder operator % computes the remainder after dividing its left-hand operand by its right-hand operand."
                            (int)hand[1].Cardvalue % 13 == (int)hand[2].Cardvalue % 13 - 1 && // möjlgitvis en loop annars? 
                            (int)hand[2].Cardvalue % 13 == (int)hand[3].Cardvalue % 13 - 1 &&
                            (int)hand[3].Cardvalue % 13 == (int)hand[4].Cardvalue % 13 - 1;
            return straight;
            //bool straight = (int)hand[0].Cardvalue++ == (int)hand[1].Cardvalue;
            //return straight;
        }
        public static bool IsFlush(ObservableCollection<Card> hand)
        {
            hand = new ObservableCollection<Card>(hand.OrderBy(o => o.Cardsuit));
            bool asd = (int)hand[0].Cardsuit == (int)hand[1].Cardsuit && (int)hand[1].Cardsuit == (int)hand[2].Cardsuit &&
                        (int)hand[2].Cardsuit == (int)hand[3].Cardsuit && (int)hand[3].Cardsuit == (int)hand[4].Cardsuit &&
                        (int)hand[4].Cardsuit == (int)hand[0].Cardsuit;
            return asd;
        }

        

    }
}

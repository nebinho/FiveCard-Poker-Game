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

            if (IsFlush(hand) && IsStraight(hand)) // kollar om man fått färg och stege och sedan om stegen är tio till ess = Royal Flush
            {
                if (IsRoyalFlush(hand))
                {
                    pokerHands.pokerHand = PokerHands.PokerHand.RoyalFlush;
                    return true;
                }
            }
            if (IsFlush(hand) && IsStraight(hand)) // kollar om man har fått färg och stege och då får man färgstege
            {
                pokerHands.pokerHand = PokerHands.PokerHand.StraightFlush;
                return true;
            }                  
            if (IsFourOfAKind(hand))
            {
                pokerHands.pokerHand = PokerHands.PokerHand.FourOfAKind;
                return true;
            }
            if (IsPair(hand) && IsThree(hand)) // kollar om man fått kåk
            {
                pokerHands.pokerHand = PokerHands.PokerHand.FullHouse;
                return true;
            }
            if (IsFlush(hand)) // kollar om man fått färg
            {
                pokerHands.pokerHand = PokerHands.PokerHand.Flush;
                return true;
            }
            if (IsStraight(hand)) // kollar om man fått stege
            {
                pokerHands.pokerHand = PokerHands.PokerHand.Straight;
                return true;
            }
            if (IsThree(hand)) // kollar om man fått tretal
            {
                pokerHands.pokerHand = PokerHands.PokerHand.ThreeOfAKind;
                return true;
            }
            if (IsTwoPair(hand))
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
            hand = new ObservableCollection<Card>(hand.OrderBy(o => o.Cardvalue));
            bool pair = (int)hand[0].Cardvalue == (int)hand[1].Cardvalue || (int)hand[1].Cardvalue == (int)hand[2].Cardvalue ||
                        (int)hand[2].Cardvalue == (int)hand[3].Cardvalue || (int)hand[3].Cardvalue == (int)hand[4].Cardvalue;

            return pair;
        }

        public static bool IsTwoPair(ObservableCollection<Card> hand)
        {
            hand = new ObservableCollection<Card>(hand.OrderBy(o => o.Cardvalue));
            bool twoPair = (int)hand[0].Cardvalue == (int)hand[1].Cardvalue && (int)hand[2].Cardvalue == (int)hand[3].Cardvalue ||
                        (int)hand[0].Cardvalue == (int)hand[1].Cardvalue && (int)hand[3].Cardvalue == (int)hand[4].Cardvalue ||
                        (int)hand[1].Cardvalue == (int)hand[2].Cardvalue && (int)hand[3].Cardvalue == (int)hand[4].Cardvalue;

            return twoPair;
        }

        public static bool IsThree(ObservableCollection<Card> hand)
        {
            hand = new ObservableCollection<Card>(hand.OrderBy(o => o.Cardvalue));
            bool three = (int)hand[0].Cardvalue == (int)hand[1].Cardvalue &&
                        (int)hand[1].Cardvalue == (int)hand[2].Cardvalue ||

                        (int)hand[1].Cardvalue == (int)hand[2].Cardvalue &&
                        (int)hand[2].Cardvalue == (int)hand[3].Cardvalue ||

                        (int)hand[2].Cardvalue == (int)hand[3].Cardvalue &&
                        (int)hand[3].Cardvalue == (int)hand[4].Cardvalue;

            return three;
        }

        public static bool IsStraight(ObservableCollection<Card> hand) // kolla med ESS SEN
        {
            hand = new ObservableCollection<Card>(hand.OrderBy(o => o.Cardvalue));
            bool straight = (int)hand[0].Cardvalue % 13 == (int)hand[1].Cardvalue % 13 - 1 && // ser ut att funka "The remainder operator % computes the remainder after dividing its left-hand operand by its right-hand operand."
                            (int)hand[1].Cardvalue % 13 == (int)hand[2].Cardvalue % 13 - 1 && // möjlgitvis en loop annars? 
                            (int)hand[2].Cardvalue % 13 == (int)hand[3].Cardvalue % 13 - 1 &&
                            (int)hand[3].Cardvalue % 13 == (int)hand[4].Cardvalue % 13 - 1;

            return straight;
        }

        public static bool IsFlush(ObservableCollection<Card> hand)
        {
            bool asd = (int)hand[0].Cardsuit == (int)hand[1].Cardsuit && (int)hand[1].Cardsuit == (int)hand[2].Cardsuit &&
                        (int)hand[2].Cardsuit == (int)hand[3].Cardsuit && (int)hand[3].Cardsuit == (int)hand[4].Cardsuit &&
                        (int)hand[4].Cardsuit == (int)hand[0].Cardsuit;

            return asd;
        }

        public static bool IsRoyalFlush(ObservableCollection<Card> hand)
        {
            hand = new ObservableCollection<Card>(hand.OrderBy(o => o.Cardvalue));
            bool aaa = hand[0].Cardvalue == Value.Ten && hand[1].Cardvalue == Value.Jack && hand[2].Cardvalue == Value.Queen && hand[3].Cardvalue == Value.King && hand[4].Cardvalue == Value.Ace;

            return aaa;
        }

        public static bool IsFourOfAKind(ObservableCollection<Card> hand)
        {
            hand = new ObservableCollection<Card>(hand.OrderBy(o => o.Cardvalue));
            bool fourOfAKind = (int)hand[0].Cardvalue == (int)hand[1].Cardvalue && (int)hand[1].Cardvalue == (int)hand[2].Cardvalue &&
                        (int)hand[2].Cardvalue == (int)hand[3].Cardvalue || (int)hand[1].Cardvalue == (int)hand[2].Cardvalue &&
                        (int)hand[2].Cardvalue == (int)hand[3].Cardvalue &&
                        (int)hand[3].Cardvalue == (int)hand[4].Cardvalue;

            return fourOfAKind;
        }
    }
}
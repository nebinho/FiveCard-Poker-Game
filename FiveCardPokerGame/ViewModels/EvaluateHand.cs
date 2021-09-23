using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static FiveCardPokerGame.ViewModels.Card;

namespace FiveCardPokerGame.ViewModels
{
    public class EvaluateHand : BaseViewModel
    {
        public static bool CheckPokerHand(ObservableCollection<Card> hand, PokerHands pokerHands)
        {

            if (IsFlush(hand) && IsStraight(hand))
            {
                if (IsRoyalFlush(hand))
                {
                    pokerHands.pokerHand = PokerHands.PokerHand.RoyalFlush;
                    pokerHands.Score = 50;
                    return true;
                }
            }
            if (IsFlush(hand) && IsStraight(hand))
            {
                pokerHands.pokerHand = PokerHands.PokerHand.StraightFlush;
                pokerHands.Score = 40;
                return true;
            }                  
            if (IsFourOfAKind(hand))
            {
                pokerHands.pokerHand = PokerHands.PokerHand.FourOfAKind;
                pokerHands.Score = 35;
                return true;
            }
            if (IsFullHouse(hand))
            {
                pokerHands.pokerHand = PokerHands.PokerHand.FullHouse;
                pokerHands.Score = 30;
                return true;
            }
            if (IsFlush(hand))
            {
                pokerHands.pokerHand = PokerHands.PokerHand.Flush;
                pokerHands.Score = 25;
                return true;
            }
            if (IsStraight(hand))
            {
                pokerHands.pokerHand = PokerHands.PokerHand.Straight;
                pokerHands.Score = 20;
                return true;
            }
            if (IsThree(hand))
            {
                pokerHands.pokerHand = PokerHands.PokerHand.ThreeOfAKind;
                pokerHands.Score = 15;
                return true;
            }
            if (IsTwoPair(hand))
            {
                pokerHands.pokerHand = PokerHands.PokerHand.TwoPair;
                pokerHands.Score = 10;
                return true;
            }
            if (IsPair(hand))
            {              
                pokerHands.pokerHand = PokerHands.PokerHand.Pair;
                pokerHands.Score = 5;
                return true;
            }
            pokerHands.pokerHand = PokerHands.PokerHand.Nothing;
            pokerHands.Score = 0;
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
            bool threeOfAKind = (int)hand[0].Cardvalue == (int)hand[1].Cardvalue &&
                        (int)hand[1].Cardvalue == (int)hand[2].Cardvalue ||

                        (int)hand[1].Cardvalue == (int)hand[2].Cardvalue &&
                        (int)hand[2].Cardvalue == (int)hand[3].Cardvalue ||

                        (int)hand[2].Cardvalue == (int)hand[3].Cardvalue &&
                        (int)hand[3].Cardvalue == (int)hand[4].Cardvalue;

            return threeOfAKind;
        }

        public static bool IsStraight(ObservableCollection<Card> hand)
        {
            hand = new ObservableCollection<Card>(hand.OrderBy(o => o.Cardvalue));
            bool straight = (int)hand[0].Cardvalue % 13 == (int)hand[1].Cardvalue % 13 - 1 &&
                            (int)hand[1].Cardvalue % 13 == (int)hand[2].Cardvalue % 13 - 1 && 
                            (int)hand[2].Cardvalue % 13 == (int)hand[3].Cardvalue % 13 - 1 &&
                            (int)hand[3].Cardvalue % 13 == (int)hand[4].Cardvalue % 13 - 1;

            return straight;
        }

        public static bool IsFlush(ObservableCollection<Card> hand)
        {
            bool flush = (int)hand[0].Cardsuit == (int)hand[1].Cardsuit && (int)hand[1].Cardsuit == (int)hand[2].Cardsuit &&
                        (int)hand[2].Cardsuit == (int)hand[3].Cardsuit && (int)hand[3].Cardsuit == (int)hand[4].Cardsuit &&
                        (int)hand[4].Cardsuit == (int)hand[0].Cardsuit;

            return flush;
        }
        public static bool IsFullHouse(ObservableCollection<Card> hand)
        {
            hand = new ObservableCollection<Card>(hand.OrderBy(o => o.Cardvalue));
            bool fullHouse = (int)hand[0].Cardvalue == (int)hand[1].Cardvalue &&
                        (int)hand[1].Cardvalue == (int)hand[2].Cardvalue &&
                        (int)hand[3].Cardvalue == (int)hand[4].Cardvalue ||

                        (int)hand[0].Cardvalue == (int)hand[1].Cardvalue &&
                        (int)hand[2].Cardvalue == (int)hand[3].Cardvalue &&
                        (int)hand[3].Cardvalue == (int)hand[4].Cardvalue;

            return fullHouse;
        }
        public static bool IsRoyalFlush(ObservableCollection<Card> hand)
        {
            hand = new ObservableCollection<Card>(hand.OrderBy(o => o.Cardvalue));
            bool royalFlush = hand[0].Cardvalue == Value.Ten && hand[1].Cardvalue == Value.Jack && hand[2].Cardvalue == Value.Queen && hand[3].Cardvalue == Value.King && hand[4].Cardvalue == Value.Ace;

            return royalFlush;
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
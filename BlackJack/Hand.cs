using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace BlackJack
{
    public enum PlayerType { Player, Dealer }
    public class Hand
    {
        private Queue<int> seeds;
        private CardDeck cardDeck;
        public List<Card> DealerCards;
        public List<Card> PlayerCards;
        public int HandNumber { get;set;}
        public Image CardBack
        {
            get 
            {
                return cardDeck.back;
            }
        }

        public Hand()
        {
            cardDeck = new CardDeck();
            char[] delimiters = new char[] { '\r', '\n','\t',' ' };
            seeds = new Queue<int>(Properties.Settings.Default.Hands.Split(delimiters, StringSplitOptions.RemoveEmptyEntries).Select<string, int>(a => Convert.ToInt32(a)));
            Next();
        }
        
        public void Next()
        {
            HandNumber = seeds.Dequeue();
            cardDeck.Shuffle(HandNumber);
            DealerCards = new List<Card>();
            PlayerCards = new List<Card>();
            for(int i = 0;i<2;i++)
            {
                DealerCards.Add(cardDeck.Next);
                PlayerCards.Add(cardDeck.Next);
            }
        }
        public void Hit(PlayerType pt)
        {
            Card c = cardDeck.Next;
            if (pt == PlayerType.Player)
            {
                PlayerCards.Add(c);
            }
            else
            {
                DealerCards.Add(c);
            }         
        }
        public int? PlayerHandValue { get { return HandValueStarter(PlayerCards); } }
        public int? DealerHandValue { get { return HandValueStarter(DealerCards); } }
        public bool BlackJack
        {
            get
            {
                return ((PlayerHandValue == 21) || (DealerHandValue == 21));         
            }
        }
        private int? HandValueStarter(List<Card> input)
        {
            int valueWithOutAces = input.Where(c => c.values.Count == 1).Sum(c => c.values[0]);
            int numberOfAce = input.Count(c => c.values.Count == 2);
            return HandValueHelper(numberOfAce, valueWithOutAces);
        }
        private int? HandValueHelper(int aces, int value)
        {
            if (aces == 0)
            {
                if (value > 21)
                {
                    return null;
                }
                else
                {
                    return value;
                }
            }
            if ((aces - 1 + 11 + value) <= 21)//aces -1 being the min value the rest of the aces can take
            {
                return HandValueHelper(aces - 1, value + 11);
            }
            else
            {
                return HandValueHelper(aces - 1, value + 1);
            }
        }
        public PlayerType? GetWinner()
        {
            int? player = PlayerHandValue;
            int? dealer = DealerHandValue;
            if (player == null)
            {
                return PlayerType.Dealer;
            }
            if (dealer == null)
            {
                return PlayerType.Player;
            }
            if (player == dealer)
            {
                return null;
            }
            if (player > dealer)
            {
                return PlayerType.Player;
            }
            else
            {
                return PlayerType.Dealer;
            }
        }
    }
}

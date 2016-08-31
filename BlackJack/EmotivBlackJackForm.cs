using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Logger;
using System.Diagnostics;

namespace BlackJack
{
    public partial class EmotivBlackJackForm : Form
    {
        List<PictureBox> DealerCardsImages;
        List<PictureBox> PlayerCardsImages;
        Timer timer;
        Hand hand = new Hand();
        byte UserID;
        public EmotivBlackJackForm()
        {
            if (MessageBox.Show("Debug Mode", "Debug Mode", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                UserID = 1;
            }
            else
            {
                UserID = Sender.GetUserID();
            }

            Process.Start(Properties.Settings.Default.MindLogger, UserID.ToString());
           
            InitializeComponent();
            DealerCardsImages = new List<PictureBox> { Dealer1, Dealer2, Dealer3, Dealer4, Dealer5 };
            PlayerCardsImages = new List<PictureBox> { Player1, Player2, Player3, Player4, Player5 };
            timer = new Timer();
            timer.Interval = (int)TimeSpan.FromSeconds(Properties.Settings.Default.Delay).TotalMilliseconds;
            timer.Tick += new EventHandler(DealerTurn);
            timer.Enabled = false;
            Deal();
        }
        private void UpdateCards(PlayerType player,bool showAll)
        {
            List<PictureBox> images;
            List<Card> cards;
            if (player == PlayerType.Player)
            {
                images = PlayerCardsImages;
                cards = hand.PlayerCards;
            }
            else
            {
                images = DealerCardsImages;
                cards = hand.DealerCards;
            }
            int i = 0;
            int size = cards.Count;
            for (; i < 5; i++)
            {
                if (i < size)
                {
                    images[i].Image = cards[i].image;
                }
                else
                {
                    images[i].Image = null;
                }
            }
            if (!showAll)
            {
                DealerCardsImages[1].Image = hand.CardBack;
            }
            StatusText.Text = hand.PlayerHandValue.ToString();
        }
        private void Deal()
        {
            Sender.StoreEvent(UserID, "Dealing");
            Hitbutton.Visible = StandButton.Visible = true;
            NextButton.Visible = false; 
            UpdateCards(PlayerType.Player,true);
            
            HandNumber.Text = hand.HandNumber.ToString();
            UpdateCards(PlayerType.Dealer, false);
            if (hand.BlackJack)
            {
                TakeCareOfWinner(hand.GetWinner());
            }
        }
        private void Hitbutton_Click(object sender, EventArgs e)
        {
            hand.Hit(PlayerType.Player);
            Sender.StoreEvent(UserID,"PlayerHit");
            UpdateCards(PlayerType.Player, true);
            if (hand.PlayerHandValue == null)
            {
                TakeCareOfWinner(PlayerType.Dealer);
            }
        }

        private void NextButton_Click(object sender, EventArgs e)
        {
            hand.Next();
            Deal();
        }

        private void TakeCareOfWinner(PlayerType? winner)
        {
            UpdateCards(PlayerType.Dealer, true);
            switch(winner)
            {         
                case null:
                    StatusText.Text = "Push no one wins";
                    Sender.StoreEvent(UserID, "Tie");
                    break;                  
                case PlayerType.Player:
                    StatusText.Text = "Player Won";
                    Sender.StoreEvent(UserID, "PlayerWon");
                    break;
                case PlayerType.Dealer:
                    StatusText.Text = "Dealer Won";
                    Sender.StoreEvent(UserID, "DealerWon");
                    break;
            }     
            NextButton.Visible = true;
            Hitbutton.Visible = StandButton.Visible = false;
        }

        private void StandButton_Click(object sender, EventArgs e)
        {
            Hitbutton.Visible = StandButton.Visible = false;
            UpdateCards(PlayerType.Dealer, true);
            timer.Enabled = true;
        }
        private void DealerTurn(object sender, EventArgs e)
        {
            if (hand.DealerHandValue < 17)
            {
                hand.Hit(PlayerType.Dealer);
                UpdateCards(PlayerType.Dealer, true);
                Sender.StoreEvent(UserID, "DealerHit");
                if (hand.DealerHandValue > 17)
                {
                    DealerTurn(sender,e);
                }
            }
            else
            {
                UpdateCards(PlayerType.Dealer, true);
                timer.Enabled = false;
                TakeCareOfWinner(hand.GetWinner());       
            }
           
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Feagin_Asg3_Poker
{
    public partial class FormMain : Form
    {
        Deck deck;
        Hand playerHand = new Hand();


        int totalCredits = 0;

        private void showCards()
        {
            pictureBox1.Image = imageListCards.Images[39];
            pictureBox2.Image = imageListCards.Images[43];
            pictureBox4.Image = imageListCards.Images[47];
            pictureBox3.Image = imageListCards.Images[51];
            pictureBox5.Image = imageListCards.Images[3];
        }



        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            totalCredits = 100;
            labelTotalCredits.Text = totalCredits.ToString();
            showCards();
        }

        private void buttonDraw_Click(object sender, EventArgs e)
        {
          
            
        }

        private void buttonBet_Click(object sender, EventArgs e)
        {
            // Create a deck using cards in (imageListCards)
            deck = new Deck(imageListCards);

            // Create Card objects and assign values from cards in deck
            Card card1 = deck.drawCard();
            Card card2 = deck.drawCard();
            Card card3 = deck.drawCard();
            Card card4 = deck.drawCard();
            Card card5 = deck.drawCard();

            pictureBox1.Image = card1.FrontImage;
            pictureBox2.Image = card2.FrontImage;
            pictureBox4.Image = card3.FrontImage;
            pictureBox3.Image = card4.FrontImage;
            pictureBox5.Image = card5.FrontImage;

            // Add cards to player Hand
            playerHand.addCard(card1);
            playerHand.addCard(card2);
            playerHand.addCard(card3);
            playerHand.addCard(card4);
            playerHand.addCard(card5);

            // Disable bet button
            buttonBet.Enabled = false;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }
    }
}

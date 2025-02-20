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
        HandDisplay HandDisplay;
        List<PictureBox> listPictureBoxes = new List<PictureBox>();

        int totalCredits = 0;

        

        private void showCards()
        {
            pictureBox1.Image = imageListCards.Images[52];
            pictureBox2.Image = imageListCards.Images[52];
            pictureBox4.Image = imageListCards.Images[52];
            pictureBox3.Image = imageListCards.Images[52];
            pictureBox5.Image = imageListCards.Images[52];
        }



        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            showCards();

            listPictureBoxes.Clear();
            listPictureBoxes.Add(pictureBox1);
            listPictureBoxes.Add(pictureBox2);
            listPictureBoxes.Add(pictureBox3);
            listPictureBoxes.Add(pictureBox4);
            listPictureBoxes.Add(pictureBox5);
           
            totalCredits = 100;
            labelTotalCredits.Text = totalCredits.ToString();
            
        }

        private void buttonDraw_Click(object sender, EventArgs e)
        {
          
            
        }

        private void buttonBet_Click(object sender, EventArgs e)
        {
            // Create a deck using cards in (imageListCards)
            deck = new Deck(imageListCards);

            // Create Display object
            HandDisplay displayHand = new HandDisplay(listPictureBoxes);

            // Create Card objects and assign values from cards in deck
            Card card1 = deck.drawCard();
            Card card2 = deck.drawCard();
            Card card3 = deck.drawCard();
            Card card4 = deck.drawCard();
            Card card5 = deck.drawCard();

            // Add cards to player Hand
            playerHand.addCard(card1);
            playerHand.addCard(card2);
            playerHand.addCard(card3);
            playerHand.addCard(card4);
            playerHand.addCard(card5);

            // Display the players hand
            displayHand.showHand(playerHand);
            
            // Disable bet button
            buttonBet.Enabled = false;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            pictureBox1.Enabled = false;
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

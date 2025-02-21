using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace Feagin_Asg3_Poker
{
    public partial class FormMain : Form
    {
        Deck deck;
        Hand playerHand = new Hand();
        HandDisplay HandDisplay;
        List<PictureBox> listPictureBoxes = new List<PictureBox>();
        

        int totalCredits = 0;


        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            showCards();
            deck = new Deck(imageListCards);
            //HandDisplay displayHand = new HandDisplay(listPictureBoxes);

            listPictureBoxes.Clear();
            listPictureBoxes.Add(pictureBox1);
            listPictureBoxes.Add(pictureBox2);
            listPictureBoxes.Add(pictureBox3);
            listPictureBoxes.Add(pictureBox4);
            listPictureBoxes.Add(pictureBox5);
           
            totalCredits = 100;
            labelTotalCredits.Text = totalCredits.ToString();

            // disable draw button
            buttonDraw.Enabled = false;
            
        }

        private void showCards()
        {
            pictureBox1.Image = imageListCards.Images[52];
            pictureBox2.Image = imageListCards.Images[52];
            pictureBox4.Image = imageListCards.Images[52];
            pictureBox3.Image = imageListCards.Images[52];
            pictureBox5.Image = imageListCards.Images[52];
        }

        private void drawNewCards()
        {
            if (pictureBox1.Enabled)
            {
                Card card1 = deck.drawCard();
                playerHand.replaceCard(0, card1);

            }
            if (pictureBox2.Enabled)
            {
                Card card2 = deck.drawCard();
                playerHand.replaceCard(1, card2);
            }
            if (pictureBox3.Enabled)
            {
                Card card3 = deck.drawCard();
                playerHand.replaceCard(2, card3);
            }
            if (pictureBox4.Enabled)
            {
                Card card4 = deck.drawCard();
                playerHand.replaceCard(3, card4);
            }
            if (pictureBox5.Enabled)
            {
                Card card5 = deck.drawCard();
                playerHand.replaceCard(4, card5);
            }
        }

        private void enablePictureBoxes()
        {
            pictureBox1.Enabled = true;
            pictureBox2.Enabled = true;
            pictureBox3.Enabled = true;
            pictureBox4.Enabled = true;
            pictureBox5.Enabled = true;
        }

        private int makeBet(int totalCredits)
        {
            if (totalCredits > 0)
            {
                totalCredits -= (int)numericUpDown.Value;
            }
            else if (totalCredits == 0)
            {
                MessageBox.Show("You have 0 credits!! you must start again.");
            }

            return totalCredits;
        }

        private void buttonDraw_Click(object sender, EventArgs e)
        {
            HandDisplay displayHand = new HandDisplay(listPictureBoxes);

            drawNewCards();

            //Show the players hand
            displayHand.showHand(playerHand);

            //clear the players hand
            playerHand.clearHand();

            deck.shuffle();

            enablePictureBoxes();

            // Disable bet button enable draw button
            buttonBet.Enabled = true;
            buttonDraw.Enabled = false;

        }

        private void buttonBet_Click(object sender, EventArgs e)
        {
            // Create a deck using cards in (imageListCards)
            //deck = new Deck(imageListCards);

            // Create Display object
            HandDisplay displayHand = new HandDisplay(listPictureBoxes);

            totalCredits = makeBet(totalCredits);
            labelTotalCredits.Text = totalCredits.ToString();

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
            
            // Disable bet button enable draw button
            buttonBet.Enabled = false;
            buttonDraw.Enabled = true;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            pictureBox1.Enabled = false;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            pictureBox2.Enabled = false;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            pictureBox3.Enabled = false;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            pictureBox4.Enabled = false;
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            pictureBox5.Enabled = false;
        }
    }
}

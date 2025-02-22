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
        int betMade = 0;

        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            faceDownCards();
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

            // hide card held labels
            labelHeld1.Visible = false;
            labelHeld2.Visible = false;
            labelHeld3.Visible = false;
            labelHeld4.Visible = false;
            labelHeld5.Visible = false;
            
        }

        private void faceDownCards()
        {
            pictureBox1.Image = imageListCards.Images[52];
            pictureBox2.Image = imageListCards.Images[52];
            pictureBox4.Image = imageListCards.Images[52];
            pictureBox3.Image = imageListCards.Images[52];
            pictureBox5.Image = imageListCards.Images[52];
        }

        private void drawNewCards()
        {
            if (!labelHeld1.Visible)
            {
                Card card1 = deck.drawCard();
                playerHand.replaceCard(0, card1);
            }
            if (!labelHeld2.Visible)
            {
                Card card2 = deck.drawCard();
                playerHand.replaceCard(1, card2);
            }
            if (!labelHeld3.Visible)
            {
                Card card3 = deck.drawCard();
                playerHand.replaceCard(2, card3);
            }
            if (!labelHeld4.Visible)
            {
                Card card4 = deck.drawCard();
                playerHand.replaceCard(3, card4);
            }
            if (!labelHeld5.Visible)
            {
                Card card5 = deck.drawCard();
                playerHand.replaceCard(4, card5);
            }
        }

        private void hideLabels()
        {
            labelHeld1.Visible = false;
            labelHeld2.Visible = false;
            labelHeld3.Visible = false;
            labelHeld4.Visible = false;
            labelHeld5.Visible = false;
        }

        private void labelToggleHeld(Label label)
        {
            if (!label.Visible)
            {
                label.Visible = true;
            }
            else if (label.Visible)
            {
                label.Visible = false;
            }
        }

        private int makeBet(int totalCredits)
        {
            if (totalCredits > 0)
            {
                if ((int)numericUpDown.Value > totalCredits)
                {
                    MessageBox.Show("You do not have enough credits. " + totalCredits.ToString() + " Credits will be bet");

                    numericUpDown.Value = totalCredits;
                    totalCredits -= totalCredits;
                    betMade = totalCredits;
                }
                else
                {
                    totalCredits -= (int)numericUpDown.Value;
                    betMade = (int)numericUpDown.Value;
                }

            }
            else if (totalCredits == 0)
            {
                MessageBox.Show("You have 0 credits!! you must start again.");
                totalCredits = 100;
            }

            return totalCredits;
        }

        private void buttonDraw_Click(object sender, EventArgs e)
        {
            Card card = new Card();
            HandDisplay displayHand = new HandDisplay(listPictureBoxes);

            drawNewCards();

            //Show the players hand
            displayHand.showHand(playerHand);

            card = playerHand.getCard(0);
            String rS1 = card.getRankSuit();
            card = playerHand.getCard(1);
            String rS2 = card.getRankSuit();
            card = playerHand.getCard(2);
            String rS3 = card.getRankSuit();
            card = playerHand.getCard(3);
            String rS4 = card.getRankSuit();
            card = playerHand.getCard(4);
            String rS5 = card.getRankSuit();

            PokerScore pokerScore = new PokerScore(rS1, rS2, rS3, rS4, rS5);
            labelHandResult.Text = pokerScore.scoreHand();
            int payOffRatio = pokerScore.getPayoffRatio();
            labelPayOffRatio.Text = payOffRatio.ToString();

            labelAmountWon.Text = (betMade *  payOffRatio).ToString();
            totalCredits = (betMade * payOffRatio) + totalCredits;
            labelTotalCredits.Text = totalCredits.ToString();

            //clear the players hand
            playerHand.clearHand();

            deck.shuffle();

            // Disable bet button enable draw button
            buttonBet.Enabled = true;
            buttonDraw.Enabled = false;

        }

        private void buttonBet_Click(object sender, EventArgs e)
        {
            // Create a deck using cards in (imageListCards)
            //deck = new Deck(imageListCards);

            hideLabels();

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
            labelToggleHeld(labelHeld1);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            labelToggleHeld(labelHeld2);
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            labelToggleHeld(labelHeld3);
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            labelToggleHeld(labelHeld4);
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            labelToggleHeld(labelHeld5);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Feagin_Asg3_Poker
{
    class Deck
    {
        // Make a list for the cards
        private List<Card> listCards = new List<Card>();

        private ImageList imageList;

        public Deck(ImageList imageListOfCards)
        {
            imageList = imageListOfCards;
            loadDeck();
        }

        public void shuffle()
        {
            loadDeck();
        }

        private void loadDeck()
        {
            // Clear the list
            listCards.Clear();

            // Create Card object
            Card card = new Card();

            // Add cards to list in specific order

            int imageIndex = 0;

            for (int i = 1; i <= 13; i++)
            {
                card = new Card(i, Card.CardSuit.Clubs, imageList.Images[imageIndex]);
                listCards.Add(card);
                imageIndex++;

                card = new Card(i, Card.CardSuit.Diamonds, imageList.Images[imageIndex]);
                listCards.Add(card);
                imageIndex++;

                card = new Card(i, Card.CardSuit.Hearts, imageList.Images[imageIndex]);
                listCards.Add(card);
                imageIndex++;

                card = new Card(i, Card.CardSuit.Spades, imageList.Images[imageIndex]);
                listCards.Add(card);
                imageIndex++;
            }
        }

        // Draw random card from deck
        public Card drawCard()
        {
            Card card = new Card();

            if (listCards.Count > 0)
            {

                // To get random we need random # from 0 to 51 ( or count of cards - 1)
                Random rand = new Random(Guid.NewGuid().GetHashCode());

                int index = rand.Next(0, listCards.Count);

                card = listCards[index];

                // Must remove card from deck after drawing
                listCards.RemoveAt(index);

            }

            return card;
        }


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Feagin_Asg3_Poker
{
    public class Hand
    {
        private List<Card> listOfCards = new List<Card>();

        public Hand()
        {
        }

        public void addCard(Card card)
        {
            listOfCards.Add(card);
        }

        public void clearHand()
        {
            listOfCards.Clear();
        }

        public void replaceCard(int index, Card card)
        {
            listOfCards[index] = card;
        }

        public Card getCard(int cardIndex)
        {
            Card card = new Card();

            if (cardIndex < listOfCards.Count)
                card = listOfCards[cardIndex];

            return card;

        }
        public int count()
        {
            return listOfCards.Count();
        }
    }
}

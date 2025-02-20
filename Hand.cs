using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Feagin_Asg3_Poker
{
    public class Hand
    {
        public List<Card> listOfCards = new List<Card>();

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

        public Card getCard(int CardIndex)
        {
            Card card;
            card = listOfCards[CardIndex];

            return card;

        }


    }
}

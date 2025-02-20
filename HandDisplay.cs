using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;
using System.Windows.Forms;

namespace Feagin_Asg3_Poker
{
    class HandDisplay
    {
        private List<PictureBox> pictureBoxes;

        public HandDisplay(List<PictureBox> pictureBoxes)
        {
            this.pictureBoxes = pictureBoxes;
        }   

        public void showHand(Hand hand)
        {
            pictureBoxes[0].Image = hand.getCard(0).FrontImage;
            pictureBoxes[1].Image = hand.getCard(1).FrontImage;
            pictureBoxes[2].Image = hand.getCard(2).FrontImage;
            pictureBoxes[3].Image = hand.getCard(3).FrontImage;
            pictureBoxes[4].Image = hand.getCard(4).FrontImage;
        }

    }
}

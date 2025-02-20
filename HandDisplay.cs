using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;
using System.Windows.Forms;
using System.Drawing;

namespace Feagin_Asg3_Poker
{
    public class HandDisplay
    {
        private List<PictureBox> listPictureBoxes = new List<PictureBox>();
        
       // Image PictureBox.Image { get; set; }

        public HandDisplay(List<PictureBox> pictureBoxes)
        {
            this.listPictureBoxes = pictureBoxes;

        }   

        public void showHand(Hand hand)
        {
            PictureBox pictureBox = new PictureBox();
            Card card = new Card();

            for (int i = 0; i < hand.count(); i++)
            {
                card = hand.getCard(i);
                listPictureBoxes[i].Image = card.FrontImage;
            }
        }

    }
}

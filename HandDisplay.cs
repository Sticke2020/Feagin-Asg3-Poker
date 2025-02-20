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
        public HandDisplay(Hand playerHand) 
        {
            pictureBox1.Image = playerHand.getCard(0);
            pictureBox2.Image = playerHand.getCard(1);
            pictureBox4.Image = playerHand.getCard(2);
            pictureBox3.Image = playerHand.getCard(3);
            pictureBox5.Image = playerHand.getCard(4);
        }
    }
}

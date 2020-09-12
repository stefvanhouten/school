using Memory.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Memory
{
   

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            AddImageToSquares();
        }

        private void AddImageToSquares()
        {
            MyCustomPictureBox pictureBox;
            var images = new List<Bitmap>(){ Resources.tree, Resources.tree, 
                                             Resources.book, Resources.book, 
                                             Resources.banana, Resources.banana, 
                                             Resources.wine, Resources.wine, 
                                             Resources.monkey, Resources.monkey 
                                           };

            for (int i = 0; i < tableLayoutPanel1.Controls.Count; i++)
            {
                if(tableLayoutPanel1.Controls[i] is PictureBox)
                {
                    pictureBox = (MyCustomPictureBox)tableLayoutPanel1.Controls[i];
                }
                else
                {
                    continue;
                }
                pictureBox.Visible = true;
                pictureBox.Image = images[0];
            }
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

    }
}

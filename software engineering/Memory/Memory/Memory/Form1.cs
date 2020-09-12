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
        private List<Card> ordered;

        class Card
        {
            public int Id { get; set; }
            public Bitmap image { get; set; }
        }

        public Form1()
        {
            InitializeComponent();
            BuildDeck();
        }

        private void BuildDeck()
        {
            var images = new List<Bitmap>(){ Resources.tree, Resources.tree,
                                             Resources.book, Resources.book,
                                             Resources.banana, Resources.banana,
                                             Resources.wine, Resources.wine,
                                             Resources.monkey, Resources.monkey,
                                             Resources.car, Resources.car,
                                             Resources.tornado, Resources.tornado,
                                             Resources.bug, Resources.bug
                                           };
            images = images.OrderBy(x => Guid.NewGuid()).ToList();
            this.ordered = new List<Card>();
            for (int i = 0; i < 16; i++)
            {
                var item = new MyCustomPictureBox { SizeMode = PictureBoxSizeMode.StretchImage, Dock = DockStyle.Fill };
                item.Name = i.ToString();
                item.Click += PictureBoxClick;
                tableLayoutPanel1.Controls.Add(item, 0, 0);
                this.ordered.Add(new Card { Id = i, image = images[i] });
            }
        }

        private void PictureBoxClick(object sender, EventArgs e)
        {
            var selected = (PictureBox)sender;
            int cardId = Convert.ToInt32(selected.Name);
            selected.Image = this.ordered[cardId].image;
        }
    }
}

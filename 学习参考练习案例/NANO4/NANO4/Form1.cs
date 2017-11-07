using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NANO4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Form2 f = new Form2();
            f.Show();
            MessageBox.Show("是你的益达~~");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SoundPlayer sp = new SoundPlayer(@"d:\库\文档\visual studio 2013\Projects\NANO4\NANO4\Resources\1.wav");
            sp.PlayLooping();
        }
    }
}

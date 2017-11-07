using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NANO4
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            Random r = new Random();
            this.Left = r.Next(0, 1366);
            this.Top = r.Next(0, 768);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
        }
    }
}

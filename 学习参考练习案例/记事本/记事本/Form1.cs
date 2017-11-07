using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 记事本
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void 打开ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "打开文本";
            ofd.InitialDirectory = @"C:\Users\Own\Desktop";
            ofd.Filter = "文本文件|*.txt|所有文件|*.*";
            ofd.ShowDialog();
            if(ofd.FileName=="")
            {
                return;
            }
            using(FileStream fsRead=new FileStream(ofd.FileName,FileMode.OpenOrCreate,FileAccess.Read))
            {
                byte[] buffer=new byte[1024*1024*5];
                textBox1.Text = Encoding.Default.GetString(buffer, 0, fsRead.Read(buffer, 0, buffer.Length));
            }

        }

        private void 保存ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Title = "保存文本";
            sfd.InitialDirectory = @"C:\Users\Own\Desktop";
            sfd.Filter = "文本文件|*.txt|所有文件|*.*";
            sfd.ShowDialog();
            if (sfd.FileName == "")
            {
                return;
            }
            using (FileStream fsWrite = new FileStream(sfd.FileName, FileMode.OpenOrCreate, FileAccess.Write))
            {
                byte[] buffer = Encoding.Default.GetBytes(textBox1.Text);
                fsWrite.Write(buffer, 0, buffer.Length);
            }
            MessageBox.Show("保存成功");
        }

        private void 自动换行ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(textBox1.WordWrap == false)
            {
                textBox1.WordWrap = true;
            }
            else
            {
                textBox1.WordWrap = false;
            }
        }

        private void 字体ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog fd = new FontDialog();
            fd.ShowDialog();
            textBox1.Font = fd.Font;
        }

        private void 颜色ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            cd.ShowDialog();
            textBox1.ForeColor = cd.Color;
        }

        private void toolStripComboBox1_Click(object sender, EventArgs e)
        {

        }

        private void 打开记录ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}

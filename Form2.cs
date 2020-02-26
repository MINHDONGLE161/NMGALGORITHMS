using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NAMUGA_TEST1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("PYTHON");
            pictureBox1.Image = Image.FromFile(@"Images\python.png");
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("JAVA");
            pictureBox1.Image = Image.FromFile(@"Images\java.png");
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            MessageBox.Show("JAVASCRIPT");
            pictureBox1.Image = Image.FromFile(@"Images\javascript.png");
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            MessageBox.Show("PHP");
            pictureBox1.Image = Image.FromFile(@"Images\php.png");
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MessageBox.Show("C");
            pictureBox1.Image = Image.FromFile(@"Images\C.png");
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("C++");
            pictureBox1.Image = Image.FromFile(@"Images\C++.png");
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("C#");
            pictureBox1.Image = Image.FromFile(@"Images\C#.png");
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Objective_C");
            pictureBox1.Image = Image.FromFile(@"Images\objective_C.png");
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            MessageBox.Show("RUBY");
            pictureBox1.Image = Image.FromFile(@"Images\RUBY.png");
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            MessageBox.Show("C++ content");
            pictureBox1.Image = Image.FromFile(@"Images\c++_content.png");
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void button15_Click(object sender, EventArgs e)
        {
            MessageBox.Show("C++ Data type");
            pictureBox1.Image = Image.FromFile(@"Images\c++_datatype.png");
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void button14_Click(object sender, EventArgs e)
        {
            MessageBox.Show("C++ Header files");
            pictureBox1.Image = Image.FromFile(@"Images\c++_headerfiles.png");
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            MessageBox.Show("C++ Keyword");
            pictureBox1.Image = Image.FromFile(@"Images\c++_keyword.png");
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            MessageBox.Show("C++ Ma nguon");
            pictureBox1.Image = Image.FromFile(@"Images\c++_manguon.png");
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void button11_Click(object sender, EventArgs e)
        {

            MessageBox.Show("C++ Overview");
            pictureBox1.Image = Image.FromFile(@"Images\c++_overview.png");
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void button18_Click(object sender, EventArgs e)
        {
            MessageBox.Show("C++ Program Structure");
            pictureBox1.Image = Image.FromFile(@"Images\c++_programstructure.png");
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void button17_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Visual C++");
            pictureBox1.Image = Image.FromFile(@"Images\visualc++.png");
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void button16_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Visual C++ 1");
            pictureBox1.Image = Image.FromFile(@"Images\visualc++1.png");
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {

        }

        private void group1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
           // MessageBox.Show("S");
            pictureBox1.Image = Image.FromFile(@"Images\School1.png");
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void group2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = Image.FromFile(@"Images\School2.png");
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void group3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = Image.FromFile(@"Images\School3.png");
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void group1ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = Image.FromFile(@"Images\Social1.png");
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void group2ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = Image.FromFile(@"Images\Social2.png");
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void group3ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = Image.FromFile(@"Images\Social3.png");
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void group1ToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = Image.FromFile(@"Images\Health1.png");
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void group2ToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = Image.FromFile(@"Images\Health2.png");
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void group3ToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = Image.FromFile(@"Images\Health3.png");
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void group1ToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = Image.FromFile(@"Images\Shopping1.png");
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void group2ToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = Image.FromFile(@"Images\Shopping2.png");
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void group3ToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = Image.FromFile(@"Images\Shopping3.png");
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void group1ToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = Image.FromFile(@"Images\Cooking1.png");
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void group2ToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = Image.FromFile(@"Images\Cooking2.png");
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        }
    }
    }
    


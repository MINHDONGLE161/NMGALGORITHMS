
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Collections;
using System.Drawing.Imaging;
using System.Drawing.Configuration;
using System.IO;

//using AForge.Imaging;
using AForge.Imaging.Filters;
using AForge.Imaging.ComplexFilters;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.Util;
using Emgu.CV.Features2D;
using Emgu.CV.XFeatures2D;







namespace NAMUGA_TEST1
{
    public partial class NAMUGA : Form
    {
        //****Start****A session main variance*************
        //A1. main picture bitmap and image format
        public Bitmap bmp;
        public Bitmap original_image;
        public Image<Gray, byte> bmp_cv;
        
        

        public NAMUGA()
        {
            // A2. mouse click form1 and picturebox1
            InitializeComponent();
            this.MouseDown += new MouseEventHandler(this.form1_click);
            pictureBox1.MouseClick += pictureBox1_MouseClick;


        }
        private void form1_click(object sender, EventArgs e)
        {
            // Get the mouse position.
            Point pt = MousePosition;
            textBox6.Text = pt.X.ToString();
            textBox7.Text = pt.Y.ToString();
        }
        public void pictureBox1_Click(object sender, EventArgs e)
        {
            // Get the mouse position.
            Point pt = MousePosition;

            // Convert to screen coordinates.
            pt = this.PointToClient(pt);

            using (Graphics gr = this.CreateGraphics())
            {
                //gr.SmoothingMode = SmoothingMode.AntiAlias;
                gr.DrawLine(Pens.Red,
                    pt.X - 5, pt.Y - 5, pt.X + 5, pt.Y + 5);
                gr.DrawLine(Pens.Blue,
                    pt.X + 5, pt.Y - 5, pt.X - 5, pt.Y + 5);
            }
        }
        public void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            Color c;
            byte rgb;
            textBox6.Text = e.X.ToString();
            textBox7.Text = e.Y.ToString();
            bmp = new Bitmap(resizeImage(bmp, pictureBox1.Width, pictureBox1.Height));
            c = bmp.GetPixel(e.X, e.Y);
            rgb = (byte)(.299 * c.R + .587 * c.G + .114 * c.B);
            textBox8.Text = c.R.ToString();
            textBox9.Text = c.G.ToString();
            textBox10.Text = c.B.ToString();
            textBox11.Text = rgb.ToString();
        }
        // A. link to form2
        public void button33_Click(object sender, EventArgs e)
        {
            // this.Hide();
            Form2 form2 = new Form2();
            form2.ShowDialog();
            //this.Close();
        }



        private void Form1_Load(object sender, EventArgs e)
        {



        }
        //######### END A session#####################################


        //***Start***********B session TOF THEORY*********************


        public void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("SMT Diagram");

            // bmp = new Bitmap(Image.FromFile("D:\\MinhDong\\TOF\\SMT_progress.png"));
            bmp = new Bitmap(Image.FromFile(@"Images\SMT_progress.png")); 
            picture1_show(bmp);

        }
        public void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("SUB Diagram");

            bmp = new Bitmap(Image.FromFile(@"Images\SUB_progress.png"));
            picture1_show(bmp);

        }
        public void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("PKG Diagram");
            //pictureBox1.Image = Image.FromFile("D:\\MinhDong\\TOF\\PKG_progress.png");
            bmp = new Bitmap(Image.FromFile(@"Images\PKG_progress.png"));
            picture1_show(bmp);
        }
        public void button4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("TEST Diagram");
            //pictureBox1.Image = Image.FromFile("D:\\MinhDong\\TOF\\Test_progress.png");
            //pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            bmp = new Bitmap(Image.FromFile(@"Images\Test_progress.png"));
            picture1_show(bmp);
        }
        public void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            MessageBox.Show("TOF");
            // pictureBox1.Image = Image.FromFile("D:\\MinhDong\\TOF\\TOF_process.png");
            // pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            bmp = new Bitmap(Image.FromFile(@"Images\TOF_process.png"));
            picture1_show(bmp);
        }
        public void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            MessageBox.Show("TOF component");
            //pictureBox1.Image = Image.FromFile("D:\\MinhDong\\TOF\\TOF_component.png");
            //pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            bmp = new Bitmap(Image.FromFile(@"Images\TOF_component.png"));
            picture1_show(bmp);
        }
        public void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            MessageBox.Show("TOF theory1");
            //pictureBox1.Image = Image.FromFile("D:\\MinhDong\\TOF\\TOF_theory.png");
            //pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            bmp = new Bitmap(Image.FromFile(@"Images\TOF_theory.png"));
            picture1_show(bmp);
        }

        public void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            MessageBox.Show("TOF theory2");
            //pictureBox1.Image = Image.FromFile("D:\\MinhDong\\TOF\\TOF_theory2.png");
            //pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            bmp = new Bitmap(Image.FromFile(@"Images\TOF_theory2.png"));
            picture1_show(bmp);
        }

        public void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            MessageBox.Show("TOF theory3");
            //pictureBox1.Image = Image.FromFile("D:\\MinhDong\\TOF\\TOF_theory3.png");
            //pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            bmp = new Bitmap(Image.FromFile(@"Images\TOF_theory3.png"));
            picture1_show(bmp);
        }

        public void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            MessageBox.Show("TOF process");
            // pictureBox1.Image = Image.FromFile("D:\\MinhDong\\TOF\\TOF_process.png");
            //pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            bmp = new Bitmap(Image.FromFile(@"Images\TOF_process.png"));
            picture1_show(bmp);

        }

        public void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            MessageBox.Show("TOF comparision");
            //pictureBox1.Image = Image.FromFile("D:\\MinhDong\\TOF\\TOF_comparision.png");
            //pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            bmp = new Bitmap(Image.FromFile(@"Images\TOF_comparision.png"));
            picture1_show(bmp);
        }
        //###### END #### B session TOF THEORY ############################################################

        //******START*****C Session CAMERA STRUCTURE********************************************************
        public void button5_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("Camera Structure");
            //pictureBox1.Image = Image.FromFile("D:\\MinhDong\\TOF\\camera_structure.png");
            //pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            bmp = new Bitmap(Image.FromFile(@"Images\camera_structure.png"));
            picture1_show(bmp);
        }

        public void button6_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Camera Parts");
            //pictureBox1.Image = Image.FromFile("D:\\MinhDong\\TOF\\camera_part.png");
            // pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            bmp = new Bitmap(Image.FromFile(@"Images\camera_part.png"));
            picture1_show(bmp);
        }

        public void button7_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Camera Substrate");
            //pictureBox1.Image = Image.FromFile("D:\\MinhDong\\TOF\\camera_substrate.png");
            //pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            bmp = new Bitmap(Image.FromFile(@"Images\camera_substrate.png"));
            picture1_show(bmp);
        }

        public void button8_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Camera Chip");
            //pictureBox1.Image = Image.FromFile("D:\\MinhDong\\TOF\\camera_chip.png");
            //pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            bmp = new Bitmap(Image.FromFile(@"Images\camera_chip.png"));
            picture1_show(bmp);
        }

        public void button9_Click(object sender, EventArgs e)
        {

            MessageBox.Show("Camera Function");
            //pictureBox1.Image = Image.FromFile("D:\\MinhDong\\TOF\\camera_function.png");
            //pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            bmp = new Bitmap(Image.FromFile(@"Images\camera_function.png"));
            picture1_show(bmp);
        }

        public void button12_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Sensor Structure");
            //pictureBox1.Image = Image.FromFile("D:\\MinhDong\\TOF\\sensor_structure.png");
            //pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            bmp = new Bitmap(Image.FromFile(@"Images\sensor_structure.png"));
            picture1_show(bmp);
        }

        public void button11_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Sensor CCD");
            //pictureBox1.Image = Image.FromFile("D:\\MinhDong\\TOF\\sensor_ccd.png");
            //pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            bmp = new Bitmap(Image.FromFile(@"Images\sensor_ccd.png"));
            picture1_show(bmp);
        }

        public void button10_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Sensor CMOS");
            //pictureBox1.Image = Image.FromFile("D:\\MinhDong\\TOF\\sensor_cmos.png");
            //pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            //pictureBox1.Image = AdjustBrightness((Bitmap)pictureBox1.Image, trackBar1.Value);
            bmp = new Bitmap(Image.FromFile(@"Images\sensor_cmos.png"));
            picture1_show(bmp);
        }

        public void button13_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Pixel 1");
            //pictureBox1.Image = Image.FromFile("D:\\MinhDong\\TOF\\pixel_structure.png");
            //pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            bmp = new Bitmap(Image.FromFile(@"Images\pixel_structure.png"));
            picture1_show(bmp);
        }

        public void button14_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Pixel 2");
            //pictureBox1.Image = Image.FromFile("D:\\MinhDong\\TOF\\pixel_structure2.png");
            //pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            bmp = new Bitmap(Image.FromFile(@"Images\pixel_structure2.png"));
            picture1_show(bmp);
        }

        public void button15_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Pixel 3");
            //pictureBox1.Image = Image.FromFile("D:\\MinhDong\\TOF\\pixel_structure3.png");
            // pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            bmp = new Bitmap(Image.FromFile(@"Images\pixel_structure3.png"));
            picture1_show(bmp);
        }

        public void button16_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Pixel 4");
            //pictureBox1.Image = Image.FromFile("D:\\MinhDong\\TOF\\pixel_structure4.png");
            //pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            bmp = new Bitmap(Image.FromFile(@"Images\pixel_structure4.png"));
            picture1_show(bmp);
        }

        public void button17_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Sensor Architecture");
            //pictureBox1.Image = Image.FromFile("D:\\MinhDong\\TOF\\sensor_architecture.png");
            // pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            bmp = new Bitmap(Image.FromFile(@"Images\sensor_architecture.png"));
            picture1_show(bmp);
        }

        public void button18_Click(object sender, EventArgs e)
        {
            MessageBox.Show("LEN FOCUS");
            //pictureBox1.Image = Image.FromFile("D:\\MinhDong\\TOF\\len_focus.png");
            //pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            bmp = new Bitmap(Image.FromFile(@"Images\len_focus.png"));
            picture1_show(bmp);
        }

        public void button20_Click(object sender, EventArgs e)
        {
            MessageBox.Show("LEN FOV");
            //pictureBox1.Image = Image.FromFile("D:\\MinhDong\\TOF\\len_fov.png");
            //pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            bmp = new Bitmap(Image.FromFile(@"Images\len_fov.png"));
            picture1_show(bmp);
        }

        public void button19_Click(object sender, EventArgs e)
        {
            MessageBox.Show("LEN MTF");
            //pictureBox1.Image = Image.FromFile("D:\\MinhDong\\TOF\\MTF_theory.png");
            //pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            bmp = new Bitmap(Image.FromFile(@"Images\MTF_theory.png"));
            picture1_show(bmp);
        }

        public void button21_Click(object sender, EventArgs e)
        {
            MessageBox.Show("LEN Resolution");
            //pictureBox1.Image = Image.FromFile("D:\\MinhDong\\TOF\\len_resolution.png");
            //pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            bmp = new Bitmap(Image.FromFile(@"Images\len_resolution.png"));
            picture1_show(bmp);
        }

        public void button22_Click(object sender, EventArgs e)
        {
            MessageBox.Show("AF Concept");
            //pictureBox1.Image = Image.FromFile("D:\\MinhDong\\TOF\\AF_concept.png");
            //pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            bmp = new Bitmap(Image.FromFile(@"Images\AF_concept.png"));
            picture1_show(bmp);
        }

        public void button23_Click(object sender, EventArgs e)
        {
            MessageBox.Show("AF Principle1");
            // pictureBox1.Image = Image.FromFile("D:\\MinhDong\\TOF\\AF_principle.png");
            // pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            bmp = new Bitmap(Image.FromFile(@"Images\AF_principle.png"));
            picture1_show(bmp);
        }

        public void button24_Click(object sender, EventArgs e)
        {
            MessageBox.Show("AF Principle2");
            //pictureBox1.Image = Image.FromFile("D:\\MinhDong\\TOF\\AF_principle2.png");
            //pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            bmp = new Bitmap(Image.FromFile(@"Images\AF_principle2.png"));
            picture1_show(bmp);
        }

        public void button25_Click(object sender, EventArgs e)
        {
            MessageBox.Show("AF VCM");
            //pictureBox1.Image = Image.FromFile("D:\\MinhDong\\TOF\\AF_VCM.png");
            //pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            bmp = new Bitmap(Image.FromFile(@"Images\AF_VCM.png"));
            picture1_show(bmp);
        }

        public void button26_Click(object sender, EventArgs e)
        {
            MessageBox.Show("AF VCM2");
            //pictureBox1.Image = Image.FromFile("D:\\MinhDong\\TOF\\AF_VCM2.png");
            //pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            bmp = new Bitmap(Image.FromFile(@"Images\AF_VCM2.png"));
            picture1_show(bmp);
        }

        public void button27_Click(object sender, EventArgs e)
        {
            MessageBox.Show("AF Cover");
            // pictureBox1.Image = Image.FromFile("D:\\MinhDong\\TOF\\AF_cover.png");
            // pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            bmp = new Bitmap(Image.FromFile(@"Images\AF_cover.png"));
            picture1_show(bmp);
        }

        public void button28_Click(object sender, EventArgs e)
        {
            MessageBox.Show("IR theory1");
            //pictureBox1.Image = Image.FromFile("D:\\MinhDong\\TOF\\IR_theory.png");
            //pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            bmp = new Bitmap(Image.FromFile(@"Images\IR_theory.png"));
            picture1_show(bmp);
        }

        public void button32_Click(object sender, EventArgs e)
        {
            MessageBox.Show("IR theory2");
            //pictureBox1.Image = Image.FromFile("D:\\MinhDong\\TOF\\IR_theory2.png");
            //pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            bmp = new Bitmap(Image.FromFile(@"Images\IR_theory2.png"));
            picture1_show(bmp);
        }

        public void button29_Click(object sender, EventArgs e)
        {
            MessageBox.Show("IR Example");
            // pictureBox1.Image = Image.FromFile("D:\\MinhDong\\TOF\\IR_Example.png");
            // pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            bmp = new Bitmap(Image.FromFile(@"Images\IR_Example.png"));
            picture1_show(bmp);
        }

        public void button30_Click(object sender, EventArgs e)
        {
            MessageBox.Show("IR Bluefilter");
            //pictureBox1.Image = Image.FromFile("D:\\MinhDong\\TOF\\IR_Bluefilter.png");
            //pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            bmp = new Bitmap(Image.FromFile(@"Images\IR_Bluefilter.png"));
            picture1_show(bmp);
        }

        public void button31_Click(object sender, EventArgs e)
        {
            MessageBox.Show("IR Transmittance");
            // pictureBox1.Image = Image.FromFile("D:\\MinhDong\\TOF\\IR_Transmittance.png");
            // pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            bmp = new Bitmap(Image.FromFile(@"Images\IR_Transmittance.png"));
            picture1_show(bmp);
        }
        public void button37_Click(object sender, EventArgs e)
        {
            //grayscale
            MessageBox.Show("DefectName_EVI grayscale");
            Bitmap image1;
            //pictureBox1.Image = Image.FromFile("D:\\MinhDong\\TOF\\defectname_EVI.png");
            //pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
            image1 = new Bitmap(@"D:\\MinhDong\\TOF\\defectname_EVI.png");

            Bitmap kq = new Bitmap(image1.Width, image1.Height);
            Bitmap anhtam = new Bitmap(image1);
            Color c;
            Byte rgb;
            for (int cot = 0; cot < anhtam.Width; cot++)
                for (int hang = 0; hang < anhtam.Height; hang++)
                {
                    c = anhtam.GetPixel(cot, hang);
                    rgb = (byte)(.299 * c.R + .587 * c.G + .114 * c.B);
                    kq.SetPixel(cot, hang, Color.FromArgb(rgb, rgb, rgb));
                }
            //return kq;
            pictureBox1.Image = kq;
            pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
        }
        public void button35_Click(object sender, EventArgs e)
        {
            MessageBox.Show("DefectName_Function");
            // pictureBox1.Image = Image.FromFile("D:\\MinhDong\\TOF\\defectname_function.png");
            // pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
            bmp = new Bitmap(Image.FromFile(@"Images\defectname_function.png"));
            picture1_show(bmp);
        }
        //######END ##### SESSION C CAMERA STRUCTURE ###############################################

        //******START*****SESSION D IMAGE PROCESSING function ****************************
        //D1 Sobel function
        private Bitmap SobelEdgeDetect(Bitmap original)
        {
            //Bitmap b = new Bitmap(original.Width, original.Height);
            Bitmap bb = new Bitmap(original);
            Bitmap b = new Bitmap(original);

           // Bitmap b = original;
            //Bitmap bb = original;
            int width = b.Width;
            int height = b.Height;
            int[,] gx = new int[,] { { -1, 0, 1 }, { -2, 0, 2 }, { -1, 0, 1 } };
            int[,] gy = new int[,] { { 1, 2, 1 }, { 0, 0, 0 }, { -1, -2, -1 } };

            int[,] allPixR = new int[width, height];
            int[,] allPixG = new int[width, height];
            int[,] allPixB = new int[width, height];

            int limit = 128 * 128;

            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    allPixR[i, j] = b.GetPixel(i, j).R;
                    allPixG[i, j] = b.GetPixel(i, j).G;
                    allPixB[i, j] = b.GetPixel(i, j).B;
                }
            }

            int new_rx = 0, new_ry = 0;
            int new_gx = 0, new_gy = 0;
            int new_bx = 0, new_by = 0;
            int rc, gc, bc;
            for (int i = 1; i < b.Width - 1; i++)
            {
                for (int j = 1; j < b.Height - 1; j++)
                {

                    new_rx = 0;
                    new_ry = 0;
                    new_gx = 0;
                    new_gy = 0;
                    new_bx = 0;
                    new_by = 0;
                    rc = 0;
                    gc = 0;
                    bc = 0;

                    for (int wi = -1; wi < 2; wi++)
                    {
                        for (int hw = -1; hw < 2; hw++)
                        {
                            rc = allPixR[i + hw, j + wi];
                            new_rx += gx[wi + 1, hw + 1] * rc;
                            new_ry += gy[wi + 1, hw + 1] * rc;

                            gc = allPixG[i + hw, j + wi];
                            new_gx += gx[wi + 1, hw + 1] * gc;
                            new_gy += gy[wi + 1, hw + 1] * gc;

                            bc = allPixB[i + hw, j + wi];
                            new_bx += gx[wi + 1, hw + 1] * bc;
                            new_by += gy[wi + 1, hw + 1] * bc;
                        }
                    }
                    if (new_rx * new_rx + new_ry * new_ry > limit || new_gx * new_gx + new_gy * new_gy > limit || new_bx * new_bx + new_by * new_by > limit)
                        bb.SetPixel(i, j, Color.Black);


                    else
                        bb.SetPixel(i, j, Color.Transparent);
                }
            }
            return bb;
        }
        // D2 histogramEqualization function for color images
        public Bitmap histogramEqualization(Bitmap sourceImage)
        {
            Bitmap renderedImage = new Bitmap(sourceImage);

            uint pixels = (uint)renderedImage.Height * (uint)renderedImage.Width;
            decimal Const = 255 / (decimal)pixels;

            int x, y, R, G, B;
            //AForge.Imaging.ImageStatistics statistics = new AForge.Imaging.ImageStatistics(sourceImage);

            AForge.Imaging.ImageStatistics statistics = new AForge.Imaging.ImageStatistics(renderedImage);

            //Create histogram arrays for R,G,B channels
            int[] cdfR = statistics.Red.Values.ToArray();
            int[] cdfG = statistics.Green.Values.ToArray();
            int[] cdfB = statistics.Blue.Values.ToArray();

            //Convert arrays to cumulative distribution frequency data
            for (int r = 1; r <= 255; r++)
            {
                cdfR[r] = cdfR[r] + cdfR[r - 1];
                cdfG[r] = cdfG[r] + cdfG[r - 1];
                cdfB[r] = cdfB[r] + cdfB[r - 1];
            }

            for (y = 0; y < renderedImage.Height; y++)
            {
                for (x = 0; x < renderedImage.Width; x++)
                {
                    Color pixelColor = renderedImage.GetPixel(x, y);

                    R = (int)((decimal)cdfR[pixelColor.R] * Const);
                    G = (int)((decimal)cdfG[pixelColor.G] * Const);
                    B = (int)((decimal)cdfB[pixelColor.B] * Const);

                    Color newColor = Color.FromArgb(R, G, B);
                    renderedImage.SetPixel(x, y, newColor);
                }
            }
            return renderedImage;
        }
        // D3 GRAYSCALE
        public Bitmap DenTrang(Bitmap anh)
        {
            Bitmap kq = new Bitmap(anh.Width, anh.Height);
            Bitmap anhtam = new Bitmap(anh);
            Color c;
            Byte rgb;
            for (int cot = 0; cot < anhtam.Width; cot++)
                for (int hang = 0; hang < anhtam.Height; hang++)
                {
                    c = anhtam.GetPixel(cot, hang);
                    rgb = (byte)(.299 * c.R + .587 * c.G + .114 * c.B);
                    kq.SetPixel(cot, hang, Color.FromArgb(rgb, rgb, rgb));
                }
            return kq;
        }
        // D4 AdjustBrightness
        public static Bitmap AdjustBrightness(Bitmap Image, int Value)
        {
            System.Drawing.Bitmap TempBitmap = new Bitmap (Image);
            float FinalValue = (float)Value / 255.0f;
            System.Drawing.Bitmap NewBitmap = new System.Drawing.Bitmap(TempBitmap.Width, TempBitmap.Height);
            System.Drawing.Graphics NewGraphics = System.Drawing.Graphics.FromImage(NewBitmap);
            float[][] FloatColorMatrix ={
                     new float[] {1, 0, 0, 0, 0},
                     new float[] {0, 1, 0, 0, 0},
                     new float[] {0, 0, 1, 0, 0},
                     new float[] {0, 0, 0, 1, 0},
                     new float[] {FinalValue, FinalValue, FinalValue, 1, 1}
                 };

            System.Drawing.Imaging.ColorMatrix NewColorMatrix = new System.Drawing.Imaging.ColorMatrix(FloatColorMatrix);
            System.Drawing.Imaging.ImageAttributes Attributes = new System.Drawing.Imaging.ImageAttributes();
            Attributes.SetColorMatrix(NewColorMatrix);
            NewGraphics.DrawImage(TempBitmap, new System.Drawing.Rectangle(0, 0, TempBitmap.Width, TempBitmap.Height), 0, 0, TempBitmap.Width, TempBitmap.Height, System.Drawing.GraphicsUnit.Pixel, Attributes);
            Attributes.Dispose();
            NewGraphics.Dispose();
            return NewBitmap;
        }
        // D5 Block Division
        public Bitmap Block(Bitmap image_block)
        {
            Bitmap kq = new Bitmap(image_block.Width, image_block.Height);
            Bitmap anhtam = new Bitmap(image_block);
            Color c;
            //Color c_block;
            // int count_red = 0;

            //Byte rgb;
            for (int cot = 0; cot < anhtam.Width; cot++)
                for (int hang = 0; hang < anhtam.Height; hang++)
                {
                    c = anhtam.GetPixel(cot, hang);

                    //rgb = (byte)(.299 * c.R + .587 * c.G + .114 * c.B);


                    if ((cot % 50 == 0) || (hang % 50 == 0))
                        kq.SetPixel(cot, hang, Color.Green);
                    else
                        kq.SetPixel(cot, hang, Color.FromArgb(c.R, c.G, c.B));
                }
            return kq;
        }
        // D7 DRAWING
        public Bitmap Draw(Bitmap image_draw)
        {
            Bitmap kq = new Bitmap(image_draw.Width, image_draw.Height);
            Bitmap anhtam = new Bitmap(image_draw);
            Color c;
            //List<PointF> pointList = new List<PointF>();
            PointF[] ARRAY_TEST1 = new PointF[] { new Point(0, 0), new Point(0, 0) };
            PointF[] ARRAY_TEST2 = new PointF[] { new Point(0, 0), new Point(0, 0) };
            PointF[] ARRAY_TEST3 = new PointF[] { new Point(0, 0), new Point(0, 0) };
            PointF[] ARRAY_TEST4 = new PointF[] { new Point(0, 0), new Point(0, 0) };
            PointF[] ARRAY_TEST5 = new PointF[] { new Point(0, 0), new Point(0, 0) };
            PointF[] ARRAY_TEST6 = new PointF[] { new Point(0, 0), new Point(0, 0) };
            PointF[] ARRAY_TEST7 = new PointF[] { new Point(0, 0), new Point(0, 0) };
            PointF[] ARRAY_TEST8 = new PointF[] { new Point(0, 0), new Point(0, 0) };
            PointF[] ARRAY_TEST9 = new PointF[] { new Point(0, 0), new Point(0, 0) };
            PointF[] ARRAY_TEST10 = new PointF[] { new Point(0, 0), new Point(0, 0) };
            PointF[] ARRAY_TEST11 = new PointF[] { new Point(0, 0), new Point(0, 0) };
            PointF[] ARRAY_TEST12 = new PointF[] { new Point(0, 0), new Point(0, 0) };
            PointF[] ARRAY_TEST13 = new PointF[] { new Point(0, 0), new Point(0, 0) };
            PointF[] ARRAY_TEST14 = new PointF[] { new Point(0, 0), new Point(0, 0) };
            PointF[] ARRAY_TEST15 = new PointF[] { new Point(0, 0), new Point(0, 0) };
            PointF[] ARRAY_TEST16 = new PointF[] { new Point(0, 0), new Point(0, 0) };
            //PointF[] ARRAY_TEST = null;

            // pointList.Add(new Point(x, y));
            Byte rgb;
            int up_gray = 255;
            int down_gray = 200;
            int k = 0;




            for (int cot = 0; cot < anhtam.Width; cot++)
                for (int hang = 0; hang < anhtam.Height; hang++)
                {
                    c = anhtam.GetPixel(cot, hang);

                    rgb = (byte)(.299 * c.R + .587 * c.G + .114 * c.B);

                  //Up_gray = int.Parse(textBox12.Text);
                 // down_gray = int.Parse(textBox13.Text);

                    if ((rgb >= down_gray) && (rgb <= up_gray)&& (cot<=anhtam.Width/2) &&(hang<=anhtam.Height/4))
                    
                    {
                        
                        ARRAY_TEST1 = new PointF[] { new Point { X = cot, Y = hang }, new Point { X = cot + 50, Y = hang + 50 }, new Point { X = cot - 50, Y = hang - 50 } };
                        
                    }
                    if ((rgb >= down_gray) && (rgb <= up_gray) && (cot <= anhtam.Width / 2) && (hang > anhtam.Height / 4)&& (hang < anhtam.Height / 2))
                    {
                        ARRAY_TEST2 = new PointF[] { new Point { X = cot, Y = hang }, new Point { X = cot + 50, Y = hang + 50 }, new Point { X = cot - 50, Y = hang - 50 } };
                    }
                    if ((rgb >= down_gray) && (rgb <= up_gray) && (cot <anhtam.Width / 2) && (hang >=anhtam.Height / 2) && (hang <3*anhtam.Height / 4))
                    {
                        ARRAY_TEST3 = new PointF[] { new Point { X = cot, Y = hang }, new Point { X = cot + 50, Y = hang + 50 }, new Point { X = cot - 50, Y = hang - 50 } };
                    }
                    if ((rgb >= down_gray) && (rgb <= up_gray) && (cot < anhtam.Width / 2)&& (hang >= 3*anhtam.Height / 4)&&(hang < anhtam.Height ))
                    {
                        ARRAY_TEST4 = new PointF[] { new Point { X = cot, Y = hang }, new Point { X = cot + 50, Y = hang + 50 }, new Point { X = cot - 50, Y = hang - 50 } };
                    }
                    if ((rgb >= down_gray) && (rgb <= up_gray) && (cot >= anhtam.Width / 2) && (cot < anhtam.Width )  && (hang < anhtam.Height / 4))
                    {
                        ARRAY_TEST5 = new PointF[] { new Point { X = cot, Y = hang }, new Point { X = cot + 50, Y = hang + 50 }, new Point { X = cot - 50, Y = hang - 50 } };
                    }
                    if ((rgb >= down_gray) && (rgb <= up_gray) && (cot >= anhtam.Width / 2) && (cot < anhtam.Width ) && (hang >= anhtam.Height / 4) && (hang <  anhtam.Height/2 ))
                    {
                        ARRAY_TEST6 = new PointF[] { new Point { X = cot, Y = hang }, new Point { X = cot + 50, Y = hang + 50 }, new Point { X = cot - 50, Y = hang - 50 } };
                    }
                    if ((rgb >= down_gray) && (rgb <= up_gray) && (cot >= anhtam.Width / 2) && (cot < anhtam.Width ) && (hang >= anhtam.Height / 2) && (hang < 3*anhtam.Height/4))
                    {
                        ARRAY_TEST7 = new PointF[] { new Point { X = cot, Y = hang }, new Point { X = cot + 50, Y = hang + 50 }, new Point { X = cot - 50, Y = hang - 50 } };
                    }
                    if ((rgb >= down_gray) && (rgb <= up_gray) && (cot >= anhtam.Width / 2) && (cot < anhtam.Width) && (hang >= 3*anhtam.Height / 4) && (hang <  anhtam.Height ))
                    {
                        ARRAY_TEST8 = new PointF[] { new Point { X = cot, Y = hang }, new Point { X = cot + 50, Y = hang + 50 }, new Point { X = cot - 50, Y = hang - 50 } };
                    }

                    if ((rgb >= down_gray) && (rgb <= up_gray) && (cot < 3*anhtam.Width / 4)&&(cot >= anhtam.Width / 2) && (hang <= anhtam.Height / 4))

                    {

                        ARRAY_TEST9 = new PointF[] { new Point { X = cot, Y = hang }, new Point { X = cot + 50, Y = hang + 50 }, new Point { X = cot - 50, Y = hang - 50 } };

                    }
                    if ((rgb >= down_gray) && (rgb <= up_gray) && (cot >= anhtam.Width / 2) && (cot < 3 * anhtam.Width / 4) && (hang > anhtam.Height / 4) && (hang < anhtam.Height / 2))
                    {
                        ARRAY_TEST10 = new PointF[] { new Point { X = cot, Y = hang }, new Point { X = cot + 50, Y = hang + 50 }, new Point { X = cot - 50, Y = hang - 50 } };
                    }
                    if ((rgb >= down_gray) && (rgb <= up_gray) && (cot >= anhtam.Width / 2) && (cot < 3 * anhtam.Width / 4) && (hang >= anhtam.Height / 2) && (hang < 3 * anhtam.Height / 4))
                    {
                        ARRAY_TEST11 = new PointF[] { new Point { X = cot, Y = hang }, new Point { X = cot + 50, Y = hang + 50 }, new Point { X = cot - 50, Y = hang - 50 } };
                    }
                    if ((rgb >= down_gray) && (rgb <= up_gray) && (cot >= anhtam.Width / 2) && (cot < 3 * anhtam.Width / 4) && (hang >= 3 * anhtam.Height / 4) && (hang < anhtam.Height))
                    {
                        ARRAY_TEST12 = new PointF[] { new Point { X = cot, Y = hang }, new Point { X = cot + 50, Y = hang + 50 }, new Point { X = cot - 50, Y = hang - 50 } };
                    }
                    if ((rgb >= down_gray) && (rgb <= up_gray) && (cot >= 3*anhtam.Width / 2) && (cot < anhtam.Width) && (hang < anhtam.Height / 4))
                    {
                        ARRAY_TEST13 = new PointF[] { new Point { X = cot, Y = hang }, new Point { X = cot + 50, Y = hang + 50 }, new Point { X = cot - 50, Y = hang - 50 } };
                    }
                    if ((rgb >= down_gray) && (rgb <= up_gray) && (cot >= 3*anhtam.Width / 4) && (cot < anhtam.Width) && (hang >= anhtam.Height / 4) && (hang < anhtam.Height / 2))
                    {
                        ARRAY_TEST14 = new PointF[] { new Point { X = cot, Y = hang }, new Point { X = cot + 50, Y = hang + 50 }, new Point { X = cot - 50, Y = hang - 50 } };
                    }
                    if ((rgb >= down_gray) && (rgb <= up_gray) && (cot >= 3*anhtam.Width / 4) && (cot < anhtam.Width) && (hang >= anhtam.Height / 2) && (hang < 3 * anhtam.Height / 4))
                    {
                        ARRAY_TEST15 = new PointF[] { new Point { X = cot, Y = hang }, new Point { X = cot + 50, Y = hang + 50 }, new Point { X = cot - 50, Y = hang - 50 } };
                    }
                    if ((rgb >= down_gray) && (rgb <= up_gray) && (cot >= 3*anhtam.Width / 4) && (cot < anhtam.Width) && (hang >= 3 * anhtam.Height / 4) && (hang < anhtam.Height))
                    {
                        ARRAY_TEST16 = new PointF[] { new Point { X = cot, Y = hang }, new Point { X = cot + 50, Y = hang + 50 }, new Point { X = cot - 50, Y = hang - 50 } };
                    }

                }
            Image<Bgr, byte> bmp_original = new Image<Bgr, byte>(anhtam);
            CircleF CR1 = CvInvoke.MinEnclosingCircle(ARRAY_TEST1);
            CircleF CR2 = CvInvoke.MinEnclosingCircle(ARRAY_TEST2);
            CircleF CR3 = CvInvoke.MinEnclosingCircle(ARRAY_TEST3);
            CircleF CR4 = CvInvoke.MinEnclosingCircle(ARRAY_TEST4);
            CircleF CR5 = CvInvoke.MinEnclosingCircle(ARRAY_TEST5);
            CircleF CR6 = CvInvoke.MinEnclosingCircle(ARRAY_TEST6);
            CircleF CR7 = CvInvoke.MinEnclosingCircle(ARRAY_TEST7);
            CircleF CR8 = CvInvoke.MinEnclosingCircle(ARRAY_TEST8);
            CircleF CR9 = CvInvoke.MinEnclosingCircle(ARRAY_TEST9);
            CircleF CR10 = CvInvoke.MinEnclosingCircle(ARRAY_TEST10);
            CircleF CR11 = CvInvoke.MinEnclosingCircle(ARRAY_TEST11);
            CircleF CR12 = CvInvoke.MinEnclosingCircle(ARRAY_TEST12);
            CircleF CR13 = CvInvoke.MinEnclosingCircle(ARRAY_TEST13);
            CircleF CR14 = CvInvoke.MinEnclosingCircle(ARRAY_TEST14);
            CircleF CR15 = CvInvoke.MinEnclosingCircle(ARRAY_TEST15);
            CircleF CR16 = CvInvoke.MinEnclosingCircle(ARRAY_TEST16);

            CvInvoke.Circle(bmp_original, new Point((int)CR1.Center.X, (int)CR1.Center.Y), (int)CR1.Radius, new Bgr(System.Drawing.Color.Red).MCvScalar, 1);
            CvInvoke.Circle(bmp_original, new Point((int)CR2.Center.X, (int)CR2.Center.Y), (int)CR2.Radius, new Bgr(System.Drawing.Color.Red).MCvScalar, 1);
            CvInvoke.Circle(bmp_original, new Point((int)CR3.Center.X, (int)CR3.Center.Y), (int)CR3.Radius, new Bgr(System.Drawing.Color.Red).MCvScalar, 1);
            CvInvoke.Circle(bmp_original, new Point((int)CR4.Center.X, (int)CR4.Center.Y), (int)CR4.Radius, new Bgr(System.Drawing.Color.Red).MCvScalar, 1);
            CvInvoke.Circle(bmp_original, new Point((int)CR5.Center.X, (int)CR5.Center.Y), (int)CR5.Radius, new Bgr(System.Drawing.Color.Red).MCvScalar, 1);
            CvInvoke.Circle(bmp_original, new Point((int)CR6.Center.X, (int)CR6.Center.Y), (int)CR6.Radius, new Bgr(System.Drawing.Color.Red).MCvScalar, 1);
            CvInvoke.Circle(bmp_original, new Point((int)CR7.Center.X, (int)CR7.Center.Y), (int)CR7.Radius, new Bgr(System.Drawing.Color.Red).MCvScalar, 1);
            CvInvoke.Circle(bmp_original, new Point((int)CR8.Center.X, (int)CR8.Center.Y), (int)CR8.Radius, new Bgr(System.Drawing.Color.Red).MCvScalar, 1);
            CvInvoke.Circle(bmp_original, new Point((int)CR9.Center.X, (int)CR9.Center.Y), (int)CR9.Radius, new Bgr(System.Drawing.Color.Red).MCvScalar, 1);
            CvInvoke.Circle(bmp_original, new Point((int)CR10.Center.X, (int)CR10.Center.Y), (int)CR10.Radius, new Bgr(System.Drawing.Color.Red).MCvScalar, 1);
            CvInvoke.Circle(bmp_original, new Point((int)CR11.Center.X, (int)CR11.Center.Y), (int)CR11.Radius, new Bgr(System.Drawing.Color.Red).MCvScalar, 1);
            CvInvoke.Circle(bmp_original, new Point((int)CR12.Center.X, (int)CR12.Center.Y), (int)CR12.Radius, new Bgr(System.Drawing.Color.Red).MCvScalar, 1);
            CvInvoke.Circle(bmp_original, new Point((int)CR13.Center.X, (int)CR13.Center.Y), (int)CR13.Radius, new Bgr(System.Drawing.Color.Red).MCvScalar, 1);
            CvInvoke.Circle(bmp_original, new Point((int)CR14.Center.X, (int)CR14.Center.Y), (int)CR14.Radius, new Bgr(System.Drawing.Color.Red).MCvScalar, 1);
            CvInvoke.Circle(bmp_original, new Point((int)CR15.Center.X, (int)CR15.Center.Y), (int)CR15.Radius, new Bgr(System.Drawing.Color.Red).MCvScalar, 1);
            CvInvoke.Circle(bmp_original, new Point((int)CR16.Center.X, (int)CR16.Center.Y), (int)CR16.Radius, new Bgr(System.Drawing.Color.Red).MCvScalar, 1);
            kq = bmp_original.Bitmap;


            return kq;
        }
        // D8 ROI
        public Bitmap ROI(Bitmap draw_area)
        {
            Bitmap kq = new Bitmap(draw_area.Width, draw_area.Height);
            Bitmap anhtam = new Bitmap(draw_area);
            Color c;
            Byte rgb;
            List<Point> pointList = new List<Point>();
            Point[] pointArray = pointList.ToArray();
            int up_gray = 150;
            int down_gray = 120;




            for (int cot = 0; cot < anhtam.Width; cot++)
                for (int hang = 0; hang < anhtam.Height; hang++)
                {
                    c = anhtam.GetPixel(cot, hang);

                    rgb = (byte)(.299 * c.R + .587 * c.G + .114 * c.B);

                    up_gray = int.Parse(textBox12.Text);
                    down_gray = int.Parse(textBox13.Text);

                    if ((rgb > down_gray) && (rgb < up_gray))
                    {

                        //for (int i = hang; i < hang + 5; hang++)
                        kq.SetPixel(cot, hang, Color.Red);
                        //for (int j = cot; j < cot + 5; cot++)
                        // kq.SetPixel(j, hang+5, Color.Red);


                    }

                    else
                        kq.SetPixel(cot, hang, Color.FromArgb(c.R, c.G, c.B));

                }
            return kq;
        }
        // D9 show image in picturebox1
        private void picture1_show(Bitmap Image_in)
        {
            // Bitmap Image_in;
            pictureBox1.Image = Image_in;
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;


        }
        // D10 resize image
        public Image resizeImage(Image img, int width, int height)
        {
            Bitmap b = new Bitmap(width, height);
            Graphics g = Graphics.FromImage((Image)b);
            g.DrawImage(img, 0, 0, width, height);
            g.Dispose();

            return (Image)b;
        }
        //######### END ##### D SESSION IMAGE PROCESSING FUNCTION #################################################################



        //********* START***** E SESSION IMAGE PROCESSING BUTTON ********************************************************************
        // E1. LOAD IMAGE
        public void button34_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog();
            //result.title = "Select an image file.";
            //result.Filter = "Png Images(*.png)|*.png|Jpeg Images(*.jpg)|*.jpg";
           // result.Filter += "|Bitmap Images(*.bmp)|*.bmp";
            if (result == DialogResult.OK)
            {
                // Lấy hình ảnh
                Bitmap img = new Bitmap(Image.FromFile(openFileDialog1.FileName));

                // Gán ảnh
                
                img = new Bitmap(resizeImage(img, pictureBox1.Width, pictureBox1.Height));
                original_image = img;
                bmp = img;
                picture1_show(bmp);

                // pictureBox1.Image = img;
                // pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            textBox12.Text = "150";
            textBox13.Text = "120";
        }
        // E2. SAVE IMAGE
        private void button43_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                bmp.Save(saveFileDialog1.FileName + ".png");
            }
        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        // E3. BRIGHTNESS ADJUSTMENT
        public void trackBar1_Scroll(object sender, EventArgs e)
        {

            Bitmap bmp_adjust;
            bmp_adjust = AdjustBrightness((Bitmap)bmp, trackBar1.Value);
            picture1_show(bmp_adjust);
            //bmp = bmp_adjust;


        }
        // E4. Grayscale
        private void button40_Click(object sender, EventArgs e)
        {
            Bitmap bmp_gray;
            bmp_gray = DenTrang(bmp);
            picture1_show(bmp_gray);
            bmp = bmp_gray;
        }
        // E5 DRAWING
        private void button41_Click(object sender, EventArgs e)
        {
          Bitmap bmp_draw;
            bmp_draw = Draw(bmp);
            bmp = bmp_draw;
            picture1_show(bmp_draw);
            picture1_show(bmp);
           //nt leftWhiteCount;

            // NOTE*******************************DRAFT DRAWING*********************************
          //Image<Bgr, Byte> input_img = new Image<Bgr, byte>(bmp);  // source image
          //Image<Bgr, Byte> mark_temp = new Image<Bgr, Byte>(bmp);
            //input_img.ROI = new Rectangle(50, 200, 20, 30);
         // input_img.ROI = new Rectangle(0, 0, input_img.Width / 3, input_img.Height);
            //Invoke.Normalize.
           //eftWhiteCount = input_img.ROI.
          //label27.Text = leftWhiteCount.ToString();
            // Image<Gray, Byte> mask = mark_temp.Convert<Gray, Byte>();
            //CvInvoke.Circle(mark_temp, new Point(200, 200), (int)50, new Bgr(System.Drawing.Color.Red).MCvScalar, 1);
            //CvInvoke.Rectangle(mark_temp, new Rectangle(new Point(300, 160), new Size(12, 20)), new Bgr(System.Drawing.Color.Red).MCvScalar, 1);
            //CvInvoke.Circle(mark_temp, new Point(100, 100), (int)5, new Bgr(System.Drawing.Color.White).MCvScalar, -1);
            //bmp_cv = input_img.And(input_img, mask);
            //bmp = mark_temp.Bitmap;
           //icture1_show(bmp);
        }

    
        // E6 ROI
        private void button42_Click(object sender, EventArgs e)
        {

            Bitmap bmp_ROI;
            bmp_ROI = ROI(bmp);
            picture1_show(bmp_ROI);
            bmp = bmp_ROI;
        }
        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            textBox12.Text = trackBar2.Value.ToString();
            Bitmap bmp_ROI;
            bmp_ROI = ROI(bmp);
            picture1_show(bmp_ROI);

        }

        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            textBox13.Text = trackBar3.Value.ToString();
        }
        // E7 SOBEL
        private void button42_Click_1(object sender, EventArgs e)
        {
            Bitmap bmp_sobel;
            bmp_sobel = SobelEdgeDetect(bmp);
            picture1_show(bmp);
            bmp = bmp_sobel;
        }
        // E8 BLOCK

        private void button44_Click(object sender, EventArgs e)
        {
            Bitmap bmp_block;
            bmp_block = Block(bmp);
            bmp = bmp_block;
            picture1_show(bmp_block);
        }
        // E9 HistogramEqualization
        private void button45_Click(object sender, EventArgs e)
        {
            Bitmap bmp_histogramEqualization;
            bmp_histogramEqualization = histogramEqualization(bmp);
            bmp = bmp_histogramEqualization;
            picture1_show(bmp_histogramEqualization);
        }
        // E10 Convolution
        private void button46_Click(object sender, EventArgs e)
        {
            int[,] kernel = {
            { -2, -1,  0 },
            { -1,  1,  1 },
            {  0,  1,  2 } };
            // create filter
            Convolution filter = new Convolution(kernel);
            // apply the filter
            Bitmap bmp_covolution = new Bitmap(bmp);
            filter.ApplyInPlace(bmp_covolution);
            picture1_show(bmp_covolution);
            bmp = bmp_covolution;

        }

        private void button48_Click(object sender, EventArgs e)
        {
            bmp_cv = new Image<Gray, byte>(bmp);
            Image<Gray, byte> bmp_binary = bmp_cv.Convert<Gray, byte>().ThresholdBinary(new Gray(150), new Gray(255));
            VectorOfVectorOfPoint contours = new VectorOfVectorOfPoint();
            Mat hier = new Mat();
            CvInvoke.FindContours(bmp_binary, contours, hier, Emgu.CV.CvEnum.RetrType.External, Emgu.CV.CvEnum.ChainApproxMethod.ChainApproxSimple);
            if (contours.Size > 0)
            {
                for (int i = 0; i < 10; i++)
                {
                    Rectangle rect = CvInvoke.BoundingRectangle(contours[i]);
                    bmp_cv.ROI = rect;
                    bmp = bmp_binary.Copy().Bitmap;
                    this.Invalidate();
                    // await Task.Delay(500);
                }
            }
            picture1_show(bmp);

        }

        private void button49_Click(object sender, EventArgs e)
        {
            bmp_cv = new Image<Gray, byte>(bmp);
            bmp = bmp_cv.Canny(130,170).Bitmap;
            picture1_show(bmp);
        }

        private void button50_Click(object sender, EventArgs e)
        {
            bmp_cv = new Image<Gray, byte>(bmp);
            
            bmp = bmp_cv.Dilate(10).Bitmap;
            picture1_show(bmp);
        }

        private void button51_Click(object sender, EventArgs e)
        {
            bmp_cv = new Image<Gray, byte>(bmp);
           
            bmp = bmp_cv.Erode(20).Bitmap;
            //bmp = bmp_cv.Bitmap;
            picture1_show(bmp);

        }

        private void button52_Click(object sender, EventArgs e)
        {
            bmp_cv = new Image<Gray, byte>(bmp);
           
            bmp = bmp_cv.Laplace(3).Bitmap;
            picture1_show(bmp);
        }

        private void button53_Click(object sender, EventArgs e)
        {
            bmp_cv = new Image<Gray, byte>(bmp);
            
            bmp = bmp_cv.SmoothBlur(3, 3).Bitmap;
            picture1_show(bmp);
        }

        private void button54_Click(object sender, EventArgs e)
        {
            bmp_cv = new Image<Gray, byte>(bmp);
            
            bmp = bmp_cv.SmoothMedian(3).Bitmap;
            picture1_show(bmp);
        }

        private void button55_Click(object sender, EventArgs e)
        {
            bmp_cv = new Image<Gray, byte>(bmp);
            bmp=bmp_cv.SmoothGaussian(3).Bitmap;
            
            picture1_show(bmp);
        }

        private void button56_Click(object sender, EventArgs e)
        {
            bmp_cv = new Image<Gray, byte>(bmp);
            bmp=bmp_cv.SmoothBilatral(7, 75, 75).Bitmap;
            //bmp_cv.SmoothBilatral()
           
            picture1_show(bmp);

        }

        private void button60_Click(object sender, EventArgs e)
        {


            bmp_cv = new Image<Gray, byte>(bmp);
            //bmp=bmp_cv.MorphologyEx()

            //picture1_show(bmp);
            Image<Bgr, Byte> input_img = new Image<Bgr, byte>(bmp);  // source image
            Image<Bgr, Byte> mark_temp = new Image<Bgr, Byte>(bmp.Width, bmp.Height, new Bgr(0, 0, 0));
            Image<Gray, Byte> mask = mark_temp.Convert<Gray, Byte>();
            CvInvoke.Circle(mask, new Point(100,100), (int)5, new Bgr(System.Drawing.Color.White).MCvScalar, -1);
            //bmp_cv = input_img.And(input_img, mask);
            bmp = mask.Bitmap;
            


        }

        private void button59_Click(object sender, EventArgs e)
        {
              bmp_cv = new Image<Gray, byte>(bmp);
            

            SobelEdgeDetector filter = new SobelEdgeDetector();
           
            bmp = bmp_cv.SmoothGaussian(1).Bitmap;
            filter.ApplyInPlace(bmp);
            picture1_show(bmp);
        }

        private void button58_Click(object sender, EventArgs e)
        {
            //bmp = DenTrang(bmp);
            bmp_cv = new Image<Gray, byte>(bmp);
            Image<Gray, byte> grayImg = bmp_cv.Convert<Gray, byte>();
            Image<Gray, byte> binImg = new Image<Gray, byte>(grayImg.Size);
            OtsuThreshold filter = new OtsuThreshold();
            bmp = bmp_cv.SmoothGaussian(3).Bitmap;
            filter.ApplyInPlace(bmp);
            picture1_show(bmp);
            
              
        }
        private void button47_Click(object sender, EventArgs e)
        {
            // create filter
            bmp_cv = new Image<Gray, byte>(bmp);

            Erosion filter = new Erosion();
            bmp = bmp_cv.SmoothGaussian(1).Bitmap;
            filter.ApplyInPlace(bmp);
            picture1_show(bmp);
            // apply the filter
            //filter.Apply(bmp);
            //picture1_show(bmp);

        }
        private void button57_Click(object sender, EventArgs e)
        {
            bmp_cv = new Image<Gray, byte>(bmp);
            bmp_cv = bmp_cv.Convert<Gray, byte>();
            Image<Gray, Single> img_final = (bmp_cv.Sobel(1, 0, 1));
            bmp = img_final.ToBitmap();
            picture1_show(bmp);
            

            // create complex image
            /*ComplexImag img = 
            ComplexImage complexImage = ComplexImage.FromBitmap(bmp);
            // do forward Fourier transformation
            complexImage.ForwardFourierTransform();
            // create filter
            FrequencyFilter filter = new FrequencyFilter(new IntRange(20, 128));
            // apply filter
            filter.Apply(complexImage);
            // do backward Fourier transformation
            complexImage.BackwardFourierTransform();
            // get complex image as bitmat
            Bitmap fourierImage = complexImage.ToBitmap();*/
        }
        //###### END #### E session #####################################################

        //*****Start*************F session calculation***********************************
        public void textBox3_TextChanged(object sender, EventArgs e)
        {

            if (System.Text.RegularExpressions.Regex.IsMatch(textBox3.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only numbers.");
                textBox3.Text = textBox3.Text.Remove(textBox3.Text.Length - 1);
            }
        }

        public void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(textBox1.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only numbers.");
                textBox1.Text = textBox1.Text.Remove(textBox1.Text.Length - 1);
            }
        }

        public void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(textBox2.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only numbers.");
                textBox2.Text = textBox2.Text.Remove(textBox2.Text.Length - 1);
            }
        }

        public void textBox4_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(textBox2.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only numbers.");
                textBox2.Text = textBox2.Text.Remove(textBox2.Text.Length - 1);
            }
        }

        private void button38_Click(object sender, EventArgs e)
        {
            if (int.Parse(textBox1.Text) >= 3)

            {
                MessageBox.Show("Thanh phan C lon hon bang 3");
            }
            else
            {
                MessageBox.Show("thanh phan C nho hon 3");
            }
        }


        private void button39_Click(object sender, EventArgs e)
        {
            int j;
            j = int.Parse(textBox1.Text) + int.Parse(textBox2.Text) + int.Parse(textBox3.Text) + int.Parse(textBox4.Text);
            //Console.WriteLine("Tong thanh phan C, O, SI", j);
            string s;
            s = j.ToString();
            textBox5.Text = s;

        }
        //######## End ######### F session calculation ##################################









            // Draft label and button

        public void button36_Click(object sender, EventArgs e)
        {

        }

        public void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {

        }

       

        public void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        public void menuStrip2_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        public void menuStrip1_ItemClicked_1(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        public void fontDialog1_Apply(object sender, EventArgs e)
        {

        }

        public void domainUpDown1_SelectedItemChanged(object sender, EventArgs e)
        {

        }


        private void label8_Click(object sender, EventArgs e)
        {

        }
      
        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

     
        private void label22_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void button61_Click(object sender, EventArgs e)
        {
            Bitmap bmp_adjust;
            bmp_adjust = AdjustBrightness((Bitmap)bmp, trackBar1.Value);
            picture1_show(bmp_adjust);
            bmp = bmp_adjust;
            // Convert a BGR image to HLS range
            //Emgu.CV.Image<Hls, Byte> imageHsi = new Image<Hls, Byte>(bmp);

            // Equalize the Intensity Channel
            //imageHsi[1]._EqualizeHist();

            // Convert the image back to BGR range
            //Emgu.CV.Image<Bgr, Byte> imageBgr = imageHsi.Convert<Bgr, Byte>();
            // bmp = imageBgr.Bitmap;
            //picture1_show(bmp);
            //bmp_cv = new Image<Gray, byte>(bmp);
            // Image<Gray, byte> grayImg = bmp_cv.Convert<Gray, byte>();
            // bmp_cv = bmp_cv._EqualizeHist();

        }

        private void button62_Click(object sender, EventArgs e)
        {
            bmp = original_image;
            picture1_show(bmp);
        }

        private void button63_Click(object sender, EventArgs e)
        {
            bmp_cv = new Image<Gray, byte>(bmp);
            Image<Gray, byte> bmp_original = new Image<Gray, byte>(original_image);
            //bmp =bmp_cv.Laplace(3).Bitmap;
         

             
            CvInvoke.Subtract(bmp_original, bmp_cv,bmp_original);
            
            bmp = bmp_original.Bitmap;


            picture1_show(bmp);
          
        }

        private void button64_Click(object sender, EventArgs e)
        {
            bmp_cv = new Image<Gray, byte>(bmp);
            Image<Gray, byte> bmp_original = new Image<Gray, byte>(original_image);


            CvInvoke.Add(bmp_original, bmp_cv, bmp_original);

            bmp = bmp_original.Bitmap;

           // CvInvoke.EqualizeHist(bmp_cv, bmp_cv);
            picture1_show(bmp);

        }

        private void button65_Click(object sender, EventArgs e)
        {
            bmp_cv = new Image<Gray, byte>(bmp);
            Image<Gray, byte> bmp_original = new Image<Gray, byte>(original_image);
            CvInvoke.EqualizeHist(bmp_cv, bmp_cv);
            bmp = bmp_cv.Bitmap;
            picture1_show(bmp);


        }

        private void button66_Click(object sender, EventArgs e)
        {
            Image<Bgr, byte> img_color = new Image<Bgr, byte>(bmp);
            Image<Gray, byte> img_grayscale = new Image<Gray, byte>(bmp);
            histogramBox1.ClearHistogram();
            histogramBox1.GenerateHistograms(img_grayscale, 1024);
            histogramBox1.Refresh();
            histogramBox2.ClearHistogram();
            histogramBox2.GenerateHistograms(img_color, 1024);
            histogramBox2.Refresh();



        }

        private void button67_Click(object sender, EventArgs e)
        {
            

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void histogramBox2_Load(object sender, EventArgs e)
        {

        }
    }
}



 
    
    


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laba3Gr_1
{
    public partial class Form1 : Form
    {
        int x1 = 100;
        int y1 = 100;
        int x2 = 300;
        int y2 = 300;
        int x3 = 100;
        int y3 = 300;

        UInt32 a = 0xFF0000;
        UInt32 b = 0x00FF00;
        UInt32 c = 0x0000FF;

        Bitmap image;

        public Form1()
        {
            InitializeComponent();

            
        }

        public void Raster()
        {
            for (int y = 0; y < pictureBox1.Height; y++)
                for (int x = 0; x < pictureBox1.Width; x++)
                    image.SetPixel(x, y, Color.FromArgb((int)ShadeBackgroundPixel(x, y)));
        }

        UInt32 ShadeBackgroundPixel(int x, int y)
        {
            UInt32 pixelValue; //цвет пикселя с координатами (x, y)

            double l1, l2, l3;
            pixelValue = 0xFFFFFFFF; //присваиваем цвет фона - белый
            
               l1 = ((y2 - y3) * ((double)(x) - x3) + (x3 - x2) * ((double)(y) - y3)) /
                    ((y2 - y3) * (x1 - x3) + (x3 - x2) * (y1 - y3));
               l2 = ((y3 - y1) * ((double)(x) - x3) + (x1 - x3) * ((double)(y) - y3)) /
                    ((y2 - y3) * (x1 - x3) + (x3 - x2) * (y1 - y3));
               l3 = 1 - l1 - l2;
               if (l1 >= 0 && l1 <= 1 && l2 >= 0 && l2 <= 1 && l3 >= 0 && l3 <= 1)
               {
                   pixelValue = (UInt32)0xFF000000 |
                       ((UInt32)(l1 * ((a & 0x00FF0000) >> 16) + l2 * ((b & 0x00FF0000) >> 16) + l3 * ((c & 0x00FF0000) >> 16)) << 16) |
                       ((UInt32)(l1 * ((a & 0x0000FF00) >> 8) + l2 * ((b & 0x0000FF00) >> 8) + l3 * ((c & 0x0000FF00) >> 8)) << 8) |
                       (UInt32)(l1 * (a & 0x000000FF) + l2 * (b & 0x000000FF) + l3 * (c & 0x000000FF));
               }
            

            return pixelValue;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        int clck = 0;

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (clck == 0)
            {
                x1 = e.Location.X;
                y1 = e.Location.Y;
                clck++;
            }
            else if (clck == 1)
            {
                x2 = e.Location.X;
                y2 = e.Location.Y;
                clck++;
            }
            else if (clck == 2)
            {
                x3 = e.Location.X;
                y3 = e.Location.Y;
                clck++;
            }
            else
                clck = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            Raster();
            pictureBox1.Image = image;
        }
    }
}

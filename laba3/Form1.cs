using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace laba3
{
    public partial class Form1 : Form
    {
        private int x1, y1, x2, y2;
        Graphics g;
        Bitmap pt;
        Color c;
        int R, G, B;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            x1 = Int32.Parse(textBox1.Text);
            y1 = Int32.Parse(textBox2.Text);
            x2 = Int32.Parse(textBox3.Text);
            y2 = Int32.Parse(textBox4.Text);

            textBox1.Dispose();
            textBox2.Dispose();
            textBox3.Dispose();
            textBox4.Dispose();

            label1.Dispose();
            label2.Dispose();
            label3.Dispose();
            label4.Dispose();

            button1.Dispose();

            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Size = this.Size;

            BresenhamAlgorithm(x1, y1, x2, y2);
            ByAlgorithm(x1, y1, x2, y2);
        }

        //целочисленный алгоритм Брезенхема
        private void BresenhamAlgorithm(int x1,int y1,int x2,int y2)
        {
            pt = new Bitmap(1, 1);
            pt.SetPixel(0, 0, Color.Black);
            g = pictureBox1.CreateGraphics();

            var dy = Math.Abs(y2 - y1);
            var dx = Math.Abs(x2 - x1);
            if (dy <= dx)
            {
                var d = 2 * dy - dx;
                //int ynext = y1;
                if(y1<y2)
                {
                    g.DrawImageUnscaled(pt, x1, y1);
                    int y = y1;
                    //int x = x1;
                    for (int x = x1 + 1; x <= x2; x++)
                    {
                        if (d > 0)
                        {
                            y++;
                            d = d + 2 * (dy - dx);
                        }
                        else
                            d = d + 2 * dy;
                        g.DrawImageUnscaled(pt, x, y);

                        //x = xnext;
                        //y = ynext;
                    }
                }
                else
                {
                    g.DrawImageUnscaled(pt, x2, y2);
                    int y = y2;
                    //int x = x1;
                    for (int x = x2 - 1; x >= x1; x--)
                    {
                        if (d > 0)
                        {
                            y++;
                            d = d + 2 * (dy - dx);
                        }
                        else
                            d = d + 2 * dy;
                        g.DrawImageUnscaled(pt, x, y);

                        //x = xnext;
                        //y = ynext;
                    }
                }
            }
            else
            {
                var d = 2 * dx - dy;

                //int xnext = x1;
                //int x = x1;
                if(y1<y2)
                {
                    int x = x1;
                    g.DrawImageUnscaled(pt, x1, y1);
                    //int y = y1;
                    for (int y = y1 + 1; y <= y2; y++)
                    {
                        if (d > 0)
                        {
                            x++;
                            d = d + 2 * (dx - dy);
                        }
                        else
                            d = d + 2 * dx;
                        g.DrawImageUnscaled(pt, x, y);

                        //x = xnext;
                        //y = ynext;
                    }
                }
                else
                {
                    int x = x2;
                    g.DrawImageUnscaled(pt, x2, y2);
                    //int y = y2;
                    for (int y = y2 + 1; y <= y1; y++)
                    {
                        if (d > 0)
                        {
                            x--;
                            d = d + 2 * (dx - dy);
                        }
                        else
                            d = d + 2 * dx;
                        g.DrawImageUnscaled(pt, x, y);

                        //x = xnext;
                        //y = ynext;
                    }
                }
            }
        }

        //алгоритм ВУ
        private void ByAlgorithm(float x1, float y1, float x2, float y2)
        {
            x1 = x1 + 350;
            x2 = x2 + 350;
            pt = new Bitmap(this.Width, this.Height);
            c = Color.Black;
            pt.SetPixel(0, 0, c);
            g = pictureBox1.CreateGraphics();
            var deltax = Math.Abs(x2 - x1);
            var deltay = Math.Abs(y2 - y1);
            float dx = x2 - x1;
            float dy = y2 - y1;
            float gradient = dy / dx;
            if (deltay <= deltax)
            {
                if (y1 < y2)
                {
                    pt.SetPixel((int)x1, (int)y1, c);
                    g.DrawImageUnscaled(pt, (int)x1, (int)y1);
                    float y = y1+gradient;
                    for (var x = x1 + 1; x <= x2 - 1; x++)
                    {
                        Color c2 = Color.FromArgb((int)(c.A - (y-(int)y)), c.R, c.G, c.B);
                        pt.SetPixel((int)x, (int)y, c2);
                        g.DrawImageUnscaled(pt, (int)x, (int)y);

                        c2 = Color.FromArgb((int)(y - (int)y), c.R, c.G, c.B);
                        pt.SetPixel((int)x, (int)(y + 1), c2);
                        g.DrawImageUnscaled(pt, (int)x, (int)(y+1));

                        y = y + gradient;
                    }
                    pt.SetPixel((int)x2, (int)y2, c);
                    g.DrawImageUnscaled(pt, (int)x2, (int)y2);
                }
                else
                {
                    pt.SetPixel((int)x1, (int)y1, c);
                    g.DrawImageUnscaled(pt, (int)x1, (int)y1);
                    float y = y1+gradient;
                    for (var x = x1 + 1; x <= x2 - 1; x++)
                    {
                        Color c2 = Color.FromArgb((int)(c.A - (y - (int)y)), c.R, c.G, c.B);
                        pt.SetPixel((int)x, (int)y, c2);
                        g.DrawImageUnscaled(pt, (int)x, (int)y);

                        c2 = Color.FromArgb((int)(y - (int)y), c.R, c.G, c.B);
                        pt.SetPixel((int)x, (int)(y - 1), c2);
                        g.DrawImageUnscaled(pt, (int)x, (int)(y-1));

                        y = y + gradient;

                    }
                    pt.SetPixel((int)x2, (int)y2, c);
                    g.DrawImageUnscaled(pt, (int)x2, (int)y2);
                }
            }
            else
            {
                if (y1 < y2)
                {
                    gradient = dx / dy;
                    pt.SetPixel((int)x1, (int)y1, c);
                    g.DrawImageUnscaled(pt, (int)x1, (int)y1);
                    float x = x1 + gradient;
                    for (var y = y1 + 1; y <= y2 - 1; y++)
                    {
                        Color c2 = Color.FromArgb((int)(c.A * (1- (x - (int)x))), c.R, c.G, c.B);
                        pt.SetPixel((int)x, (int)y, c2);
                        g.DrawImageUnscaled(pt, (int)x, (int)y);

                        c2 = Color.FromArgb((int)(x - (int)x), c.R, c.G, c.B);
                        pt.SetPixel((int)(x+1), (int)y, c2);
                        g.DrawImageUnscaled(pt, (int)(x+1), (int)y);

                        x = x + gradient;
                    }
                    pt.SetPixel((int)x2, (int)y2, c);
                    g.DrawImageUnscaled(pt, (int)x2, (int)y2);
                }
                else
                {
                    gradient = dx / dy;
                    pt.SetPixel((int)x2, (int)y2, c);
                    g.DrawImageUnscaled(pt, (int)x2, (int)y2);
                    float x = x2 + gradient;
                    for (var y = y2 + 1; y <= y1 - 1; y++)
                    {
                        Color c2 = Color.FromArgb((int)(c.A - (x - (int)x)), c.R, c.G, c.B);
                        pt.SetPixel((int)x, (int)y, c2);
                        g.DrawImageUnscaled(pt, (int)x, (int)y);

                        c2 = Color.FromArgb((int)(x - (int)x), c.R, c.G, c.B);
                        pt.SetPixel((int)(x - 1), (int)y, c2);
                        g.DrawImageUnscaled(pt, (int)(x - 1), (int)y);

                        x = x + gradient;
                    }
                    pt.SetPixel((int)x1, (int)y1, c);
                    g.DrawImageUnscaled(pt, (int)x1, (int)y1);
                }
            }
        }
    }
}

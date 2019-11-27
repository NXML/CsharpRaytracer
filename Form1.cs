using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Drawing
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        int map(int x, int in_min, int in_max, int out_min, int out_max)
        {
            return (x - in_min) * (out_max - out_min) / (in_max - in_min) + out_min;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            base.OnPaint(e);
            int h = panel1.Height;
            int w = panel1.Width;

            Bitmap myBitmap = new Bitmap(w, h);
            for (int x = 0; x < w; x++)
                for (int y = 0; y < h; y++)
                {

                    int r = map(x, 0, w, 0, 255);
                    int g = map(y, 0, h, 0, 255);
                    int b = 201;


                    myBitmap.SetPixel(x, y,Color.FromArgb(r,g,b));
            
                    //base.OnPaint(e);
                    
                }
            e.Graphics.DrawImage(myBitmap, 0, 0);
         
        }


        private void panel1_paint(object sender, EventArgs e)
        {

            panel1.Refresh();

        }
    }
}

using Drawing.Model;
using System;
using System.Drawing;
using System.Windows.Forms;
namespace Drawing
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();



        }





        /*Vars*/
        Vec3 lower_left_corner = new Vec3(-2, -1, -1);
        Vec3 horizontal = new Vec3(4, 0, 0);
        Vec3 vertical = new Vec3(0, 2, 0);
        Vec3 origin = new Vec3(0, 0, 0);
        Sphere sphere = new Sphere(new Vec3(0, 0, -1), 0.5);
        Graphics graphics;








        private void Form1_Load(object sender, EventArgs e)
        {

        }


        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            base.OnPaint(e);
            Paint();

        }

        private new void Paint()
        {
            int height = panel1.Height;
            int width = panel1.Width;
            graphics = panel1.CreateGraphics();



            Bitmap myBitmap = new Bitmap(width, height);






            for (int x = 0; x < width; x++)
                for (int y = 0; y < height; y++)
                {

                    /*Start raycast*/
                    double u = Convert.ToDouble(x) / width;
                    double v = Convert.ToDouble(y) / height;

                    //cast the ray
                    Ray casted = new Ray(origin, lower_left_corner + (horizontal * u) + (vertical * v));



                    Vec3 c = oColor(casted).normalize();

                    int r = Convert.ToInt32(255 * c.x);
                    int g = Convert.ToInt32(255 * c.y);
                    int b = Convert.ToInt32(255 * c.z);


                    /*stop raycast*/


                    myBitmap.SetPixel(x, y, Color.FromArgb(r, g, b));


                }



            graphics.DrawImage(myBitmap, 0, 0);






        }

        Vec3 oColor(Ray r)
        {
            double t = sphere.is_hit(r);
            if (t > 0)
            {

                return new Vec3(1, 0, 0);
            }

            Vec3 unit_dir = r.dir.normalize();
            t = 0.5 * (unit_dir.y + 1);

            return new Vec3(1.0, 1.0, 1.0) * (1.0 - t) + new Vec3(0.5, 0.7, 1.0) * t;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            //capture up arrow key
            if (keyData == Keys.Up)
            {
                sphere.center.z -= 0.1;
            }
            //capture down arrow key
            if (keyData == Keys.Down)
            {
                sphere.center.z += 0.1;
            }
            //capture left arrow key
            if (keyData == Keys.Left)
            {
                sphere.center.x += 0.1;
            }
            //capture right arrow key
            if (keyData == Keys.Right)
            {
                sphere.center.x -= 0.1;
            }
            Paint();



            return base.ProcessCmdKey(ref msg, keyData);
        }









    }
}

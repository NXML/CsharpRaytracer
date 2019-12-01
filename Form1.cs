using Drawing.Model;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
namespace Drawing
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
             thread1 = new Thread(DoWork);


        }





        /*Vars*/
        Vec3 lower_left_corner = new Vec3(-2, -1, -0.5);
        Vec3 horizontal = new Vec3(4, 0, 0);
        Vec3 vertical = new Vec3(0, 2, 0);
        Vec3 origin = new Vec3(0, 0, 0);
        Hitable_List world = new Hitable_List();
        Graphics graphics;

        Sphere S1 = new Sphere(new Vec3(0, -10020, -1), 10000);
        Sphere S2 = new Sphere(new Vec3(0, 0, -2), 0.5);
        Thread thread1;











        private void Form1_Load(object sender, EventArgs e)
        {
          
            world.list.Add(S2);
            world.list.Add(S1);
           
            thread1.Start();


        }


        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            base.OnPaint(e);

            Paint();

        }

        private new void Paint()
        {
            graphics = panel1.CreateGraphics();
            int height = panel1.Height;
            int width = panel1.Width;

           



            Bitmap myBitmap = new Bitmap(width, height);

         




            for (int x = 0; x < width; x++)
                for (int y = 0; y < height; y++)
                {

                    /*Start raycast*/
                    double u = Convert.ToDouble(x) / width;
                    double v = Convert.ToDouble(y) / height;

                    //cast the ray
                    Ray casted = new Ray(origin, lower_left_corner + (horizontal * u) + (vertical * v));
                    Vec3 p = casted.point_at_parameter(2.0);


                    Vec3 c = oColor(casted,world).normalize();
                   

                    int r = Convert.ToInt32(255.99 * c.x);
                    int g = Convert.ToInt32(255.99 * c.y);
                    int b = Convert.ToInt32(255.99 * c.z);
                    r = Form1.Clamp(r, 0, 255);
                    g = Form1.Clamp(g, 0, 255);
                    b = Form1.Clamp(b, 0, 255);


                    /*stop raycast*/

                
                    myBitmap.SetPixel(x, Math.Abs(height - 1 - y), Color.FromArgb(r, g, b));

                  
                


                }
          



            graphics.DrawImage(myBitmap, 0, 0);





        }
       

        Vec3 oColor(Ray r,Hitable world)
        {
            Hit_Record rec = new Hit_Record();
            if (world.Hit(r, 0.0, float.MaxValue, rec))
            {
                //Debug.WriteLine(rec.normal.toString());
                return normal_to_color(rec.normal);
                //return 0.5 * new Vec3(rec.normal.x, rec.normal.y + 1, rec.normal.z+1);
                
            }
            else
            {
                Vec3 unit_dir = r.dir.normalize();
                double t = 0.5 * (unit_dir.y + 1);
               
                return (1-t)* new Vec3(1,1,1) + t*new Vec3(0.5,0.2,1);

            }



            
            
            
        }




        public  void DoWork()
        {
            while (true)
            {
                this.Paint();
             
            }
        }




        public Vec3 normal_to_color(Vec3 normal) {
            normal = normal.normalize();
            double r = ((normal.x + 1) / 2) * 255;
            double g = ((normal.y + 1) / 2) * 255;
            double b = ((normal.z + 1) / 2) * 255;
            return new Vec3(r, g, b);
        }







        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            thread1.Abort();
        }


        public static T Clamp<T>(T aValue, T aMin, T aMax) where T : IComparable<T>
        {
            var _Result = aValue;
            if (aValue.CompareTo(aMax) > 0)
                _Result = aMax;
            else if (aValue.CompareTo(aMin) < 0)
                _Result = aMin;
            return _Result;
        }
    }

    
}

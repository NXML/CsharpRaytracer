using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drawing.Model
{
    public class Vec3
    {
        public double x { get; set; }
        public double y { get; set; }
        public double z { get; set; }

        public Vec3(double x, double y , double z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }
        public double length() {
            return Math.Sqrt(x*x +y* y + z*z);
        }

        public static double dot(Vec3 v1 , Vec3 v2)
        {
            return v1.x * v2.x + v1.y * v2.y + v1.z * v2.z;
        }

        public  double dot(Vec3 v1)
        {
            return v1.x * this.x + v1.y * this.y + v1.z * this.z;
        }

        public static Vec3 operator +(Vec3 v1 , Vec3 v2)
        {
            return new Vec3(v1.x + v2.x, v1.y + v2.y, v1.z + v2.z);
        }
        public static Vec3 operator -(Vec3 v1, Vec3 v2)
        {
            return new Vec3(v1.x - v2.x, v1.y - v2.y, v1.z - v2.z);
        }

        public static Vec3 operator *(Vec3 v1, double nb)
        {
            return new Vec3(v1.x*nb,v1.y*nb ,v1.z*nb);
        }

        public static Vec3 operator *(double nb,Vec3 v1)
        {
            return new Vec3(v1.x * nb, v1.y * nb, v1.z * nb);
        }











        public static Vec3 operator /(Vec3 v1, double nb)
        {
            return new Vec3(v1.x / nb, v1.y / nb, v1.z / nb);
        }
        public Vec3 normalize()
        {
            double l = this.length();
            return new Vec3(this.x/l,this.y/l,this.z/l);
        }





    }
}

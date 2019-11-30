using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drawing.Model
{
    class Sphere
    {

        public Vec3 center;
        public double radius;
        public Sphere(Vec3 center, double r)
        {
            this.center = center;
            this.radius = r;
        }

        public double is_hit(Ray r)
        {
            Vec3 oc = r.origin - this.center;
            double a = r.dir.dot(r.dir);
            double b = oc.dot(r.dir) * 2.0;
            double c = oc.dot(oc) - this.radius * this.radius;
            double delta = (b * b) - 4 * a * c;
            if (delta < 0) return -1;
            return (-b - Math.Sqrt(delta)) / (2 * a);


        }
    }
}

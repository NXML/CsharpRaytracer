using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drawing.Model
{
    class Sphere : Hitable
    {

        public Vec3 center;
        public double radius;
        public Sphere(Vec3 center, double r)
        {
            this.center = center;
            this.radius = r;
            this.record = new Hit_Record();
        }

        public override bool Hit(Ray r, double t_min, double t_max, Hit_Record rec)
        {
           
            Vec3 oc = r.origin - this.center;
            double a = r.dir.dot(r.dir);
            double b = oc.dot(r.dir) * 2.0;
            double c = oc.dot(oc) - this.radius * this.radius;
            double delta = (b * b) - (a * c);
            if (delta >= 0)
            {
                double temp = (-b - Math.Sqrt(delta)) / a;
                if(temp < t_max && temp > t_min)
                {
                    rec.t = temp;
                    rec.p = r.point_at_parameter(rec.t);
                    rec.normal = (rec.p - this.center) / radius;

                    return true;
                }
                temp = (-b + Math.Sqrt(delta)) / a;
                if (temp < t_max && temp > t_min)
                {
                    rec.t = temp;
                    rec.p = r.point_at_parameter(rec.t);
                    rec.normal = (rec.p - center) / radius;
                    return true;
                }
            }
            return false;


        }

        
    }
}

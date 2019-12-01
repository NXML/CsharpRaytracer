using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drawing.Model
{
    class Hitable_List : Hitable
    {
        public List<Hitable> list = new List<Hitable>();
      
        public override bool Hit(Ray r, double t_min, double t_max, Hit_Record rec)
        {
            Hit_Record temp_rec = new Hit_Record();
            bool hit_anything = false;
            double closest_so_far = t_max;
            foreach (Hitable item in list)
            {
               
                if (item.Hit(r, t_min, closest_so_far, temp_rec))
                {
                    hit_anything = true;
                    closest_so_far = temp_rec.t;
               
                    rec.normal = new Vec3(temp_rec.normal.x,temp_rec.normal.y,temp_rec.normal.z);
                    rec.t=temp_rec.t;
                    rec.p = temp_rec.p;

                    //Debug.WriteLine(temp_rec.normal.toString());
                }
            }
           
            return hit_anything;
        }
    }
}

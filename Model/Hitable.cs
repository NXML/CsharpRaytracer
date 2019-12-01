using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drawing.Model
{
    public abstract class Hitable
    {
        public abstract bool Hit(Ray r, double t_min, double t_max, Hit_Record rec);

        public Hit_Record record;

    }

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drawing.Model
{
    class Camera
    {
        public  int antialiasing_factor = 10;
        
        
        public Vec3 horizontal = new Vec3(4, 0, 0);
        public Vec3 vertical = new Vec3(0, 2, 0);
        
        
        public Vec3 origin = new Vec3(0, 0, 0);
        public Vec3 lower_left_corner = new Vec3(-2, -1, -0.5);

        public Ray getRay(double u, double v)
        {
            return new Ray(origin, lower_left_corner + (horizontal * u) + (vertical * v));
        }

    }
}

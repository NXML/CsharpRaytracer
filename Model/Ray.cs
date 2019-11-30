namespace Drawing.Model
{
    internal class Ray
    {
        public Vec3 origin;
        public Vec3 dir;

        public Ray(Vec3 origin, Vec3 dir)
        {
            this.origin = origin;
            this.dir = dir;
        }

        public Vec3 point_at_parameter(double t)
        {
            return origin + (dir * t);
        }
    }
}
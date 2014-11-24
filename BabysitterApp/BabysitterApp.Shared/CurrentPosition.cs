namespace BabysitterApp
{
    using System;

    public class CurrentPosition
    {
        private double x;
        private double y;
        private double z;

        public CurrentPosition(double p1, double p2, double p3)
        {
            this.x = p1;
            this.y = p2;
            this.z = p3;
        }

        public double X
        {
            get { return x; }
            set { x = value; }
        }

        public double Y
        {
            get { return y; }
            set { y = value; }
        }

        public double Z
        {
            get { return z; }
            set { z = value; }
        }
        
    }
}

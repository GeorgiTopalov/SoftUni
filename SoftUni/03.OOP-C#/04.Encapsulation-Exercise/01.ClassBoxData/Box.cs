using System;
using System.Collections.Generic;
using System.Text;

namespace ClassBoxData
{

    public class Box
    {
        private double length;
        private double width;
        private double heigth;

        public Box(double length, double width, double heigth)
        {
            this.Length = length;
            this.Width = width;
            this.Heigth = heigth;
        }
        public double Length
        {
            get
            {
                return this.length;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException($"Length cannot be zero or negative.");
                }
                this.length = value;
            }
        }
        public double Width
        {
            get
            {
                return this.width;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException($"Width cannot be zero or negative.");
                }
                this.width = value;
            }
        }
        public double Heigth
        {
            get
            {
                return this.heigth;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException($"Heigth cannot be zero or negative.");
                }
                this.heigth = value;
            }
        }

        public double SurfaceArea()
        {
            double surfaceArea = 2 * (Length * Width + Length * Heigth + Width * Heigth);
            return surfaceArea;
        }
        public double LateralSurfaceArea()
        {
            double lateralSurfaceArea = 2 * (Length + Width) * Heigth;
            return lateralSurfaceArea;
        }
        public double Volume()
        {
            double volume = Length * Width * Heigth;
            return volume;
        }
    }
}

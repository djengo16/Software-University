using System;
using System.Collections.Generic;
using System.Text;

namespace Class_Box_Data
{
    public class Box
    {
        private double length;
        private double width;
        private double height;

        public Box(double length, double width, double height)
        {
            Length = length;
            Width = width;
            Height = height;
        }

        public double Length
        {
            get { return length; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Length cannot be zero or negative.");
                   
                }
                length = value;
            }
        }

        public double Width
        {
            get { return width; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Width cannot be zero or negative.");
                   
                }
                width = value;
            }
        }

        public double Height
        {
            get { return height; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Height cannot be zero or negative.");
                    
                }
                height = value;
            }
        }

                                                //        Volume = lwh
                                                //Lateral Surface Area = 2lh + 2wh
                                                //Surface Area = 2lw + 2lh + 2wh

        public double SurfaceAre()
        {
            double area = 0;

            area = 2 * length * width + 2 * length * height + 2 * width * height;

            return area;
        }

        public double LateralSurFaceArea()
        {
            double area = 0;

            area = 2 * length * height + 2 * width * height;

            return area;
        }

        public double Volume()
        {
            return length * width * height;
        }


    }
}

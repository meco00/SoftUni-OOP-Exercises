using System;
using System.Collections.Generic;
using System.Text;

namespace BoxData
{
    public class Box
    {
        private double length;
        private double width;
        private double height;


        public double Length 
        { get { return this.length; }
            private set
            {
                if (value<=0)
                {
                    throw new ArgumentException("Length cannot be zero or negative.");

                }


                this.length = value;
            }
                
        }

        public double Width
        {
            get { return this.width; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Width cannot be zero or negative.");

                }


                this.width = value;
            }

        }

        public double Height
        {
            get { return this.height; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Height cannot be zero or negative.");

                }


                this.height = value;
            }

        }

        public Box(double length,double width,double height)
        {
            this.Length = length;
            this.Width = width;
            this.Height = height;

        }


        public void CalculateSurfaceArea()
        {
            // 2lw + 2lh + 2wh
            double area = 2 * length * width + 2 * length * height + 2 * width * height;

            Console.WriteLine($"Surface Area - {area:f2}");



        }

        public void CalculateLateralArea()
        {
            //2lh + 2wh

            double lateralArea = 2 * length * height+2*width*height;

            Console.WriteLine($"Lateral Surface Area - {lateralArea:f2}");
        }

        public void CalculateVolume()
        {
            double volume = length * width * height;

            Console.WriteLine($"Volume - {volume:f2}");
        }

        public void Calculations()
        {
            CalculateSurfaceArea();
            CalculateLateralArea();
            CalculateVolume();

        }


    }
}

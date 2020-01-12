using System;

namespace Mars.Rover.Domain
{
    public class Size : ISize
    {
        public int Width { get; set; }

        public int Height { get; set; }

        public Size(int width, int height)
        {
            if (width <= 0)
                throw new Exception("Width must be greater than zero!");

            if(height <= 0)
                throw new Exception("Height must be greater than zero!");

            if(width == 1 && height == 1)
                throw new Exception("There is no space for move!");

            this.Width = width;
            this.Height = height;
        }
    }
}

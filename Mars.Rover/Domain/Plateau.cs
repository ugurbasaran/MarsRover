namespace Mars.Rover.Domain
{
    public class Plateau : IPlateau
    {
        public Size Size { get; set; } 

        public void SetSize(Size size)
        {
            this.Size = size;
        }

        public void SetSize(int width, int height)
        {
            this.Size = new Size(width, height);
        }
    }
}

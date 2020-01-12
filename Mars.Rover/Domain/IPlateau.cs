namespace Mars.Rover.Domain
{
    public interface IPlateau
    {
        Size Size { get; set; }

        void SetSize(int width, int height);
    }
}

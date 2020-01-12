namespace Mars.Rover.Domain
{
    public class Location : ILocation
    {
        public int LocationX { get; set; }

        public int LocationY { get; set; }

        public Location(int locationX, int locationY)
        {
            this.LocationX = locationX;
            this.LocationY = locationY;
        }
    }
}

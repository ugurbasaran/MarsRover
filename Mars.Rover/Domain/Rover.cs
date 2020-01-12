using Mars.Rover.Enum;

namespace Mars.Rover.Domain
{
    public class Rover : IRover
    {
        public Location Location { get; set; }

        public CompassDirection CompassDirection { get; set; }
    }
}

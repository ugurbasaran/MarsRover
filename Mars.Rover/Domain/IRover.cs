using Mars.Rover.Enum;

namespace Mars.Rover.Domain
{
    public interface IRover
    {
        Location Location { get; set; }

        CompassDirection CompassDirection { get; set; }
    }
}

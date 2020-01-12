using System;

namespace Mars.Rover.CommandMatch
{
    public class MoveIncreaseLocation : IEquatable<MoveIncreaseLocation>
    {
        public int IncreaseXLocation { get; set; }

        public int IncreaseYLocation { get; set; }

        public MoveIncreaseLocation(int increaseXLocation, int increaseYLocation)
        {
            IncreaseXLocation = increaseXLocation;
            IncreaseYLocation = increaseYLocation;
        }

        public bool Equals(MoveIncreaseLocation other)
        {
            return IncreaseXLocation == other.IncreaseXLocation && IncreaseYLocation == other.IncreaseYLocation;
        }
    }
}

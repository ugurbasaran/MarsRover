using Mars.Rover.Domain;
using Mars.Rover.Enum;
using System;

namespace Mars.Rover.CommandMatch
{
    public class MoveCommandMatch : CommandMatch<CompassDirection, MoveIncreaseLocation>
    {
        private static readonly Lazy<MoveCommandMatch> lazyInstance = new Lazy<MoveCommandMatch>(() => new MoveCommandMatch());

        public static MoveCommandMatch Instance => lazyInstance.Value;

        protected MoveCommandMatch()
        {
            CommandMatches.Add(CompassDirection.North, new MoveIncreaseLocation(0, 1));
            CommandMatches.Add(CompassDirection.East, new MoveIncreaseLocation(1, 0));
            CommandMatches.Add(CompassDirection.South, new MoveIncreaseLocation(0, -1));
            CommandMatches.Add(CompassDirection.West, new MoveIncreaseLocation(-1, 0));
        }
    }
}

using Mars.Rover.Enum;
using System;

namespace Mars.Rover.CommandMatch
{
    public class CompassDirectionCommandMatch : CommandMatch<string, CompassDirection>
    {
        private static readonly Lazy<CompassDirectionCommandMatch> lazyInstance = new Lazy<CompassDirectionCommandMatch>(() => new CompassDirectionCommandMatch());

        public static CompassDirectionCommandMatch Instance => lazyInstance.Value;

        private CompassDirectionCommandMatch()
        {
            CommandMatches.Add("N", CompassDirection.North);
            CommandMatches.Add("E", CompassDirection.East);
            CommandMatches.Add("S", CompassDirection.South);
            CommandMatches.Add("W", CompassDirection.West);
        }
    }
}

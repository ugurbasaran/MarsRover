using Mars.Rover.Domain;
using Mars.Rover.Enum;
using System;

namespace Mars.Rover.CommandMatch
{
    public class CompassDirectionTurnCommandMatch : CommandMatch<CompassDirectionTurn, CompassDirection>
    {
        private static readonly Lazy<CompassDirectionTurnCommandMatch> lazyInstance = new Lazy<CompassDirectionTurnCommandMatch>(() => new CompassDirectionTurnCommandMatch());

        public static CompassDirectionTurnCommandMatch Instance => lazyInstance.Value;

        protected CompassDirectionTurnCommandMatch()
        {
            CommandMatches.Add(new CompassDirectionTurn(CompassDirection.North, Turn.Left), CompassDirection.West);
            CommandMatches.Add(new CompassDirectionTurn(CompassDirection.North, Turn.Right), CompassDirection.East);

            CommandMatches.Add(new CompassDirectionTurn(CompassDirection.East, Turn.Left), CompassDirection.North);
            CommandMatches.Add(new CompassDirectionTurn(CompassDirection.East, Turn.Right), CompassDirection.South);

            CommandMatches.Add(new CompassDirectionTurn(CompassDirection.South, Turn.Left), CompassDirection.East);
            CommandMatches.Add(new CompassDirectionTurn(CompassDirection.South, Turn.Right), CompassDirection.West);

            CommandMatches.Add(new CompassDirectionTurn(CompassDirection.West, Turn.Left), CompassDirection.South);
            CommandMatches.Add(new CompassDirectionTurn(CompassDirection.West, Turn.Right), CompassDirection.North);
        }
    }
}

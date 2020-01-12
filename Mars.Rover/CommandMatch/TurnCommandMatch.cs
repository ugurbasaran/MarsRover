using Mars.Rover.CommandMatch;
using Mars.Rover.Enum;
using System;

namespace Mars.Rover.CommandMatch
{
    public class TurnCommandMatch : CommandMatch<string, Turn>
    {
        private static readonly Lazy<TurnCommandMatch> lazyInstance = new Lazy<TurnCommandMatch>(() => new TurnCommandMatch());

        public static TurnCommandMatch Instance => lazyInstance.Value;

        protected TurnCommandMatch()
        {
            CommandMatches.Add("L", Turn.Left);
            CommandMatches.Add("R", Turn.Right);
        }
    }
}

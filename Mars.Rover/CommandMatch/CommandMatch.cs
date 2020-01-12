using System;
using System.Collections.Generic;

namespace Mars.Rover.CommandMatch
{
    public abstract class CommandMatch<TKey, TTarget> : ICommandMatch<TKey, TTarget>
    {
        public Dictionary<TKey, TTarget> CommandMatches { get; set; } = new Dictionary<TKey, TTarget>();

        protected CommandMatch()
        {
        }

        public TTarget GetValue(TKey key)
        {
            return CommandMatches[key];
        }
    }
}

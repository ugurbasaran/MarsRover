using System.Collections.Generic;

namespace Mars.Rover.CommandMatch
{
    public interface ICommandMatch<TKey, TTarget>
    {
        Dictionary<TKey, TTarget> CommandMatches { get; set; }

        TTarget GetValue(TKey key);
    }
}

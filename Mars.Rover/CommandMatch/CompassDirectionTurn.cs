using Mars.Rover.Enum;
using System;

namespace Mars.Rover.CommandMatch
{
    public sealed class CompassDirectionTurn : IEquatable<CompassDirectionTurn>
    {
        public CompassDirection CompassDirection { get; set; }

        public Turn Move { get; set; }

        public CompassDirectionTurn(CompassDirection compassDireciton, Turn move)
        {
            CompassDirection = compassDireciton;
            Move = move;
        }

        public bool Equals(CompassDirectionTurn other)
        {
            return CompassDirection == other.CompassDirection && Move == other.Move;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof(CompassDirectionTurn)) return false;
            return Equals((CompassDirectionTurn)obj);
        }

        public override int GetHashCode()
        {
            return CompassDirection.GetHashCode() ^ Move.GetHashCode();
        }
    }
}

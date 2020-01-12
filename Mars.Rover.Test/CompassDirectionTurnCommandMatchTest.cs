using Mars.Rover.CommandMatch;
using Mars.Rover.Enum;
using NUnit.Framework;

namespace Mars.Rover.Test
{
    [TestFixture]
    public class CompassDirectionTurnCommandMatchTest
    {
        [TestCase(CompassDirection.North, Turn.Left, CompassDirection.West)]
        [TestCase(CompassDirection.North, Turn.Right, CompassDirection.East)]
        [TestCase(CompassDirection.East, Turn.Left, CompassDirection.North)]
        [TestCase(CompassDirection.East, Turn.Right, CompassDirection.South)]
        [TestCase(CompassDirection.South, Turn.Left, CompassDirection.East)]
        [TestCase(CompassDirection.South, Turn.Right, CompassDirection.West)]
        [TestCase(CompassDirection.West, Turn.Left, CompassDirection.South)]
        [TestCase(CompassDirection.West, Turn.Right, CompassDirection.North)]
        public void CompassDirectionTurnCommandMatch_Test(CompassDirection currentDirection, Turn turnCommand, CompassDirection nextDirection)
        {
            CompassDirection nextDirectionResult = CompassDirectionTurnCommandMatch.Instance.CommandMatches[new CompassDirectionTurn(currentDirection, turnCommand)];
            NUnit.Framework.Assert.AreEqual(nextDirection, nextDirectionResult);
        }
    }
}

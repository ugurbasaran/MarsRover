using Mars.Rover.CommandMatch;
using Mars.Rover.Enum;
using NUnit.Framework;

namespace Mars.Rover.Test
{
    [TestFixture]
    public class MoveCommandMatchTest
    {
        [TestCase(CompassDirection.North, 0, 1)]
        [TestCase(CompassDirection.East, 1, 0)]
        [TestCase(CompassDirection.South, 0, -1)]
        [TestCase(CompassDirection.West, -1, 0)]
        public void MoveCommandMatch_Test(CompassDirection compassDirection, int expectedIncreaseX, int expectedIncreaseY)
        {
            MoveIncreaseLocation moveIncreaseLocation = MoveCommandMatch.Instance.CommandMatches[compassDirection];
            NUnit.Framework.Assert.AreEqual(new MoveIncreaseLocation(expectedIncreaseX, expectedIncreaseY) , moveIncreaseLocation);
        }
    }
}

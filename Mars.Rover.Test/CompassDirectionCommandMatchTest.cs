using Mars.Rover.CommandMatch;
using Mars.Rover.Enum;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;

namespace Mars.Rover.Test
{
    [TestFixture]
    public class CompassDirectionCommandMatchTest
    {
        [TestCase("N", CompassDirection.North)]
        [TestCase("E", CompassDirection.East)]
        [TestCase("S", CompassDirection.South)]
        [TestCase("W", CompassDirection.West)]
        public void CompassDirectionCommandMatch_Test(string commandChar, CompassDirection compassDirection)
        {
            CompassDirection compassDirectionResult = CompassDirectionCommandMatch.Instance.CommandMatches[commandChar];
            NUnit.Framework.Assert.AreEqual(compassDirection, compassDirectionResult);
        }

        [TestCase("N", CompassDirection.East)]
        [TestCase("E", CompassDirection.West)]
        [TestCase("S", CompassDirection.North)]
        [TestCase("W", CompassDirection.East)]
        public void CompassDirectionCommandMatch_FailTest(string commandChar, CompassDirection compassDirection)
        {
            CompassDirection compassDirectionResult = CompassDirectionCommandMatch.Instance.CommandMatches[commandChar];
            NUnit.Framework.Assert.AreNotEqual(compassDirection, compassDirectionResult);
        }
    }
}

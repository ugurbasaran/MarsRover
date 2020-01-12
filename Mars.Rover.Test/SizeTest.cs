using Mars.Rover.Domain;
using NUnit.Framework;
using System;

namespace Mars.Rover.Test
{
    [TestFixture]
    public class SizeTest
    {
        [TestCase(3, 5)]
        [TestCase(10, 12)]
        public void SetSize_Test(int width, int height)
        {
            Assert.DoesNotThrow(() => new Size(width, height));
        }

        [TestCase(0, 0)]
        [TestCase(-1, 5)]
        [TestCase(-5, -3)]
        [TestCase(1, 1)]
        public void SetSize_FailTest(int width, int height)
        {
            Assert.Throws<Exception>(() => new Size(width, height));
        }
    }
}

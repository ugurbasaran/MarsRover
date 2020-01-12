using Mars.Rover.Command;
using Mars.Rover.Domain;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using System;

namespace Mars.Rover.Test
{
    [TestFixture]
    public class RoverLocationTest
    {
        IServiceProvider serviceProvider = new ServiceCollection()
                                                  .AddSingleton<IRoverManager, NASARoverManager>()
                                                  .BuildServiceProvider();

        [TestCase(3, 3, "1 2 N")]
        [TestCase(15, 14, "12 13 N")]
        public void SetRoverLocation_MustInsidePlateau(int width, int height, string inputCommand)
        {
            IRoverManager nasaRoverManager = serviceProvider.GetService<IRoverManager>();
            nasaRoverManager.Plateau.SetSize(width, height);

            SetRoverLocationCommand setRoverLocationCommand = new SetRoverLocationCommand(serviceProvider);
            Assert.DoesNotThrow(() => setRoverLocationCommand.Execute(inputCommand));
        }

        [TestCase(3, 3, "5 9 N")]
        [TestCase(15, 14, "24 36 N")]
        public void SetRoverLocation_FailInsidePlateau(int width, int height, string inputCommand)
        {
            IRoverManager nasaRoverManager = serviceProvider.GetService<IRoverManager>();
            nasaRoverManager.Plateau.SetSize(width, height);

            SetRoverLocationCommand setRoverLocationCommand = new SetRoverLocationCommand(serviceProvider);
            Assert.Throws<Exception>(() => setRoverLocationCommand.Execute(inputCommand));
        }

        [TestCase(5, 5, "1 2 N", "RMRMRMRM")]
        public void MoveRoverLocation_MustInsidePlateau(int width, int height, string setRoverLocationInput, string moveRoverInput)
        {
            IRoverManager nasaRoverManager = serviceProvider.GetService<IRoverManager>();
            nasaRoverManager.Plateau.SetSize(width, height);

            SetRoverLocationCommand setRoverLocationCommand = new SetRoverLocationCommand(serviceProvider);
            setRoverLocationCommand.Execute(setRoverLocationInput);

            MoveRoverCommand moveRoverCommand = new MoveRoverCommand(serviceProvider);
            Assert.DoesNotThrow(() => moveRoverCommand.Execute(moveRoverInput));
        }

        [TestCase(5, 5, "1 2 N", "MMMMMMMM")]
        public void MoveRoverLocation_FailInsidePlateau(int width, int height, string setRoverLocationInput, string moveRoverInput)
        {
            IRoverManager nasaRoverManager = serviceProvider.GetService<IRoverManager>();
            nasaRoverManager.Plateau.SetSize(width, height);

            SetRoverLocationCommand setRoverLocationCommand = new SetRoverLocationCommand(serviceProvider);
            setRoverLocationCommand.Execute(setRoverLocationInput);

            MoveRoverCommand moveRoverCommand = new MoveRoverCommand(serviceProvider);
            Assert.Throws<Exception>(() => moveRoverCommand.Execute(moveRoverInput));
        }
    }
}

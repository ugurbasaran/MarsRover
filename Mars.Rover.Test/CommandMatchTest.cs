using Mars.Rover.Command;
using Mars.Rover.Domain;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using System;

namespace Mars.Rover.Test
{
    [TestFixture]
    public class CommandMatchTest
    {
        [TestCase("3 6", typeof(SetPlateauSizeCommand))]
        [TestCase("1 2 N", typeof(SetRoverLocationCommand))]
        [TestCase("LMLMLMLMM", typeof(MoveRoverCommand))]
        [TestCase("M", typeof(MoveForwardCommand))]
        [TestCase("L", typeof(TurnRoverCommand))]
        [TestCase("R", typeof(TurnRoverCommand))]
        public void CommandMatch_Test(string commandInput, Type commandType)
        {
            IServiceProvider serviceProvider = new ServiceCollection()
                                                  .AddSingleton<IRoverManager, NASARoverManager>()
                                                  .BuildServiceProvider();

            CommandManager commandManager = new CommandManager(serviceProvider);
            ICommand command = commandManager.GetCommandForInput(commandInput);
            Assert.AreEqual(command.GetType(), commandType);
        }

        [TestCase("QWERTY")]
        [TestCase("N 1 2")]
        [TestCase("t 5 5")]
        [TestCase("6 5 5")]
        public void CommandMatch_InvalidCommandTest(string commandInput)
        {
            IServiceProvider serviceProvider = new ServiceCollection()
                                                  .AddSingleton<IRoverManager, NASARoverManager>()
                                                  .BuildServiceProvider();

            CommandManager commandManager = new CommandManager(serviceProvider);
            Assert.Throws<Exception>(() => commandManager.ExecuteCommand(commandInput));
        }
    }
}

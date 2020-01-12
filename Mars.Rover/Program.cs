using Mars.Rover.Command;
using Mars.Rover.Domain;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Text;

namespace Mars.Rover
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var serviceProvider = new ServiceCollection()
                                          .AddSingleton<IRoverManager, NASARoverManager>()
                                          .BuildServiceProvider();

                CommandManager commandManager = new CommandManager(serviceProvider);
                string[] splittedCommands = BuildInput().Split(Environment.NewLine);
                foreach (var command in splittedCommands)
                {
                    commandManager.ExecuteCommand(command);
                }

                IRoverManager nasaRoverManager = serviceProvider.GetService<IRoverManager>();
                nasaRoverManager.GiveRoverReport();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
            }

            Console.ReadKey();
        }

        private static string BuildInput()
        {
            StringBuilder input = new StringBuilder();
            input.AppendLine("5 5");
            input.AppendLine("1 2 N");
            input.AppendLine("LMLMLMLMM");
            input.AppendLine("3 3 E");
            input.Append("MMRMMRMRRM");
            return input.ToString();
        }
    }
}

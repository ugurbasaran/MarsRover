using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Mars.Rover.Command
{
    public class CommandManager
    {
        private IEnumerable<Command> commandListInAssembly;
        private IServiceProvider serviceProvider;

        public CommandManager(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
            GetCommandExecutersInAssembly();
        }

        public void ExecuteCommand(string input)
        {
            ICommand executeCommand = GetCommandForInput(input);
            if (executeCommand == null)
                throw new Exception($"{input} is not a valid command!");

            executeCommand.Execute(input);
        }

        public ICommand GetCommandForInput(string input)
        {
            return commandListInAssembly.FirstOrDefault(command => command.CheckInputRegexMatch(input));
        }

        private void GetCommandExecutersInAssembly()
        {
            if (commandListInAssembly == null)
            {
                commandListInAssembly = Assembly.GetExecutingAssembly()
                                                .DefinedTypes
                                                .Where(type => type.IsSubclassOf(typeof(Command)) && !type.IsAbstract)
                                                .Select(x => Activator.CreateInstance(x, serviceProvider) as Command)
                                                .ToList();
            }
        }
    }
}

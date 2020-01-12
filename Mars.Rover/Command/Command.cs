using System;
using System.Text.RegularExpressions;
using Mars.Rover.Domain;
using Microsoft.Extensions.DependencyInjection;

namespace Mars.Rover.Command
{
    public abstract class Command : ICommand
    {
        protected IServiceProvider serviceProvider;
        protected IRoverManager nasaRoverManager;

        public Command(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
            nasaRoverManager = serviceProvider.GetService<IRoverManager>();
        }

        public bool CheckInputRegexMatch(string commandInput)
        {
            return CommandRegex.IsMatch(commandInput); 
        }

        public void Execute(string commandInput)
        {
            CheckInputRegexMatch(commandInput);
            InternalExecute(commandInput);
        }

        protected abstract void InternalExecute(string commandInput);

        public abstract Regex CommandRegex { get; }

    }
}

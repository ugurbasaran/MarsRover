using System;
using System.Text.RegularExpressions;

namespace Mars.Rover.Command
{
    public class MoveRoverCommand : Command
    {
        public override Regex CommandRegex => new Regex("^[LMR]{2,}$");

        public MoveRoverCommand(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }

        protected override void InternalExecute(string commandInput)
        {
            char[] splittedInput = commandInput.ToCharArray();
            foreach (var moveCommand in splittedInput)
            {
                new CommandManager(serviceProvider).ExecuteCommand(moveCommand.ToString());
            }
        }
    }
}

using Mars.Rover.Domain;
using System;
using System.Text.RegularExpressions;
using Microsoft.Extensions.DependencyInjection;

namespace Mars.Rover.Command
{
    public class SetPlateauSizeCommand : Command
    {
        public override Regex CommandRegex => new Regex(@"^\d+ \d+$");

        public SetPlateauSizeCommand(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }

        protected override void InternalExecute(string commandInput)
        {
            string[] splittedInput = commandInput.Split(' ');
            int x = Convert.ToInt32(splittedInput[0]);
            int y = Convert.ToInt32(splittedInput[1]);
            nasaRoverManager.Plateau.SetSize(x, y);
        }
    }
}

using Mars.Rover.CommandMatch;
using Mars.Rover.Enum;
using System;
using System.Text.RegularExpressions;

namespace Mars.Rover.Command
{
    public class SetRoverLocationCommand : Command
    {
        public override Regex CommandRegex => new Regex(@"^\d+ \d+ [NSEW]$");

        public SetRoverLocationCommand(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }

        protected override void InternalExecute(string commandInput)
        {
            string[] splittedCommand = commandInput.Split(' ');
            int locationX = Convert.ToInt32(splittedCommand[0]);
            int locationY = Convert.ToInt32(splittedCommand[1]);
            CompassDirection compassDirection = CompassDirectionCommandMatch.Instance.GetValue(splittedCommand[2]);

            bool checkRoverLocation = nasaRoverManager.CheckLocationInsidePlateau(locationX, locationY);
            if (checkRoverLocation == false)
                throw new Exception("Rover first location should be inside of Plateau!");

            Domain.Rover rover = new Domain.Rover()
            {
                CompassDirection = compassDirection,
                Location = new Domain.Location(locationX, locationY)
            };

            nasaRoverManager.RoverList.Add(rover);
            nasaRoverManager.CurrentRover = rover;
        }
    }
}

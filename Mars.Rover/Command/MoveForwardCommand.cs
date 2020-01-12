using Mars.Rover.CommandMatch;
using System;
using System.Text.RegularExpressions;

namespace Mars.Rover.Command
{
    public class MoveForwardCommand : Command
    {
        public override Regex CommandRegex => new Regex("^[M]+$");

        public MoveForwardCommand(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }

        protected override void InternalExecute(string commandInput)
        {
            nasaRoverManager.CheckCurrentRoverExist();
            MoveIncreaseLocation moveIncreaseLocation = MoveCommandMatch.Instance.GetValue(nasaRoverManager.CurrentRover.CompassDirection);
            nasaRoverManager.CurrentRover.Location.LocationX += moveIncreaseLocation.IncreaseXLocation;
            nasaRoverManager.CurrentRover.Location.LocationY += moveIncreaseLocation.IncreaseYLocation;
            bool checkRoverNextLocation = nasaRoverManager.CheckLocationInsidePlateau(nasaRoverManager.CurrentRover.Location.LocationX, nasaRoverManager.CurrentRover.Location.LocationY);
            if (checkRoverNextLocation == false)
                throw new Exception("Rover must be stay in plateau!");
        }
    }
}

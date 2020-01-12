using Mars.Rover.CommandMatch;
using Mars.Rover.Enum;
using System;
using System.Text.RegularExpressions;


namespace Mars.Rover.Command
{
    public class TurnRoverCommand : Command
    {
        public TurnRoverCommand(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }

        public override Regex CommandRegex => new Regex("^[LR]$");

        protected override void InternalExecute(string commandInput) 
        {
            Turn turn = TurnCommandMatch.Instance.GetValue(commandInput);
            nasaRoverManager.CheckCurrentRoverExist();
            CompassDirectionTurn compassDirectionTurn = new CompassDirectionTurn(nasaRoverManager.CurrentRover.CompassDirection, turn);
            CompassDirection nextCompassDirection = CompassDirectionTurnCommandMatch.Instance.GetValue(compassDirectionTurn);
            nasaRoverManager.CurrentRover.CompassDirection = nextCompassDirection;
        }
    }
}

using Mars.Rover.CommandMatch;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Mars.Rover.Domain
{
    public class NASARoverManager : IRoverManager
    {
        public List<IRover> RoverList { get; set; } = new List<IRover>();

        public IPlateau Plateau { get; set; }

        public IRover CurrentRover { get; set; }

        public NASARoverManager()
        {
            Plateau = new Plateau();
        }

        public void GiveRoverReport()
        {
            foreach (IRover rover in RoverList)
            {
                string directionCode = CompassDirectionCommandMatch.Instance.CommandMatches.FirstOrDefault(c => c.Value == rover.CompassDirection).Key;
                string roverReport = $"{rover.Location.LocationX} {rover.Location.LocationY} {directionCode}";
                Console.WriteLine(roverReport);
            }
        }

        public void CheckCurrentRoverExist()
        {
            if (CurrentRover == null)
                throw new Exception("Current rover not exist!");
        }

        public bool CheckLocationInsidePlateau(int locationX, int locationY)
        {
            return locationX >= 0 && locationX <= Plateau.Size.Width
                   && locationY >= 0 && locationY <= Plateau.Size.Height;
        }
    }
}

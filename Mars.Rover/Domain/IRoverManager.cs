using System.Collections.Generic;

namespace Mars.Rover.Domain
{
    public interface IRoverManager
    {
        List<IRover> RoverList { get; set; }

        IPlateau Plateau { get; set; }

        IRover CurrentRover { get; set; }

        bool CheckLocationInsidePlateau(int locationX, int locationY);

        void CheckCurrentRoverExist();

        void GiveRoverReport();
    }
}

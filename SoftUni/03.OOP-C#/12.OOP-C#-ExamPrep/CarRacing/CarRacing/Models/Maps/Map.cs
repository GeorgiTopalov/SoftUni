using CarRacing.Models.Maps.Contracts;
using CarRacing.Models.Racers.Contracts;
using CarRacing.Utilities.Messages;

namespace CarRacing.Models.Maps
{
    public class Map : IMap
    {
        public string StartRace(IRacer racerOne, IRacer racerTwo)
        {
            double racerOneMultiplier = 0;
            double racerTwoMultiplier = 0;

            if (racerOne.RacingBehavior == "strict")
            {
                racerOneMultiplier = 1.2;
            }
            else
            {
                racerOneMultiplier = 1.1;
            }
            if (racerTwo.RacingBehavior == "strict")
            {
                racerTwoMultiplier = 1.2;
            }
            else
            {
                racerTwoMultiplier = 1.1;
            }


            if (!racerOne.IsAvailable() && racerTwo.IsAvailable())
            {
                return string.Format(OutputMessages.OneRacerIsNotAvailable, racerTwo.Username, racerOne.Username);
            }
            else if (racerOne.IsAvailable() && !racerTwo.IsAvailable())
            {
                return string.Format(OutputMessages.OneRacerIsNotAvailable, racerOne.Username, racerTwo.Username);
            }
            else if (!racerOne.IsAvailable() && !racerTwo.IsAvailable())
            {
                return string.Format(OutputMessages.RaceCannotBeCompleted);
            }
            else
            {
                racerOne.Race();
                racerTwo.Race();

                double racerOneChanceOfWinning = racerOneMultiplier * racerOne.Car.HorsePower * racerOne.DrivingExperience;
                double racerTwoChanceOfWinning = racerTwoMultiplier * racerTwo.Car.HorsePower * racerTwo.DrivingExperience;

                if (racerOneChanceOfWinning > racerTwoChanceOfWinning)
                {
                    return string.Format(OutputMessages.RacerWinsRace, racerOne.Username, racerTwo.Username, racerOne.Username);
                }
                else
                {
                    return string.Format(OutputMessages.RacerWinsRace, racerTwo.Username, racerOne.Username, racerTwo.Username);
                }
            }
        }
    }
}

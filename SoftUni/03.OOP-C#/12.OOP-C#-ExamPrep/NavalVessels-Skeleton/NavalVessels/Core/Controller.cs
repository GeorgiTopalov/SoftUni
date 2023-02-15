using NavalVessels.Core.Contracts;
using NavalVessels.Models;
using NavalVessels.Models.Contracts;
using NavalVessels.Repositories;
using NavalVessels.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NavalVessels.Core
{
    public class Controller : IController
    {
        private VesselRepository vessels;
        private List<ICaptain> captains;

        public Controller()
        {
            this.vessels = new VesselRepository();
            this.captains = new List<ICaptain>();
        }

        public VesselRepository Vessels => this.vessels;
        public ICollection<ICaptain> Captains => this.captains;
        public string AssignCaptain(string selectedCaptainName, string selectedVesselName)
        {
            ICaptain captain = Captains.FirstOrDefault(c => c.FullName == selectedCaptainName);
            Vessel vessel = (Vessel)Vessels.FindByName(selectedVesselName);

            if (captain == default)
            {
                return String.Format(OutputMessages.CaptainNotFound, selectedCaptainName);
            }
            if (vessel == default)
            {
                return String.Format(OutputMessages.VesselNotFound, selectedVesselName);
            }
            if (vessel.Captain != null)
            {
                return String.Format(OutputMessages.VesselOccupied, selectedVesselName);
            }

            vessel.Captain = captain;
            captain.Vessels.Add(vessel);

            return String.Format(OutputMessages.SuccessfullyAssignCaptain, selectedCaptainName, selectedVesselName);
        }

        public string AttackVessels(string attackingVesselName, string defendingVesselName)
        {
            IVessel attackVessel = Vessels.FindByName(attackingVesselName);
            IVessel deffendVessel = Vessels.FindByName(defendingVesselName);

            
            if (attackVessel == null)
            {
                return String.Format(OutputMessages.VesselNotFound, attackingVesselName);
            }
            if(deffendVessel == null)
            {
                return String.Format(OutputMessages.VesselNotFound, defendingVesselName);
            }

            if (attackVessel.ArmorThickness == 0)
            {
                return String.Format(OutputMessages.AttackVesselArmorThicknessZero, attackingVesselName);
            }
            
            if(deffendVessel.ArmorThickness == 0)
            {
                return String.Format(OutputMessages.AttackVesselArmorThicknessZero, defendingVesselName);

            }

            attackVessel.Attack(deffendVessel);
            attackVessel.Captain.IncreaseCombatExperience();
            deffendVessel.Captain.IncreaseCombatExperience();

            return String.Format(OutputMessages.SuccessfullyAttackVessel, defendingVesselName, attackingVesselName, deffendVessel.ArmorThickness);
        }

        public string CaptainReport(string captainFullName)
        {
            ICaptain captain = Captains.FirstOrDefault(c => c.FullName == captainFullName);

            return captain.Report();
           
        }

        public string HireCaptain(string fullName)
        {
            Captain captain = new Captain(fullName);

            if (Captains.FirstOrDefault(c => c.FullName == fullName) == default)
            {
                Captains.Add(captain);
                return $"Captain {fullName} is hired.";
            }
            else
            {
                return $"Captain {fullName} is already hired.";
            }
        }

        public string ProduceVessel(string name, string vesselType, double mainWeaponCaliber, double speed)
        {
            if (Vessels.FindByName(name) != default)
            {
                return String.Format(OutputMessages.VesselIsAlreadyManufactured, vesselType, name);
            }
            if (vesselType != "Submarine" && vesselType != "Battleship")
            {
                return String.Format(OutputMessages.InvalidVesselType);
            }

            Vessel vessel;

            if (vesselType == "Submarine")
            {
                vessel = new Submarine(name, mainWeaponCaliber, speed);
            }
            else
            {
                vessel = new Battleship(name, mainWeaponCaliber, speed);
            }

            Vessels.Add(vessel);

            return String.Format(OutputMessages.SuccessfullyCreateVessel, vesselType, name, mainWeaponCaliber, speed);
        }

        public string ServiceVessel(string vesselName)
        {
            Vessel vessel = (Vessel)Vessels.FindByName(vesselName);

            if (vessel == default)
            {
                return String.Format(OutputMessages.VesselNotFound, vesselName);
            }
            
            vessel.RepairVessel();

            return String.Format(OutputMessages.SuccessfullyRepairVessel, vesselName);
        }

        public string ToggleSpecialMode(string vesselName)
        {
            Vessel vessel = (Vessel)Vessels.FindByName(vesselName);

            if (vessel == default)
            {
                return String.Format(OutputMessages.VesselNotFound, vesselName);
            }

            if(vessel.GetType().Name == "Battleship")
            {
                Battleship battleship = (Battleship)Vessels.FindByName(vesselName);
                battleship.ToggleSonarMode();

                return $"Battleship {vesselName} toggled sonar mode.";
            }
            else
            {
                Submarine submarine = (Submarine)Vessels.FindByName(vesselName);
                submarine.ToggleSubmergeMode();

                return $"Submarine {vesselName} toggled submerge mode.";
            }
        }

        public string VesselReport(string vesselName)
        {
            Vessel vessel = (Vessel)Vessels.FindByName(vesselName);

            return vessel.ToString();
        }
    }
}

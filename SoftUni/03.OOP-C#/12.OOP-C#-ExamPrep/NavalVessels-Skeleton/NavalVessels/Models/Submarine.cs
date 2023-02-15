using NavalVessels.Models.Contracts;
using System;
using System.Text;

namespace NavalVessels.Models
{
    public class Submarine : Vessel, ISubmarine
    {
        private bool submergeMode;
        public Submarine(string name, double mainWeaponCaliber, double speed) 
            : base(name, 200, mainWeaponCaliber, speed)
        {
            this.submergeMode = false;
        }

        public bool SubmergeMode => this.submergeMode;

        public override void RepairVessel()
        {
            if (this.ArmorThickness < 200)
            {
                this.ArmorThickness = 200;
            }
        }

        public void ToggleSubmergeMode()
        {
            if (submergeMode)
            {
                submergeMode = false;
                this.Speed += 4;
                this.MainWeaponCaliber -= 40;
            }
            else
            {
                submergeMode = true;
                this.Speed -= 4;
                this.MainWeaponCaliber += 40;
            }
        }

        public override string ToString()
        {
            string message;

            if (!submergeMode)
            {
                message = " *Submerge mode: OFF";
            }
            else
            {
                message = " *Submerge mode: ON";
            }
           
            return base.ToString() + $"{Environment.NewLine}" + $"{message}";
        }
    }
}

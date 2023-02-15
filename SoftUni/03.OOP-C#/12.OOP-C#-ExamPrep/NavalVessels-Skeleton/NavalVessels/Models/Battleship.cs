using System;
using System.Text;

namespace NavalVessels.Models.Contracts
{
    public class Battleship : Vessel, IBattleship
    {
        private bool sonarMode;
        public Battleship(string name, double mainWeaponCaliber, double speed) 
            : base(name, 300, mainWeaponCaliber, speed)
        {
            this.sonarMode = false;
        }

        public bool SonarMode => this.sonarMode;
        public override void RepairVessel()
        {
            if (this.ArmorThickness < 300)
            {
                 this.ArmorThickness = 300;
            }
        }

        public void ToggleSonarMode()
        {
            if (sonarMode)
            {
                sonarMode = false;
                this.MainWeaponCaliber -= 40;
                this.Speed += 5;
            }
            else
            {
                sonarMode = true;
                this.MainWeaponCaliber += 40;
                this.Speed -= 5;
            }
        }

        public override string ToString()
        {

            string message;

            if (!sonarMode)
            {
                message = " *Sonar mode: OFF";
            }
            else
            {
                message = " *Sonar mode: ON";
            }
            
            return base.ToString() + $"{Environment.NewLine}" + $"{message}";
        }
    }
}

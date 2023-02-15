using NavalVessels.Models.Contracts;
using NavalVessels.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace NavalVessels.Models
{
    public abstract class Vessel : IVessel
    {
        private string name;
        private double armorThickness;
        private double mainWeaponCaliber;
        private double speed;
        private ICaptain captain;
        private List<string> targets;

        public Vessel(string name, double armorThickness, double mainWeaponCaliber, double speed)
        {
            this.Name = name;
            this.ArmorThickness = armorThickness;
            this.MainWeaponCaliber = mainWeaponCaliber;
            this.Speed = speed;
            this.targets = new List<string>();
        }

        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(string.Format(ExceptionMessages.InvalidVesselName));
                }
                name = value;
            }
        }

        public ICaptain Captain
        {
            get { return captain; }
            set
            {
                if (value == null)
                {
                    throw new NullReferenceException(string.Format(ExceptionMessages.InvalidCaptainToVessel));
                }
                captain = value;
            }
        }
        public double ArmorThickness { get { return this.armorThickness; } set { this.armorThickness = value; } }

        public double MainWeaponCaliber { get { return this.mainWeaponCaliber; } protected set { this.mainWeaponCaliber = value; } }

        public double Speed { get { return this.speed; } protected set { this.speed = value; } }

        public ICollection<string> Targets => this.targets;

        public void Attack(IVessel target)
        {
           if (target == null)
            {
                throw new NullReferenceException(string.Format(ExceptionMessages.InvalidTarget));
            }
            this.Targets.Add(target.Name);

            target.ArmorThickness -= this.MainWeaponCaliber;

            if (target.ArmorThickness < 0)
            {
                target.ArmorThickness = 0;
            }
        }

        abstract public void RepairVessel();
       

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"- {this.Name}");
            sb.AppendLine($" *Type: {this.GetType().Name}");
            sb.AppendLine($" *Armor thickness: {this.ArmorThickness}");
            sb.AppendLine($" *Main weapon caliber: {this.MainWeaponCaliber}");
            sb.AppendLine($" *Speed: {this.Speed} knots");

            if (this.Targets.Count > 0)
            {
                sb.AppendLine($" *Targets: {string.Join(", ", this.Targets)}");
            }
            else
            {
                sb.AppendLine($" *Targets: none");
            }

            return sb.ToString().TrimEnd();
        }
    }
}


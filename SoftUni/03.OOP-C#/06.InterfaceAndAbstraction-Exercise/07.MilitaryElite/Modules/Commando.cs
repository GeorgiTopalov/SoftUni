using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite
{
    public class Commando : SpecialisedSoldier, ICommando
    {
        private List<IMission> missions;
        public Commando(string id, string firstName, string lastName, decimal salary, string corps)
            : base (id, firstName, lastName, salary, corps)
        {
            
          this.missions = new List<IMission>();
        }
        
        public IReadOnlyCollection<IMission> Missions => this.missions;

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"Name: {FirstName} {LastName} Id: {Id} Salary: {Salary:F2}");
            stringBuilder.AppendLine($"Corps: {Corps}");
            stringBuilder.AppendLine("Missions:");

            foreach (var mission in Missions)
            {
                stringBuilder.AppendLine($"  {mission.ToString()}");
            }
            return stringBuilder.ToString().TrimEnd();
        }
        public void AddMission(IMission mission)
        {
            this.missions.Add(mission);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite
{
    public class Engineer : SpecialisedSoldier, IEngineer
    {
        private List<IRepair> repairs;
        public Engineer(string id, string firstName, string lastName, decimal salary, string corps)
        : base (id, firstName, lastName, salary,corps)
        {
            
            this.repairs = new List<IRepair>();
        }

        
        public IReadOnlyCollection<IRepair> Repairs => this.repairs;

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"Name: {FirstName} {LastName} Id: {Id} Salary: {Salary:f2}");
            stringBuilder.AppendLine($"Corps: {Corps}");
            stringBuilder.AppendLine("Repairs:");

            foreach (var repair in Repairs)
            {
                stringBuilder.AppendLine($"  {repair.ToString()}");
            }
            return stringBuilder.ToString().TrimEnd();
        }

        public void AddRepair(IRepair repair)
        {
            this.repairs.Add(repair);
        }
    }
}

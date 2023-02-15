using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite
{
    public class LieutenantGeneral : Private, ILieutenantGeneral
    {
        private List<ISoldier> privates;
        public LieutenantGeneral(string id, string firstName, string lastName, decimal salary)
            : base(id, firstName, lastName, salary)
        {
            this.privates = new List<ISoldier>();
        }

        public IReadOnlyCollection<ISoldier> Privates => this.privates;

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"Name: {FirstName} {LastName} Id: {Id} Salary: {Salary:F2}");
            stringBuilder.AppendLine("Privates:");
            foreach(var privates in Privates)
            {
                stringBuilder.AppendLine($"  {privates.ToString()}");
            }
            return stringBuilder.ToString().TrimEnd();
        }
        public void AddPrivate(ISoldier newPrivate)
        {
            this.privates.Add(newPrivate);
        }
    }
}

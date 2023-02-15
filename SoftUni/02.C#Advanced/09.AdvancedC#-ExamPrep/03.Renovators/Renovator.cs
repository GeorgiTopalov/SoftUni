using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renovators
{
    public class Renovator
    {
        string name;
        string type;
        double rate;
        int days;
        bool hired;

        public string Name { get { return this.name; } set { this.name = value; } }
        public string Type { get { return this.type; } set { this.type = value; } }
        public double Rate { get { return this.rate; } set { this.rate = value; } }
        public bool Hired { get { return this.hired; } set { this.hired = value; } }
        public int Days { get { return this.days; } set { this.days = value; } }

        public Renovator(string name, string type, double rate, int days) 
        {
            this.name = name;
            this.type = type;
            this.rate = rate;
            this.days = days;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"-Renovator: {this.Name}");
            sb.AppendLine($"--Specialty: {this.Type}");
            sb.AppendLine($"--Rate per day: {this.Rate} BGN");

            return sb.ToString().TrimEnd();
           
        }
    }
}

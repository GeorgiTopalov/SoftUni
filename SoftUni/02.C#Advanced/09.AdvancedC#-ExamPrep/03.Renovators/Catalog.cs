using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renovators
{
    public class Catalog
    {
        List<Renovator> renovators;
        string name;
        int neededRenovators;
        string project;
        

        public int Count { get { return renovators.Count; } }

        public string Name { get { return this.name; } set { this.name = value; } }
        public int NeededRenovators { get { return this.neededRenovators; } set { this.neededRenovators = value; } }
        public string Project { get { return this.project; } set { this.project = value; } }

        public Catalog(string name, int neededRenovators, string project)
        {
            this.name = name;
            this.neededRenovators = neededRenovators;
            this.project = project;
            this.renovators = new List<Renovator>();
        }



        public string AddRenovator(Renovator renovator)
        {
            if (renovator.Name == null 
                || renovator.Name == String.Empty 
                || renovator.Type == null 
                || renovator.Type == String.Empty)
            {
                return "Invalid renovator's information.";
            }
            if (renovators.Count >= neededRenovators)
            {
                return "Renovators are no more needed.";
            }
            if (renovator.Rate > 350)
            {
                return "Invalid renovator's rate.";
            }
            renovators.Add(renovator);
            return $"Successfully added {renovator.Name} to the catalog.";
        }
        public bool RemoveRenovator(string name)
        {
            if (!renovators.Any(x => x.Name == name))
            {
                return false;
            }

            foreach (var renovator in renovators)
            {
                if (renovator.Name == name)
                {
                    renovators.Remove(renovator);
                    break;
                }
            }
            return true;

        }
        public int RemoveRenovatorBySpecialty(string type)
        {
            int renovatorsCount = 0;

            for (int i = 0; i < renovators.Count; i++)
            {
                if (renovators[i].Type == type)
                {
                    renovatorsCount++;
                    renovators.Remove(renovators[i]);
                    i--;
                }
            }


            return renovatorsCount;
        }

        public Renovator HireRenovator(string name)
        {
            foreach (var renovator in renovators)
            {
                if (renovator.Name == name)
                {
                    renovator.Hired = true;
                    return renovator;
                }
            }
            return null;
        }

        public List<Renovator> PayRenovators(int days)
        {
            List<Renovator> workingRenovators = new List<Renovator>();

            foreach (var renovator in renovators)
            {
                if (renovator.Days >= days)
                {
                    workingRenovators.Add(renovator);
                }
            }

            return workingRenovators;
        }

        public string Report()
        {
            List<Renovator> notHired = new List<Renovator>();

            foreach (var renovator in renovators)
            {
                if (renovator.Hired == false)
                {
                    notHired.Add(renovator);
                }
            }

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Renovators available for Project {project}:");

            foreach (var renovator in notHired)
            {
                sb.AppendLine($"{renovator}");
            }

            return sb.ToString().TrimEnd();
            
        }
    }
}

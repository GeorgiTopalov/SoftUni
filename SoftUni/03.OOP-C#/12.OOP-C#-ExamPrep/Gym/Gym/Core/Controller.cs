using Gym.Core.Contracts;
using Gym.Models.Athletes;
using Gym.Models.Athletes.Contracts;
using Gym.Models.Equipment;
using Gym.Models.Equipment.Contracts;
using Gym.Models.Gyms;
using Gym.Models.Gyms.Contracts;
using Gym.Repositories;
using Gym.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gym.Core
{
    public class Controller : IController
    {
        private readonly EquipmentRepository equipment;
        private readonly ICollection<IGym> gyms;

        public Controller()
        {
            this.equipment = new EquipmentRepository();
            this.gyms = new List<IGym>();
        }
        public string AddAthlete(string gymName, string athleteType, string athleteName, string motivation, int numberOfMedals)
        {
            if (athleteType != "Boxer" && athleteType != "Weightlifter")
            {
                throw new InvalidOperationException("Invalid athlete type");
            }
            IGym gym = gyms.FirstOrDefault(g => g.Name == gymName);

            if ((gym.GetType().Name == "BoxingGym" && athleteType == "Weightlifter") ||
                 gym.GetType().Name == "WeightliftingGym" && athleteType == "Boxer")
            {
                return String.Format(OutputMessages.InappropriateGym);
            }
           

            IAthlete newAthlete;

            if (athleteType == "Boxer")
            {
                newAthlete = new Boxer(athleteName, motivation, numberOfMedals);
            }
            else
            {
                newAthlete = new Weightlifter(athleteName, motivation, numberOfMedals);
            }

            gym.AddAthlete(newAthlete);

            return String.Format(OutputMessages.EntityAddedToGym, athleteType, gymName);
        }

        public string AddEquipment(string equipmentType)
        {
            if (equipmentType != "BoxingGloves" && equipmentType != "Kettlebell")
            {
                throw new InvalidOperationException("Invalid equipment type");
            }

            IEquipment newEquipment;

            if (equipmentType == "BoxingGloves")
            {
                newEquipment = new BoxingGloves();
            }
            else
            {
                newEquipment = new Kettlebell();
            }

            this.equipment.Add(newEquipment);

            return String.Format(OutputMessages.SuccessfullyAdded, equipmentType);
        }

        public string AddGym(string gymType, string gymName)
        {
            if (gymType != "BoxingGym" && gymType != "WeightliftingGym")
            {
                throw new InvalidOperationException("Invalid gym type");
            }

            IGym gym;

            if (gymType == "BoxingGym")
            {
                gym = new BoxingGym(gymName);
            }
            else
            {
                gym = new WeightliftingGym(gymName);
            }

            gyms.Add(gym);
            return String.Format(OutputMessages.SuccessfullyAdded, gymType);
        }

        public string EquipmentWeight(string gymName)
        {
            IGym currentGym = gyms.FirstOrDefault(x => x.Name == gymName);
            string totalWeight = $"{currentGym.EquipmentWeight:f2}";

            return String.Format(OutputMessages.EquipmentTotalWeight, gymName, totalWeight);
        }

        public string InsertEquipment(string gymName, string equipmentType)
        {
            IEquipment currentEquipment = this.equipment.FindByType(equipmentType);
            IGym currentGym = gyms.FirstOrDefault(x=> x.Name == gymName);

            if (currentEquipment == null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.InexistentEquipment, equipmentType));
            }

            currentGym.AddEquipment(currentEquipment);
            this.equipment.Remove(currentEquipment);

            return String.Format(OutputMessages.EntityAddedToGym, equipmentType, gymName);
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var gym in gyms)
            {
                sb.AppendLine(gym.GymInfo());
            }

            return sb.ToString().TrimEnd();
        }

        public string TrainAthletes(string gymName)
        {
            //Can they train with 100 stamina or no? Test
            IGym gym = gyms.FirstOrDefault(x => x.Name == gymName);

            gym.Exercise();

            return String.Format(OutputMessages.AthleteExercise, gym.Athletes.Count);
        }
    }
}

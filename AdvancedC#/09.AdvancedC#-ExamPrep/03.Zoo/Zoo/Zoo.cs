using System.Collections.Generic;

namespace Zoo
{
    public class Zoo
    {
        List<Animal> animals;

        string name;

        int capacity;

        public string Name { get { return this.name; } set { this.name = value; } }

        public int Capacity { get { return this.capacity; } set { this.capacity = value; } }

        public List<Animal> Animals { get { return this.animals; } set { this.animals = value; } }

        public Zoo(string name, int capacity)
        {
            this.name = name;
            this.capacity = capacity;
            this.animals = new List<Animal>();
        }

        public string AddAnimal(Animal animal)
        {
            if (animal.Species == null || animal.Species == string.Empty)
            {
                return "Invalid animal species.";
            }
            if (animal.Diet != "herbivore" && animal.Diet != "carnivore")
            {
                return "Invalid animal diet.";
            }
            if (animals.Count == capacity)
            {
                return "The zoo is full.";
            }

            animals.Add(animal);
            return $"Successfully added {animal.Species} to the zoo.";
        }
        public int RemoveAnimals(string species)
        {
            int count = 0;
            for (int i = 0; i < animals.Count; i++)
            {
                if (animals[i].Species.Equals(species))
                {
                    count++;
                    animals.RemoveAt(i);
                    i--;
                }
            }
            return count;
        }

        public List<Animal> GetAnimalsByDiet(string diet)
        {
            List<Animal> animalsOnDiet = new List<Animal>();

            foreach (Animal animal in animals)
            {
                if (animal.Diet.Equals(diet))
                {
                    animalsOnDiet.Add(animal);
                }
            }

            return animalsOnDiet;
        }

        public Animal GetAnimalByWeight(double weight)
        {
            foreach (Animal animal in animals)
            {
                if (animal.Weight.Equals(weight))
                {
                    return animal;
                }
            }
            return null;
        }
        public string GetAnimalCountByLength(double minimumLength, double maximumLength)
        {
            int animalCount = 0;

            foreach (Animal animal in animals)
            {
                if (animal.Length >= minimumLength && animal.Length <= maximumLength)
                {
                    animalCount++;
                }
            }
            return $"There are {animalCount} animals with a length between {minimumLength} and {maximumLength} meters.";

        }
    }
}

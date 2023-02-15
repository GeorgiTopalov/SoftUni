using System;

namespace WildFarm
{
    public class AnimalFactory
    {
        public Animal CreateAnimal(string[] animalInfo)
        {
            string type = animalInfo[0];
            string name = animalInfo[1];
            double weight = double.Parse(animalInfo[2]);
            string uniqueProp = animalInfo[3];

            Animal animal = null;

            if (animalInfo.Length == 5)
            {

                string breed = animalInfo[4];

                if (type == "Cat")
                {
                    animal = new Cat(name, weight, uniqueProp, breed);
                }
                else
                {
                    animal = new Tiger(name, weight, uniqueProp, breed);
                }
            }
            else if (type == "Owl")
            {
                animal = new Owl(name, weight, double.Parse(uniqueProp));
            }
            else if (type == "Hen")
            {
                animal = new Hen(name, weight, double.Parse(uniqueProp));
            }
            else if (type == "Dog")
            {
                animal = new Dog(name, weight, uniqueProp);

            }
            else if (type == "Mouse")
            {
                animal = new Mouse(name, weight, uniqueProp);
            }

            return animal;
        }
    }
}

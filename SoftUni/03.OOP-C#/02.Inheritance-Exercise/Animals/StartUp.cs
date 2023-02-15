using System;

namespace Animals
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string input = Console.ReadLine();

            while (true)
            {
                string type = Console.ReadLine();
                string[] animalArgs = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string name = animalArgs[0];
                int age = int.Parse(animalArgs[1]);

                if (age < 0)
                {
                    Console.WriteLine("Invalid input!");
                    continue;
                }
                if (type == "Beast")
                {
                    break;
                }
                Animal animal = default;

                if (type == "Cat")
                {
                    Cat cat = new Cat(name, age, animalArgs[2]);
                }
                else if (type == "Dog")
                {
                    animal = new Dog(name, age, animalArgs[2]);
                }
                else if (type == "Frog")
                {
                    animal = new Frog(name, age,animalArgs[2]);
                }
                else if (type == "Kitten")
                {
                    animal = new Kitten(name, age);
                }
                else if (type == "TomCat")
                {
                    animal = new Tomcat(name, age);
                }
                Console.WriteLine(type);
                Console.WriteLine($"{animal.Name} {animal.Age} {animal.Gender}");
                string sound = animal.ProduceSound();
                Console.WriteLine(sound);
                
            }
        }
    }
}

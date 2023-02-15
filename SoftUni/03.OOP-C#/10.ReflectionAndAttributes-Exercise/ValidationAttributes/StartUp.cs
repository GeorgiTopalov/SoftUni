using System;

namespace ValidationAttributes
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var person = new Person("Ivan", 65);

            bool isValidEntity = Validator.isValid(person);

            Console.WriteLine(isValidEntity);
        }
    }
}

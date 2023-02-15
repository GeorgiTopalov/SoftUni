using System;

namespace Telephony
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] numbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string[] websites = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            Smartphone smartphone = new Smartphone();

            for (int i = 0; i < numbers.Length; i++)
            {
                try
                {
                    for (int j = 0; j < numbers[i].Length; j++)
                    {
                        if (!Char.IsDigit(numbers[i][j]))
                        {
                            throw new ArgumentException("Invalid number!");
                        }
                    }
                    smartphone.Call(numbers[i]);
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                }
            }

            for (int i = 0; i < websites.Length; i++)
            {
                try
                {
                    for (int j = 0; j < websites[i].Length; j++)
                    {
                        if (Char.IsDigit(websites[i][j]))
                        {
                            throw new ArgumentException("Invalid URL!");
                        }
                    }
                    smartphone.Browse(websites[i]);
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}

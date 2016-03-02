namespace _01.SumAndAverage
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
           
            if (string.IsNullOrEmpty(input))
            {
                Console.WriteLine("Sum=0; Average=0");
                return;
            }

            List<decimal> numbers = new List<decimal>();
            string[] inputSplited = input.Split(' ');
            foreach (var number in inputSplited)
            {
                numbers.Add(decimal.Parse(number));
            }

            Console.Write("Sum={0};", numbers.Sum());
            Console.WriteLine("Average={0}", numbers.Average());
        }
    }
}

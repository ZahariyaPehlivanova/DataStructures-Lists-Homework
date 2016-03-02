using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.Count_of_Occurrences
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            List<int> numbers = new List<int>();
            string[] inputSplited = input.Split(' ');

            foreach (var number in inputSplited)
            {
                numbers.Add(int.Parse(number));
            }

            var occurences = Enumerable.Repeat(0, 1000 + 1)
                .ToArray();

            foreach (var number in numbers)
            {
                occurences[number]++;
            }

            for (int num = 0; num <= 1000; num++)
            {
                if (occurences[num] > 0)
                {
                    Console.WriteLine($"{num} -> {occurences[num]} times");
                }
            }
        }
    }
}

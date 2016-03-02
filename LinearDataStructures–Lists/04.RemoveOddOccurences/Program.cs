namespace _04.RemoveOddOccurences
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

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

            RemoveOccurences(numbers);

            Console.WriteLine(string.Join(" ", numbers));
        }

        private static void RemoveOccurences(List<int> numbers)
        {
            var distinctNums = new List<int>(numbers.Distinct());

            foreach (var distinctNum in distinctNums)
            {
                if (numbers.Count(n => n == distinctNum) % 2 == 1)
                {
                    numbers.RemoveAll(num => num == distinctNum);
                }
            }
        }
    }
}

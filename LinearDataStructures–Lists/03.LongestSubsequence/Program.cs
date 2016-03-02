namespace _03.LongestSubsequence
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

            var longestSubsequence = FindLongestSubsequence(numbers);

            Console.WriteLine(string.Join(" ", longestSubsequence));
        }

        public static List<int> FindLongestSubsequence(IList<int> nums)
        {
            var longestSequence = int.MinValue;
            var startIndex = int.MinValue;

            for (int i = 0; i < nums.Count; i++)
            {
                var currentNum = nums[i];
                var currCount = 1;
                for (int j = i + 1; j < nums.Count; j++)
                {
                    if (nums[j] != currentNum)
                    {
                        break;
                    }

                    currCount++;
                }

                if (currCount > longestSequence)
                {
                    longestSequence = currCount;
                    startIndex = i;
                }
            }

            var result = new List<int>(
                nums
                    .Skip(startIndex)
                    .Take(longestSequence));

            return result;
        }
    }
}

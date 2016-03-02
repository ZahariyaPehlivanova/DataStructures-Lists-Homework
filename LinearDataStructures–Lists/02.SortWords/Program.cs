using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.SortWords
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            List<string> words = new List<string>();
            string[] inputSplited = input.Split(' ');

            foreach (var word in inputSplited)
            {
                words.Add(word);
            }

            Console.WriteLine("{0}", string.Join(" ", words.OrderBy(x => x)));
        }
    }
}

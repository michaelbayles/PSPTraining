using System;
using System.IO;
using System.Linq;

namespace PSPTraining
{
    public class Day1
    {
        //read input
        //apply calculation
        //output

        public double CalculateMedianFromFile(string inputFile)
        {
            if (!File.Exists(inputFile))
            {
                Console.WriteLine("Your file doesn't exist");
                throw new FileNotFoundException(inputFile);
            }


            var nums = File.ReadAllLines(inputFile).Select(a => int.Parse(a)).ToArray();

            var sorted = BubbleSorter.SortInts(nums);


            return MikeMath.Median(sorted);

        }

    }
}

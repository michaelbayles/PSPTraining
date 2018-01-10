using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PSPTraining
{
    public static class MikeMath
    {
        public static double Median(int[] nums)
        {
            if (nums.Length == 1)
                return nums[0];

            if (nums.Length == 0)
                return 0;

            if (nums.Length % 2 == 0)
            {
                return (nums[nums.Length / 2] + nums[(nums.Length / 2) - 1]) / 2.0;
            }
            else
            {
                return nums[nums.Length / 2];
            }
        }

        /// <summary>
        /// Parses a double from a percentage string. 0 will be returned if pattern not found
        /// </summary>
        /// <param name="input">Input string containing percentage</param>
        /// <returns>The percentage expressed as a double if present. Otherwise 0.</returns>
        public static double PercentageStringToDouble(string input)
        {
            var pattern = new Regex(@"(\d+)%");
            if (pattern.IsMatch(input))
            {
                return double.Parse(pattern.Match(input).Groups[1].Value) / 100.0;
            }

            return 0;

        }
    }
}

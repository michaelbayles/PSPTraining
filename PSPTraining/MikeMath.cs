using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    }
}

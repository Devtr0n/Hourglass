using FluentAssertions;
using System;

namespace Hourglass
{
    /*
        The main Program class
        Contains all methods for performing hourglass summation and analysis on largest sum
    */
    /// <summary>
    /// The main Program class
    /// Contains all methods and properties for performing hourglass summation and analysis
    /// </summary>
    /// <remarks>Given a 2D matrix, the task is to find the maximum sum of an hourglass</remarks>
    internal class Program
    {
        public static int Result { get; set; }

        // Calculates the largest sum of all hourglass possibilities
        /// <summary>
        /// Calculates the largest sum of all hourglass possibilities
        /// </summary>
        internal static int HourglassSum(int[][] arr)
        {
            // initialize the sum and largestSum, sum is used to temporarily store the hourglass sum of each calculation, largestSum is used to store the largest sum of all calculations
            int sum, largestSum = 0;

            // traverse the non-edge numbers of the array (that is, the number that can become the center of the hourglass)
            for (var j = 1; j < arr.Length - 1; j++)
            {
                for (var i = 1; i < arr[j].Length - 1; i++)
                {
                    // sum of current hourglass numbers
                    sum = arr[i - 1][j - 1] + arr[i - 1][j] + arr[i - 1][j + 1] + arr[i][j] + arr[i + 1][j - 1] + arr[i + 1][j] + arr[i + 1][j + 1];

                    // determine the largest hourglass sum, a clever trick
                    largestSum = Math.Max(largestSum, sum);
                }
            }

            return largestSum;
        }

        // Initializes hourglass data and calculates the largest sum
        /// <summary>
        /// Initializes hourglass data and calculates the largest sum
        /// </summary>
        /// <remarks>
        /// This method uses FluentAssertions to validate expected results and outcomes
        /// </remarks>
        private static void Main(string[] args)
        {
            // initialize a two-dimensional array
            var arr = new int[][] {new int[]{1, 1, 1, 0, 0, 0},
                                    new int[]{0, 1, 0, 0, 0, 0},
                                    new int[]{1, 1, 1, 0, 0, 0},
                                    new int[]{0, 0, 2, 4, 4, 0},
                                    new int[]{0, 0, 0, 2, 0, 0},
                                    new int[]{0, 0, 1, 2, 4, 0}};

            // calculate the largest hourglass sum
            Result = HourglassSum(arr);

            // output result and verify correctness
            Console.WriteLine(Result);
            Result.Should().Be(19);

            // initialize another two-dimensional array
            arr = new int[][] {new int[]{1, 2, 3, 0, 0},
                               new int[]{0, 0, 0, 0, 0},
                               new int[]{2, 1, 4, 0, 0},
                               new int[]{0, 0, 0, 0, 0},
                               new int[]{1, 1, 0, 1, 0}};

            // calculate the largest hourglass sum
            Result = HourglassSum(arr);

            // output result and verify correctness
            Console.WriteLine(Result);
            Result.Should().Be(13);

            // finish up and pause console window
            Console.ReadKey();
        }
    }
}
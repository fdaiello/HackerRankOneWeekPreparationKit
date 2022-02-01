using System;
using System.Collections.Generic;

namespace HackerRankOneWeekPreparationKit
{
    class Program
    {
        static void Main(string[] args)
        {
            TestCountingSort();
        }
        static void TestCountingSort()
        {
            List<int> arr  = new() { 1, 1, 3, 2, 1 };
            Console.WriteLine(String.Join(",",Result.countingSort(arr)));

            arr = new() { 50, 40, 40, 20, 30, 90, 75, 85, 44, 12, 99 };
            Console.WriteLine(String.Join(",", Result.countingSort(arr)));

        }
        static void TestDiagonalDifference()
        {
            List<List<int>> arr = new()
            {
                new() { 1, 2, 3 },
                new() { 4, 5, 6 },
                new() { 9, 8, 9 }
            };

            Console.WriteLine(Result.diagonalDifference(arr));
            Console.WriteLine("Expected: 2");


            arr = new()
            {
                new() { 11, 2, 4 },
                new() { 4, 5, 6 },
                new() { 10, 8, -12 }
            };

            Console.WriteLine(Result.diagonalDifference(arr));
            Console.WriteLine("Expected: 15");
        }
        static void TestLonelyInt()
        {
            List<int> arr = new List<int>() { 1, 2, 3, 4, 3, 2, 1 };
            Console.WriteLine(Result.lonelyinteger(arr));
            Console.WriteLine("Expected: 4");
        }
        static void TestFindMedian()
        {
            List<int> arr = new List<int>() { 0, 1, 2, 4, 6, 5, 3 };
            Console.WriteLine(Result.findMedian(arr));
            Console.WriteLine("Expected: 3");

            arr = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11};
            Console.WriteLine(Result.findMedian(arr));
            Console.WriteLine("Expected: 6");

        }
        static void TestTimeConversion()
        {
            string time = "07:05:45PM";
            Console.WriteLine(Result.timeConversion(time));
            Console.WriteLine("Expcted: 19:05:45");
        }
        static void TestPlusMinus()
        {
            List<int> arr = new List<int>() { 1, 1, 0, -1, - 1 };
            Result.plusMinus(arr);
            Console.WriteLine("Expected: 0.400000, 0.400000, 0.200000");
        }
        static void TestMinMaxSum()
        {
            List<int> arr = new List<int>() { 1, 3, 5, 7, 9 };
            Result.miniMaxSum(arr);
            Console.WriteLine("Expected: 16, 24");

            arr = new List<int>() { 1, 3, 5, int.MaxValue, int.MaxValue-1 };
            Result.miniMaxSum(arr);
            long min = 1 + 3 + 5 + (long)(int.MaxValue - 1);
            long max = 3 + 5 + (long)int.MaxValue + (long)(int.MaxValue - 1);

            Console.WriteLine($"Expected: {min} {max}");

        }
    }
}

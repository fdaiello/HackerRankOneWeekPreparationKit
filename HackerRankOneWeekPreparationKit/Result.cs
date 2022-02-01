﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRankOneWeekPreparationKit
{
    class Result

    {
        /*
         *  https://www.hackerrank.com/challenges/one-week-preparation-kit-plus-minus
         */
        public static void plusMinus(List<int> arr)
        {
            // positive
            float p = 0;
            // negative
            float n = 0;
            // zero
            float z = 0;
            
            for ( int i =0; i< arr.Count; i++)
            {
                if (arr[i] > 0)
                    p++;
                else if (arr[i] < 0)
                    n++;
                else
                    z++;
            }

            Console.WriteLine((p / arr.Count).ToString("N6"));
            Console.WriteLine((n / arr.Count).ToString("N6"));
            Console.WriteLine((z / arr.Count).ToString("N6"));

        }
        /*
         *  https://www.hackerrank.com/challenges/one-week-preparation-kit-mini-max-sum
         */
        public static void miniMaxSum(List<int> arr)
        {
            arr.Sort();
            long min = arr.Sum(v=>(long)v) - arr[arr.Count - 1];
            long max = arr.Sum(v => (long)v) - arr[0];

            Console.WriteLine(min + " " + max);
        }
        /*
         * https://www.hackerrank.com/challenges/one-week-preparation-kit-time-conversion
         */
        public static string timeConversion(string s)
        {
            DateTime dateTime = Convert.ToDateTime(s);
            return dateTime.ToString("HH:mm:ss");

        }
        /*
         * https://www.hackerrank.com/test/eoipgdk427n/questions/a8taf02a12a
         */
        public static int findMedian(List<int> arr)
        {
            arr.Sort();
            return arr[arr.Count / 2];
        }
        /*
         * https://www.hackerrank.com/challenges/one-week-preparation-kit-lonely-integer
         */
        public static int lonelyinteger(List<int> a)
        {
            Dictionary<int, int> map = new Dictionary<int, int>();
            for ( int i =0; i<a.Count; i++)
            {
                if (map.ContainsKey(a[i]))
                    map[a[i]]++;
                else
                    map.Add(a[i], 1);
            }

            return map.Where(p => p.Value == 1).Select(p=>p.Key).FirstOrDefault();
        }
        /*
         * https://www.hackerrank.com/challenges/one-week-preparation-kit-diagonal-difference
         */
        public static int diagonalDifference(List<List<int>> arr)
        {
            // Sum of Diagonals
            long d1 = 0;
            long d2 = 0;

            // Column
            int column = 0;

            // For all rows
            for ( int row=0; row<arr.Count; row++)
            {
                d1 += arr[row][column];
                d2 += arr[row][arr[row].Count - column - 1];
                column++;
            }

            // Return Absolute value of difference
            return (int)Math.Abs(d1 - d2);
        }

        /*
         * https://www.hackerrank.com/challenges/one-week-preparation-kit-countingsort1
         */

        public static List<int> countingSort(List<int> arr)
        {
            // Hash table
            int[] hash = new int[100];

            // Taverse input array, fill hash
            for ( int i =0; i < arr.Count; i++)
            {
                hash[arr[i]]++;
            }

            return hash.ToList();
        }
    }
}

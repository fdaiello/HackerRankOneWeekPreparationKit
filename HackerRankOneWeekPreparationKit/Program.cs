using System;
using System.Collections.Generic;
using System.IO;

namespace HackerRankOneWeekPreparationKit
{
    class Program
    {
        static void Main(string[] args)
        {
            TestLegoBlocks();
        }
        static void TestLegoBlocks()
        {
            int n = 2;
            int m = 2;

            Console.WriteLine(Result.legoBlocks(n, m));
            Console.WriteLine("Expected: 7");
        }
        static void TestNoPrefixFile()
        {

            StreamReader sr = new StreamReader(Directory.GetCurrentDirectory() + "\\input41.txt");
            int n = Convert.ToInt32(sr.ReadLine().Trim());

            List<string> words = new List<string>();

            for (int i = 0; i < n; i++)
            {
                string wordsItem = sr.ReadLine();
                words.Add(wordsItem);
            }

            Result.noPrefix(words);
        }
        static void TestNoPrefix()
        {
            List<string> sl;

            sl = new() { "ab", "a"};
            Result.noPrefix(sl);
            Console.WriteLine("Expected: BAD SET a");

            sl = new() { "abcde", "fghi", "j", "hij" };
            Result.noPrefix(sl);
            Console.WriteLine("Expected: GOOD SET");

            sl = new() { "abcde", "fghi", "fghij", "qerstu" };
            Result.noPrefix(sl);
            Console.WriteLine("Expected: BAD SET fghij");

            sl = new() { "aab", "defgab", "abcde", "aabcde", "bbbbbbbbbb", "jabjjjad" };
            Result.noPrefix(sl);
            Console.WriteLine("Expected: BAD SET aabcde");

        }
        static void TestBSF()
        {
            List<List<int>> edges = new()
            {
                new() { 1, 2 },
                new() { 1, 3 },
                new() { 3, 4 }
            };

            int n = 5;
            int m = 3;
            int s = 1;

            Console.WriteLine(String.Join(",", Result.bfs(n, m, edges, s)));
            Console.WriteLine("Expected: 6, 6, 12, -1");
        }
        static void TestMergeLinkedList()
        {

            SinglyLinkedList list1 = new SinglyLinkedList();
            list1.InsertNode(10);
            list1.InsertNode(20);
            list1.InsertNode(30);
            list1.InsertNode(40);

            SinglyLinkedList list2 = new SinglyLinkedList();
            list2.InsertNode(15);
            list2.InsertNode(25);
            list2.InsertNode(35);
            list2.InsertNode(45);

            SinglyLinkedListNode node = SinglyList.mergeLists(list1.head, list2.head);

            // StreamWriter streamWriter = new StreamWriter(Directory.GetCurrentDirectory() + "\\SinglyListOutput.txt");

            SinglyList.PrintSinglyLinkedList(node, " ",Console.Out);

        }
        static void TestTruckTour()
        {
            List<List<int>> list = new()
            {
                new() { 2,2 },
                new() { 2,2 },
                new() { 2,4 },
                new() { 4,2 }
            };

            Console.WriteLine(Result.truckTour(list));
            Console.WriteLine("Expected: 3");

        }
        static void TestMinimumBribes()
        {
            List<int> q;

            q = new List<int> { 3, 2, 1, 4, 5, 6, 7, 8 };
            Result.minimumBribes(q);
            Console.WriteLine("Expected: 3");

            q = new List<int> { 1, 2, 5, 4, 3, 6, 7, 8 };
            Result.minimumBribes(q);
            Console.WriteLine("Expected: 3");

            q = new List<int> { 1, 2, 5, 3, 7, 8, 6, 4 };
            Result.minimumBribes(q);
            Console.WriteLine("Expected: 7");

            q = new List<int> { 1, 2, 5, 6, 3, 4, 7, 8 };
            Result.minimumBribes(q);
            Console.WriteLine("Expected: 4");

            q = new List<int> { 1, 2, 5, 6, 3, 4, 7, 8 };
            Result.minimumBribes(q);
            Console.WriteLine("Expected: 4");

            q = new List<int> { 1, 2, 5, 3, 4, 6, 7, 8 };
            Result.minimumBribes(q);
            Console.WriteLine("Expected: 2");

            q = new List<int> { 1, 2, 3, 5, 4, 6, 7, 8 };
            Result.minimumBribes(q);
            Console.WriteLine("Expected: 1");

            q = new List<int> { 1, 2, 5, 3, 4, 6, 7, 8 };
            Result.minimumBribes(q);
            Console.WriteLine("Expected: 2");

            q = new List<int> { 1, 5, 2, 3, 4, 6, 7, 8 };
            Result.minimumBribes(q);
            Console.WriteLine("Expected: Too Chaotic");
        }
        static void TestSuperDigit()
        {
            string n = "9875";
            int k = 4;

            Console.WriteLine(Result.superDigit(n, k));
            Console.WriteLine("Expected: 8");
        }
        static void TestGridChallenge()
        {
            List<string> grid = new List<string> { "abc", "ade", "efg" };

            Console.WriteLine(Result.gridChallenge(grid));
            Console.WriteLine("Expected: YES");

            grid = new List<string> { "abh", "ade", "efg" };

            Console.WriteLine(Result.gridChallenge(grid));
            Console.WriteLine("Expected: NO");

            grid = new List<string> { "abc", "hjk", "mpq", "rtv" };
            Console.WriteLine(Result.gridChallenge(grid));
            Console.WriteLine("Expected: YES");

            grid = new List<string> { "abc", "hjz", "mpq", "rtv" };
            Console.WriteLine(Result.gridChallenge(grid));
            Console.WriteLine("Expected: NO");

        }
        static void TestPalindromeIndex()
        {
            string s = "ASDFFDSAX";
            Console.WriteLine(Result.palindromeIndex(s));
            Console.WriteLine("Expected 8");

            s = "aaaaaaaaaaaaaaaaaaaaaaraaaaaaaaaaaaataaaaa";
            Console.WriteLine(Result.palindromeIndex(s));
            Console.WriteLine("Expected -1");

            s = "aaab";
            Console.WriteLine(Result.palindromeIndex(s));
            Console.WriteLine("Expected 3");

            s = "baa";
            Console.WriteLine(Result.palindromeIndex(s));
            Console.WriteLine("Expected 0");

            s = "aaa";
            Console.WriteLine(Result.palindromeIndex(s));
            Console.WriteLine("Expected -1");

            s = "Felipe4epileF";
            Console.WriteLine(Result.palindromeIndex(s));
            Console.WriteLine("Expected -1");
        }
        static void TestCeasarCipher()
        {
            string s = "abcdefghi-----tuvwxyz----ABCDE---TUVWXTZ";
            int k = 1;

            Console.WriteLine(Result.caesarCipher(s, k));

        }
        static void TestTowerBreaker()
        {
            int n = 1;
            int m = 4;

            Console.WriteLine(Result.towerBreakers(n, m));
            Console.WriteLine("Expected: 1");
        }
        static void TestFlippingMatrix()
        {
            List<List<int>> matrix = new()
            {
                new() { 1, 2 },
                new() { 3, 4 }
            };

            Console.WriteLine(Result.flippingMatrix(matrix));
            Console.WriteLine("Expected: 4");

            matrix = new()
            {
                new() { 112, 42, 83, 119 },
                new() { 56, 125, 56, 49 },
                new() { 15, 78, 101, 43 },
                new() { 62, 98, 114, 108 }
            };


            Console.WriteLine(Result.flippingMatrix(matrix));
            Console.WriteLine("Expected: 414");

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

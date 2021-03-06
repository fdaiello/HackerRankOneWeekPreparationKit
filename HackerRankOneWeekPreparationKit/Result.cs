using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRankOneWeekPreparationKit
{
    class Result
    {
        /*
         *  https://www.hackerrank.com/challenges/one-week-preparation-kit-lego-blocks/
         *  
         *  Input: 
         *         n - wall height
         *         m - wall width
         *         
         *  OutPut
         *         Number of possible combinations, multiplied by 10 exp 9 + 7
         *         
         *  BUG!!!!!???????????????
         */
        public static int legoBlocks(int n, int m)
        {
            // magic number we have to multiply before returning result
            const double mod =  10e9f + 7;

            // Widht of lego blocks available - all heights equal 1. So we have theese blocks: 1x1 1x2 1x3 1x4
            List<int> blocks = new List<int> { 1, 2, 3, 4 };

            // Memo array for all sub width width, from 0 to m
            double[] f = new double[m + 1];

            // Initialize array. Position 0 set to 1 ( one possibility of building for w =0 with 0 blocks ).
            f[0] = 1;

            // For all sub width
            for ( int w = 0; w<=m; w++)
            {
                // For each block
                foreach ( int block in blocks)
                {
                    // If block fits with, increase possibility array. Consider all possible ways already computed to sw-block -> w[sw-block]
                    if ( block <= w)
                    {
                        f[w] += f[w - block];
                    }
                }
            }

            // Power height
            double[] g = new double[m + 1];
            for (int i = 1; i <= m; i++)
                g[i] = Math.Pow(f[i], n);

            // Now lets subtract invalid blocks
            double[] h = new double[m + 1];
            h[1] = 1;

            // BUG!!!!!???????????????
            for (int i = 2; i <= m; i++)
            {
                h[i] = g[i];
                double tmp = 0;
                for (int j = 1; j < i; j++)
                    tmp += h[j] * g[i - j];
                h[i] = h[i] - tmp;
            }


            // Return all possibilities
            return (int)(h[m] % mod);

        }
        /*
         *   https://www.hackerrank.com/challenges/one-week-preparation-kit-no-prefix-set
         */
        public static void noPrefix(List<String> words)
        {
            // Trie Root node
            TrieNode trie = new TrieNode();

            // Traverse string list
            foreach ( string word in words)
            {
                // Trie Node pointer
                TrieNode node = trie;

                // Traverse chars in word
                foreach ( char c in word)
                {
                    if (node.Children[c-'a'] == null)
                    {
                        node.Children[c-'a'] = new TrieNode();
                        node.HasChild = true;
                    }

                    node = node.Children[c-'a'];

                    // Check for previus prefix word saved up to here
                    if (node.End)
                    {
                        Console.WriteLine("BAD SET");
                        Console.WriteLine(word);
                        return;
                    }

                }

                // Check for continuing word - this is a prefix
                if (node.HasChild)
                {
                    Console.WriteLine("BAD SET");
                    Console.WriteLine(word);
                    return;
                }

                // Mark end of node
                node.End = true;
            }

            Console.WriteLine("GOOD SET");
        }
        /*
         * https://www.hackerrank.com/challenges/one-week-preparation-kit-tree-preorder-traversal
         */
        public class Node
        {
            public Node(int _data)
            {
                data = _data;
            }
            public int data;
            public Node left;
            public Node right;
        }

        public static void preOrder(Node root)
        {
            Console.WriteLine(root.data);
            if (root.left != null)
                preOrder(root.left);
            if (root.right != null)
                preOrder(root.right);
        }

        public static Node insert(Node root, int data)
        {
            if (root == null)
            {
                return new Node(data);
            }
            else
            {
                Node cur;
                if (data <= root.data)
                {
                    cur = insert(root.left, data);
                    root.left = cur;
                }
                else
                {
                    cur = insert(root.right, data);
                    root.right = cur;
                }
                return root;
            }
        }
        /*
         * https://www.hackerrank.com/test/3g7sntr46mr/questions/4rcfp2hh0ge
         * 
         *   n - number of nodes
         *   m - number of edges
         *   edges - list of pair of nodes representing one edge
         *   s - starting point
         *   
         *   Return a list of nodes ( except start node ) with distance of each node to start node
         *   Use Breadth First Search ( check all nodes of each level before moving to next level 
         *   
         */
        public static List<int> bfs(int n, int m, List<List<int>> edges, int s)
        {

            // Build the graph representation with a square matrix
            int[,] graph = new int[n+1, n+1];
            foreach(List<int> edge in edges)
            {
                graph[edge[0], edge[1]] = 1;
                graph[edge[1], edge[0]] = 1;
            }

            // Traverse the graph. Breadth First Serch requires a Queue
            Queue<Tuple<int,int>> queue = new Queue<Tuple<int,int>>();
            int level = 0;
            queue.Enqueue(new Tuple<int, int>(s, level));
            int node;

            // List of visited nodes - to avoid Loops
            List<int> visited = new List<int>();

            // Map of distances from start
            Dictionary<int, int> md = new Dictionary<int, int>();
            for (int i =1; i<= n; i++)
            {
                md.Add(i, -1);
            }

            while ( queue.Any())
            {
                // Get next queued node
                Tuple<int, int> tuple = queue.Dequeue();
                node = tuple.Item1;
                level = tuple.Item2;

                // Save node and level
                md[node] = level;
                level++;

                // Enqueue all child
                for ( int i =1; i<=n; i++)
                {
                    if (graph[node, i] == 1 && ! visited.Contains(i))
                    {
                        // mark as visited
                        visited.Add(i);
                        // enqueue child
                        queue.Enqueue(new Tuple<int, int>(i,level));
                    }
                }
            }

            // Build return list from map of distances
            List<int> rl = new List<int>();
            for ( int i =1; i <=n; i++)
            {
                if ( i != s)
                {
                    if (md[i] > 0)
                        rl.Add(md[i] * 6);
                    else
                        rl.Add(-1);
                }
            }

            return rl;
        }
        /*
         * Representing a Graph with GraphNode Class
         * Has some bug I could'n find
         */
        public static List<int> bfs1(int n, int m, List<List<int>> edges, int s)
        {
            // Graph Map of nodes
            Dictionary<int, GraphNode> graph = new Dictionary<int, GraphNode>();

            // Build Graph
            foreach(List<int> edge in edges)
            {
                int node1Number = edge[0];
                int node2Number = edge[1];

                GraphNode node1;
                if (graph.ContainsKey(node1Number))
                {
                    node1 = graph[node1Number];
                }
                else
                {
                    node1 = new GraphNode(node1Number);
                }

                GraphNode node2;
                if (graph.ContainsKey(node2Number))
                {
                    node2 = graph[node2Number];
                }
                else
                {
                    node2 = new GraphNode(node2Number);
                }

                node1.AddEdge(node2);
                node2.AddEdge(node1);

                if (graph.ContainsKey(node1.Value))
                {
                    graph[node1.Value] = node1;
                }
                else
                {
                    graph.Add(node1.Value, node1);
                }

                if (graph.ContainsKey(node2.Value))
                {
                    graph[node2.Value] = node2;
                }
                else
                {
                    graph.Add(node2.Value, node2);
                }
            }


            // Distance Map
            SortedDictionary<int, int> dMap = new SortedDictionary<int, int>();
            for ( int i = 1; i<=n; i++)
            {
                dMap.Add(i, -1);
            }

            // Traverse Graph from start node
            int level = 0;
            Queue<Tuple<int,int>> queue = new Queue<Tuple<int,int>>();
            queue.Enqueue(new Tuple<int, int>(s, level));

            while (queue.Any())
            {
                Tuple<int, int> tuple = queue.Dequeue();


                if (!graph.ContainsKey(tuple.Item1))
                {
                    throw new IndexOutOfRangeException($"Graph does not contains key:{tuple.Item1}");
                }

                GraphNode node = graph[tuple.Item1];
                level = tuple.Item2;

                // Check if not already already visited
                if (dMap[tuple.Item1] ==-1)
                {
                    // Add distance to map
                    dMap[tuple.Item1] = level;

                    level++;

                    foreach (GraphNode childNode in node.edges)
                    {
                        queue.Enqueue(new Tuple<int, int>(childNode.Value, level));
                    }
                }
            }


            // Create List based on Map
            List<int> result = new List<int>();

            foreach( KeyValuePair<int,int> kv in dMap)
            {
                if ( kv.Key != s)
                {
                    if (kv.Value > 0)
                        result.Add(kv.Value * 6);
                    else
                        result.Add(-1);
                }
            }
            return result;
        }
        /*
         *  List of petrol pumps
         *     List with two elements
         *       first - amount of fuel - each unit equals one unit of distance
         *       second - distance up to next pump
         */
        public static int truckTour(List<List<int>> petrolpumps)
        {

            // Amount of fuel
            int a;

            // Distance to next pump
            int d;

            // Test All start points
            for ( int startPoint =0; startPoint<petrolpumps.Count; startPoint++)
            {
                // Init current point with start point
                int currentPoint = startPoint;
                // Init counter of nodes
                int c = 0;

                // Init quantities
                a = 0;

                // Try to make the Loop
                while ( c< petrolpumps.Count)
                {
                    // Get amount of fuel and distance to next node
                    a += petrolpumps[currentPoint][0];
                    d = petrolpumps[currentPoint][1];

                    // Can we get there?
                    a = a - d;

                    if ( a<0)
                    {
                        break;
                    }

                    // Node counters
                    c++;

                    // Current Node counter
                    currentPoint++;
                    if (currentPoint == petrolpumps.Count)
                        currentPoint = 0;
                }

                // Reached end?
                if (c == petrolpumps.Count)
                    return startPoint;
            }

            return -1;
        }

        /*
         * https://www.hackerrank.com/challenges/one-week-preparation-kit-new-year-chaos/
         */
        public static void minimumBribes(List<int> q)
        {
            int bribes = 0;
            int tmp;

            for (int i = 0; i < q.Count; i++)
            {
                if (q[i] - i - 1 > 2)
                {
                    Console.WriteLine("Too chaotic");
                    return;
                }
            }

            bool swapped;
            do
            {
                swapped = false;
                for ( int i = 0; i<q.Count-1; i++)
                {
                    if (q[i] > q[i + 1])
                    {
                        bribes++;
                        swapped = true;
                        tmp = q[i];
                        q[i] = q[i + 1];
                        q[i + 1] = tmp;
                    }
                }


            } while (swapped);

            Console.WriteLine(bribes);

        }
        public static void minimumBribes0(List<int> q)
        {
            int bribes = 0;
            int bribers = 0;
            
            for ( int i =0; i< q.Count; i++)
            {
                if ( q[i] - i  -1 > 2)
                {
                    Console.WriteLine("Too chaotic");
                    return;
                }
                else if (q[i] - i - 1 > 0)
                {
                    bribes += q[i] - i - 1;
                    bribers += 1;
                }
                else if ( bribers > 0)
                {
                    bribers = 0;
                }

            }

            Console.WriteLine(bribes);

        }
        /*
         * https://www.hackerrank.com/challenges/one-week-preparation-kit-recursive-digit-sum
         */
        public static int superDigit(string n, int k) { 

            return SuperDigit0(n,k);

        }
        static int SuperDigit0(string n, int k)
        {
            if (n.Length == 1)
                return Int32.Parse(n);
            else
            {
                long sum = 0;
                for ( int i =0; i < n.Length; i++)
                {
                    sum += Int32.Parse(n[i].ToString());
                }
                sum *= k;
                return SuperDigit0(sum.ToString(),1);
            }
        }
        /*
         * https://www.hackerrank.com/challenges/one-week-preparation-kit-grid-challenge/problem
         */
        public static string gridChallenge(List<string> grid)
        {
            char[][] nGrid = new char[grid.Count][];

            for (int i = 0; i < grid.Count; i++) {
                nGrid[i] = grid[i].ToCharArray();
                Array.Sort(nGrid[i]);
            } 

            for (int c=0; c < nGrid[0].Length; c++)
            {
                for ( int r=1; r<nGrid.Length; r++)
                {
                    if (nGrid[r][c] < nGrid[r - 1][c])
                        return "NO";
                }
            }

            return "YES";
        }
        /*
         * https://www.hackerrank.com/test/crlnp8rgs12/questions/a2b68fq8p7b
         */
        public static int palindromeIndex(string s)
        {
            int p1 = 0;
            int p2 = s.Length - 1;

            int r = -1;

            while ( p1<p2)
            {
                if (s[p1] == s[p2])
                {
                    p1++;
                    p2--;
                }
                else
                {
                    if ( s[p1+1] == s[p2] && r == -1)
                    {
                        r = p1;
                        p1++;
                    }
                    else if ( s[p1] == s[p2 - 1] && r==-1)
                    {
                        r = p2;
                        p2--;
                    }
                    else
                    {
                        return -1;
                    }
                }
            }

            return r;

        }

        /*
         * https://www.hackerrank.com/challenges/one-week-preparation-kit-caesar-cipher-1
         */
        public static string caesarCipher(string s, int k)
        {
            int aCode = 'a';
            int zCode = 'z';
            int q = zCode - aCode + 1;
            int delta = k % q;

            int aCode2 = 'A';
            int zCode2 = 'Z';

            int shifted;

            StringBuilder sb = new StringBuilder();

            for ( int i = 0; i < s.Length; i++)
            {
                if ( s[i]>=aCode && s[i]<= zCode)
                {
                    shifted = s[i] + delta;
                    if (shifted > zCode)
                        shifted = shifted - zCode + aCode -1;
                    sb.Append ((char)shifted);
                }
                else if (s[i] >= aCode2 && s[i] <= zCode2)
                {
                    shifted = s[i] + delta;
                    if (shifted > zCode2)
                        shifted = shifted - zCode2 + aCode2 - 1;
                    sb.Append((char)shifted);
                }
                else
                {
                    sb.Append(s[i]);
                }
            }

            return sb.ToString();
        }
        /*
         * https://www.hackerrank.com/challenges/one-week-preparation-kit-tower-breakers-1
         */
        public static int towerBreakers(int n, int m)
        {
            if (m == 1)
                return 2;
            else if (n % 2 == 0)
                return 2;
            else
                return 1;

        }
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
        /*
         *  Test Day Two
         *  
         *  Flipping the Matrix
         *  2n Matrix - square
         *  
         *  https://www.hackerrank.com/test/4nahpm20m33/questions/di1dm3kpigj
         *  
         *  Flip rows or columns
         *  Maximize sum at the upper left quadrant
         *  
         *  Trick: no need to really flip, just get max of every possible position
         */
        public static int flippingMatrix(List<List<int>> matrix)
        {
            // Sum return
            int sRet = 0;

            // Loop all left columns
            for ( int column=0; column < matrix.Count / 2; column++)
            {
                // Loop all upper rows
                for (int row = 0; row < matrix.Count/2; row++)
                {
                    // Get max of every simetric element in the 4 quadrants
                    int e1 = matrix[column][row];
                    int e2 = matrix[column][matrix.Count - row - 1];
                    int e3 = matrix[matrix.Count - column - 1][row];
                    int e4 = matrix[matrix.Count - column - 1][matrix.Count - row - 1];

                    // Get max of 4 and acumulate
                    sRet += Math.Max(e1, Math.Max(e2, Math.Max(e3, e4)));
                }
            }


            return sRet;
        }
    }


}

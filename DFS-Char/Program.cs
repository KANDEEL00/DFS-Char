﻿namespace DFS
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char[] vertices = new char[] { 'u', 'v', 'w', 'x', 'y', 'z' };
            /*
            u-v 0,1
            u-x 0,3
            v-y 1,4
            w-y 2,4
            w-z 2,5
            x-v 3,1
            y-x 4,3
            z-z 5,5
             */
            KeyValuePair<char, char>[] edges = new KeyValuePair<char, char>[] {
                    new KeyValuePair<char, char>('u','v'),
                    new KeyValuePair<char, char>('u','x'),
                    new KeyValuePair<char, char>('v','y'),
                    new KeyValuePair<char, char>('w','y'),
                    new KeyValuePair<char, char>('w','z'),
                    new KeyValuePair<char, char>('x','v'),
                    new KeyValuePair<char, char>('y','x'),
                    new KeyValuePair<char, char>('z','z'),
            };
            DFS(vertices, edges);
        }
        public static Dictionary<char, char> DFS(char[] vertices, KeyValuePair<char, char>[] edges)
        {
            //connect each vertex to his edges
            //List<int>[] conn = new List<int>[vertices.Length];
            Dictionary<char, List<char>> Adj = new Dictionary<char, List<char>>();
            foreach (var i in edges)
            {
                if (Adj.ContainsKey(i.Key))
                {
                    Adj[i.Key].Add(i.Value);
                }
                else
                {
                    Adj.Add(i.Key, new List<char>());
                    Adj[i.Key].Add(i.Value);
                }

                //Undirected
                //Adj[i.Value].Add(i.Key);
            }
            //niggas
            int time = 0;
            //int[] d = new int[vertices.Length];//Discover
            //int[] f = new int[vertices.Length];//Finish
            //int[] p = new int[vertices.Length];//Parent

            Dictionary<char, int> color = new Dictionary<char, int>(vertices.Length);//color white=0 , grey = 1 , black = 2

            Dictionary<char, int> d = new Dictionary<char, int>(vertices.Length);//Discover
            Dictionary<char, int> f = new Dictionary<char, int>(vertices.Length);//Finish
            Dictionary<char, char> p = new Dictionary<char, char>(vertices.Length);//Parent

            foreach (char u in vertices)
            {
                if (!color.ContainsKey(u))
                {
                    DFSVisit(u);
                }

            }
            void DFSVisit(char u)
            {
                color[u] = 1; //discoverd
                time++;
                d[u] = time;
                foreach (char v in Adj[u])
                {
                    if (!color.ContainsKey(v)) //new
                    {
                        p[v] = u;
                        DFSVisit(v);
                    }
                }
                color[u] = 2; //explored(finished)
                time++;
                f[u] = time;
            }

            foreach (char u in vertices)
                Console.Write("------");
            Console.WriteLine();
            Console.Write("| Vertex   | ");
            foreach (char u in vertices)
                Console.Write(u + " | ");
            Console.WriteLine();

            Console.Write("| Discover | ");
            foreach (char u in vertices)
                Console.Write(d[u] + " | ");
            Console.WriteLine();

            Console.Write("| Finish   | ");
            foreach (char u in vertices)
                Console.Write(f[u] + " | ");
            Console.WriteLine();

            Console.Write("| Parent   | ");
            foreach (char u in vertices)
            {
                if (!p.ContainsKey(u)) p[u] = '-';
                Console.Write(p[u] + " | ");
            }
            Console.WriteLine();
            foreach (char u in vertices)
                Console.Write("------");
            Console.WriteLine();

            return p;
        }
    }
}

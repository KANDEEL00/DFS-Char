namespace DFS
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char[] vertices = new char[] { 'u', 'v', 'w', 'x', 'y', 'z' };
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
            //Adjacent vertices
            Dictionary<char, List<char>> Adj = new Dictionary<char, List<char>>();
            foreach (var i in edges)
            {
                if (!Adj.ContainsKey(i.Key))
                    Adj.Add(i.Key, new List<char>());
                Adj[i.Key].Add(i.Value);
                //Undirected
                if (!Adj.ContainsKey(i.Value))
                    Adj.Add(i.Value, new List<char>());
                Adj[i.Value].Add(i.Key);
            }
            //needed Data Structures to track DFS
            Dictionary<char, int> color = new Dictionary<char, int>(vertices.Length);//color white=NULL , grey = 1 , black = 2
            Dictionary<char, char> p = new Dictionary<char, char>(vertices.Length);//Parent
            Dictionary<char, int> d = new Dictionary<char, int>(vertices.Length);//Discover
            Dictionary<char, int> f = new Dictionary<char, int>(vertices.Length);//Finish
            int time = 0;
            //iterate each vertex
            foreach (char u in vertices)
            {
                if (!color.ContainsKey(u))//NULL = white(new, first time to visit)
                {
                    DFSVisit(u);
                }

            }
            void DFSVisit(char u)
            {
                color[u] = 1; //discovered(visited)
                time++;//time increases each time we pass on edge
                d[u] = time;//time of discovering this vertex (will help for knowing edge type)
                foreach (char v in Adj[u])
                {
                    if (!color.ContainsKey(v)) //new,same as above 
                    {
                        p[v] = u; //but now the previous vertex is the parent of this vertex
                        DFSVisit(v); //iterate to the next vertex until there no new adjacent vertex
                    }
                }
                color[u] = 2; //explored(finished)
                time++;//time increases also while backtracking
                f[u] = time;//time of finish exploring this vertex (also will help for knowing edge type)
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

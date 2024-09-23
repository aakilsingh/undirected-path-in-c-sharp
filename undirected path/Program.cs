namespace undirected_path
{
    //Write a method, undirectedPath, that takes in a list of edges for an undirected graph and two nodes (nodeA, nodeB).
    //The method should return a boolean indicating whether or not there exists a path between nodeA and nodeB

    // the first thing we should do is convert our edge list to an adjaceny list (keys and values) because it is easier to traverse
    public class Program
    {
        public static Boolean undirectedPath(List<List<string>> edges, string nodeA, string nodeB)
        {
            Dictionary<string, List<string>> graph = buildGraph(edges);
            HashSet<string> visited = new HashSet<string>();
            return traverseBfs(graph, nodeA, nodeB, visited);
        }

        // method to traverse, also need to stores the nodes we visited. We create this method because we can take in the graph and traverse instead of the List of edges
        public static Boolean traverseDfs(Dictionary<string, List<string>> graph, string src, string dst,HashSet<string> visited)
        {
            if(src == dst)
            {
                return true;
            }

            if (visited.Contains(src)) { 
                
                return false;
            
            }
            visited.Add(src);

            foreach (string neighbour in graph.GetValueOrDefault(src)) {

                if (traverseDfs(graph, neighbour, dst, visited)) // if this returns true, also return true
                {
                    return true;
                }
            }
            return false;
            }


        // breadth first search, queue
        public static Boolean traverseBfs(Dictionary<string, List<string>> graph, string src, string dst, HashSet<string> visited)
        {
            Queue<string> queue = new Queue<string>();
            queue.Enqueue(src);

            while (queue.Count != 0)
            {
                var node = queue.Dequeue();
                if(node == dst)
                {
                    return true ;
                }


                foreach (string neighbour in graph.GetValueOrDefault(node))
                {
                    if (!visited.Contains(neighbour))
                    {
                        queue.Enqueue(neighbour);
                        visited.Add(node); // adding the node to the visited hash set
                    }
                }
            }
            return false;
        }
        


        // the first thing we should do is convert our edge list to an adjaceny list (keys and values) because it is easier to traverse
        public static Dictionary<string, List<string>> buildGraph(List<List<string>> edges)
        {
           Dictionary<string, List<string>> graph = new Dictionary<string, List<string>>(); // initialize the graph
            foreach (List<string> pair in edges) { 
            string a = pair.ElementAt(0); // getting the 2 nodes
            string b = pair.ElementAt(1);

                if (!graph.ContainsKey(a))
                {
                    graph.Add(a, new List<string>()); // adding the a node to the adjacency list as a key and adding empty list
                }
                if (!graph.ContainsKey(b))
                {
                    graph.Add(b, new List<string>());
                }
                graph[a].Add(b); // adding each other as neighbours
                graph[b].Add(a);
            }
            return graph;
        }

        public static void Main(string[] args)
        {
            List<List<string>> edges = new List<List<string>>
            {
                new List<string> {"i","j" },
                new List<string> {"k","i" },
                new List<string> {"m","k" },
                new List<string> {"k","l" },
                new List<string> {"o","n" },

        };
            Console.WriteLine(undirectedPath(edges, "j", "m")); 



    }
    }
}

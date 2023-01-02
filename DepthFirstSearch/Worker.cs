namespace DepthFirstSearch
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;

        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {

            Graph graph = new Graph(11);
            graph.AddEdge(1, 2, false);
            graph.AddEdge(1, 3, false);
            graph.AddEdge(2, 4, false);
            graph.AddEdge(4, 7, false);
            graph.AddEdge(3, 5, false);
            graph.AddEdge(3, 6, false);
            graph.AddEdge(5, 8, false);
            graph.AddEdge(8, 9, false);
            graph.AddEdge(9, 10, false);

            graph.DFS(_logger);
        }

        public class Graph
        {
            LinkedList<int>[] linkedListArray;

            public Graph(int v)
            {
                linkedListArray = new LinkedList<int>[v];
            }
            public void AddEdge(int u, int v, bool blnBiDir = true)
            {
                if (linkedListArray[u] == null)
                {
                    linkedListArray[u] = new LinkedList<int>();
                    linkedListArray[u].AddFirst(v);
                }
                else
                {
                    var last = linkedListArray[u].Last;
                    linkedListArray[u].AddAfter(last, v);
                }

                if (blnBiDir)
                {
                    if (linkedListArray[v] == null)
                    {
                        linkedListArray[v] = new LinkedList<int>();
                        linkedListArray[v].AddFirst(u);
                    }
                    else
                    {
                        var last = linkedListArray[v].Last;
                        linkedListArray[v].AddAfter(last, u);
                    }
                }
            }


            internal void DFSHelper(int src, bool[] visited, ILogger<Worker> logger)
            {
                visited[src] = true;
                Console.Write(src + "->");
                logger.LogDebug(src + "->");
                if (linkedListArray[src] != null)
                {
                    foreach (var item in linkedListArray[src])
                    {
                        if (!visited[item] == true)
                        {
                            DFSHelper(item, visited, logger);
                        }
                    }
                }
            }

            internal void DFS(ILogger<Worker> logger)
            {

                logger.LogDebug("DFS");
                bool[] visited = new bool[linkedListArray.Length + 1];
                DFSHelper(1, visited, logger);

            }
        }
    }
}
  
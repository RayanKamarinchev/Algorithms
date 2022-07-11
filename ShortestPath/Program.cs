int[,] graph = {
    { 0, 4, 0, 0, 0, 0, 0, 8, 0 },
    { 4, 0, 8, 0, 0, 0, 0, 11, 0 },
    { 0, 8, 0, 7, 0, 4, 0, 0, 2 },
    { 0, 0, 7, 0, 9, 14, 0, 0, 0 },
    { 0, 0, 0, 9, 0, 10, 0, 0, 0 },
    { 0, 0, 4, 0, 10, 0, 2, 0, 0 },
    { 0, 0, 0, 14, 0, 2, 0, 1, 6 },
    { 8, 11, 0, 0, 0, 0, 1, 0, 7 },
    { 0, 0, 2, 0, 0, 0, 6, 7, 0 }
};

Dijkstra(graph, 0, 9);

static void Dijkstra(int[,] graph, int source, int verticesCount)
{
    int[] distance = new int[verticesCount];
    bool[] shortestPathTreeSet = new bool[verticesCount];

    for (int i = 0; i < verticesCount; ++i)
    {
        distance[i] = int.MaxValue;
        shortestPathTreeSet[i] = false;
    }

    distance[source] = 0;

    for (int count = 0; count < verticesCount - 1; ++count)
    {
        int u = MinimumDistance(distance, shortestPathTreeSet, verticesCount);
        shortestPathTreeSet[u] = true;

        for (int v = 0; v < verticesCount; ++v)
            if (!shortestPathTreeSet[v] && Convert.ToBoolean(graph[u, v]) && distance[u] != int.MaxValue && distance[u] + graph[u, v] < distance[v])
                distance[v] = distance[u] + graph[u, v];
    }

    Print(distance, verticesCount);
}

static int MinimumDistance(int[] distance, bool[] shortestPathTreeSet, int verticesCount)
{
    int min = int.MaxValue;
    int minIndex = 0;

    for (int v = 0; v < verticesCount; ++v)
    {
        if (shortestPathTreeSet[v] == false && distance[v] <= min)
        {
            min = distance[v];
            minIndex = v;
        }
    }

    return minIndex;
}

static void Print(int[] distance, int verticesCount)
{
    Console.WriteLine("Vertex    Distance from source");

    for (int i = 0; i < verticesCount; ++i)
        Console.WriteLine($"{i}\t  {distance[i]}");
}
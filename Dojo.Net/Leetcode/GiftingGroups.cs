using System.Collections.Generic;
using System.Linq;

namespace Dojo.Net.Leetcode;

public class GiftingGroups
{
    public int CountGroupsBFS(List<string> related)
    {
        var G = GetAdjacencyList(related);
        bool[] visitedNodes = [.. Enumerable.Repeat(false, G.Count)];
        int groups = 0;

        for (int k = 0; k < visitedNodes.Length; k++)
        {
            if (!visitedNodes[k])
            {
                BFS(k, G, visitedNodes);
                groups += 1;
            }
        }

        return groups;
    }
    public int CountGroupsDFS(List<string> related)
    {
        var G = GetAdjacencyList(related);

        bool[] visitedNodes = [.. Enumerable.Repeat(false, G.Count)];

        int groups = 0;

        for (int k = 0; k < visitedNodes.Length; k++)
        {
            if (!visitedNodes[k])
            {
                DFS(k, G, visitedNodes);
                groups += 1;
            }
        }

        return groups;
    }

    private List<List<int>> GetAdjacencyList(List<string> related)
    {
        List<List<int>> G = [];
        for (int k = 0; k < related.Count; k++)
        {
            G.Add([]);
            for (int m = k + 1; m < related[k].Length; m++)
            {
                if (int.Parse(related[k][m].ToString()) == 1)
                    G[k].Add(m);
            }
        }
        return G;
    }

    private void DFS(int nodeId, List<List<int>> graph, bool[] visitedNodes)
    {
        List<int> neighbours = graph[nodeId];
        visitedNodes[nodeId] = true;
        foreach (int P in neighbours)
        {
            if (!visitedNodes[P])
                DFS(P, graph, visitedNodes);
        }
    }

    private void BFS(int nodeId, List<List<int>> graph, bool[] visitedNodes)
    {
        Queue<int> nodesToCheck = new();
        nodesToCheck.Enqueue(nodeId);
        visitedNodes[nodeId] = true;
        
        while(nodesToCheck.Count != 0)
        {
            int node = nodesToCheck.Dequeue();
            List<int> neighbours = graph[node];
            foreach(int item in neighbours)
            {
                nodesToCheck.Enqueue(item);
                visitedNodes[item] = true;
            }
        }

    }
}

using UnityEngine;
using System.Collections.Generic;
using System;

public class FusionDirector : MonoBehaviour
{
    public static FusionDirector Instance;
    public MutationNode mutationGraph = new MutationNode(0);

    public int car1 = 0;
    public int car2 = 2;
    public int result = -1;

    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    int CalculateLength(MutationNode start, MutationNode end)
    {
        List<int> visited = new List<int>();
        Queue<(MutationNode, int)> queue = new Queue<(MutationNode, int)>();

        visited.Add(start.id);
        queue.Enqueue((start,0));

        while (queue.Count != 0)
        {
            var (current, dist) = queue.Dequeue();

            if (current.id == end.id)
            {
                return dist;
            }

            foreach (MutationEdge edge in current.childs)
            {
                if (!visited.Contains(edge.to.id))
                {
                    visited.Add(edge.to.id);
                    queue.Enqueue((edge.to, dist + 1));
                }
            }
        }

        return -1;
    }

    void Start()
    {
        int nodeCount = 4;
        List<MutationNode> nodes = new List<MutationNode>();
        nodes.Add(mutationGraph);
        for (int i = 1; i < nodeCount; i++)
        {
            nodes.Add(new MutationNode(i));
        }

        mutationGraph.Add(nodes[0], 1, 1);

        nodes[0].Add(nodes[1], 1, 1);
        nodes[0].Add(nodes[2], 1, 1);
        nodes[0].Add(nodes[3], 1, 1);
    }

    bool CanFusion()
    {
        return car1 != -1 && car2 != -1;
    }

    void Fusion()
    {
        if (!CanFusion()) {
            return;
        }

        MutationNode node1 = new MutationNode(car1);
        MutationNode node2 = new MutationNode(car2);

        int mutation_count = CalculateLength(node1, node2);

        if (mutation_count == -1)
        {
            return;
        }

        Random rand = new Random();
        int randIdx = rand.Next(1);

        if (randIdx == 0)
        {
            result = node1.RandomWalk(mutation_count);
        } 
        else
        {
            result = node2.RandomWalk(mutation_count);
        }

        Debug.Log("Node Selected" + result);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

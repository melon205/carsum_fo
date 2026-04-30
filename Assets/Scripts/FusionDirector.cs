using UnityEngine;
using System.Collections.Generic;
using System;

public class FusionDirector : MonoBehaviour
{
    public static FusionDirector Instance;
    public MutationNode mutationGraph = new MutationNode(0);
    List<MutationNode> nodes = new List<MutationNode>();

    public int car1 = -1;
    public int car2 = -1;
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

    int CalculateLength(int start, int end)
    {
        List<int> visited = new List<int>();
        Queue<(MutationNode, int)> queue = new Queue<(MutationNode, int)>();

        visited.Add(start);
        queue.Enqueue((nodes[start], 0));

        while (queue.Count != 0)
        {
            var (current, dist) = queue.Dequeue();
            if (current.id == end)
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
        nodes.Add(mutationGraph);
        for (int i = 1; i < nodeCount; i++)
        {
            nodes.Add(new MutationNode(i));
        }

        nodes[0].Add(nodes[1], 1, 1);
        nodes[0].Add(nodes[2], 1, 1);
        nodes[0].Add(nodes[3], 1, 1);

        Fusion();
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

        int mutation_count = CalculateLength(car1, car2);

        if (mutation_count == -1)
        {
            return;
        }

        System.Random rand = new System.Random();
        int randIdx = rand.Next(0, 2);

        MutationNode node = nodes[randIdx == 0 ? car1 : car2];
        
        for (int i = 1; i < 10; i++)
        {
            int a = node.RandomVisit();
            node = nodes[a];
        }
        
        for (int i = 1; i < mutation_count; i++)
        {
            node = nodes[node.RandomVisit()];
        }
        
        result = node.id;

        Debug.Log("Node Selected: " + result);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

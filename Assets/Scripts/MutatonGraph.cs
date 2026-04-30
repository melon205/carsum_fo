using UnityEngine;
using System.Collections.Generic;
using System;
public class MutationNode {
    public int id;
    public List<MutationEdge> childs;

    public MutationNode(int nodeId) {
        id = nodeId;
        childs = new List<MutationEdge>();
    }

    public void Add(MutationNode other, int forwardWeight, int backwardWeight)
    {
        childs.Add(new MutationEdge(other, forwardWeight));
        other.childs.Add(new MutationEdge(this, backwardWeight));
    }

    MutationNode RandomVisit()
    {
        Random rand = new Random();
        List<int> partition = List<int>();
        
        int sum = 0;
        foreach (MutationEdge edge in childs)
        {
            sum += edge.weight;
            partition.Add(sum);
        }

        int randIdx = rand.Next(sum);

        for (int i = 0; i < partition.Count; i++)
        {
            if (partition[i] >= randIdx)
            {
                return MutationNode(i-1);
            }
        }

        Debug.LogWarning("Random visit failed");
        return MutationNode(0);
    }

    public MutationNode RandomWalk(int count)
    {
        MutationNode result = this;

        for (int i = 0; i < count; i++)
        {
            result = result.RandomVisit();
        }

        return result;
    }
}

public class MutationEdge {
    public MutationNode to;
    public int weight;

    public MutationEdge(MutationNode node, int edgeWeight) {
        to = node;
        weight = edgeWeight;
    }
}

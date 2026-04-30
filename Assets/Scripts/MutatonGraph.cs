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

    public int RandomVisit()
    {
        System.Random rand = new System.Random();
        List<int> partition = new List<int>();
        
        int sum = 0;
        foreach (MutationEdge edge in childs)
        {
            sum += edge.weight;
            partition.Add(sum * 100);
        }

        int randIdx = rand.Next(sum * 100);

        for (int i = 0; i < partition.Count; i++)
        {
            if (partition[i] >= randIdx)
            {
                return childs[i].to.id;
            }
        }

        Debug.LogWarning("Random visit failed");
        return -1;
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

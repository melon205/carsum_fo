using UnityEngine;
using System.Collections.Generic;
using System;

public class FusionDirector : MonoBehaviour
{
    public static FusionDirector Instance;
    public MutationNode mutationGraph = new MutationNode(0);
    List<MutationNode> nodes = new List<MutationNode>();

    public CarData car1 = new CarData();
    public CarData car2 = new CarData();
    public CarData result = new CarData();

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
        HashSet<int> visited = new HashSet<int>();
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

        car1.modifiers.Add(Modifier.OS);
        car2.modifiers.Add(Modifier.Overheat);

        Fusion();
    }

    public bool CanFusion()
    {
        return car1.id != -1 && car2.id != -1;
    }

    public void Fusion()
    {
        //Type Selection
        if (!CanFusion()) {
            return;
        }

        int carId1 = car1.id;
        int carId2 = car2.id;

        int mutationCount = CalculateLength(carId1, carId2);

        if (mutationCount == -1)
        {
            return;
        }

        mutationCount += (car1.mutagen + car2.mutagen) / 10;

        System.Random rand = new System.Random();
        int randIdx = rand.Next(0, 2);

        MutationNode node = nodes[randIdx == 0 ? carId1 : carId2];
        
        for (int i = 1; i < mutationCount; i++)
        {
            node = nodes[node.RandomVisit()];
        }
        
        int resultId = node.id;

        Debug.Log("Node Selected: " + resultId);

        //Modifier
        List<Modifier> modifierList = new List<Modifier>();
        modifierList.AddRange(car1.modifiers);
        modifierList.AddRange(car2.modifiers);

        List<Modifier> resultModifierList = new List<Modifier>();

        for (int i = 1; i < modifierList.Count / 2; i++)
        {
            resultModifierList.Add(modifierList[rand.Next(modifierList.Count)]);
        }

        result = new CarData(resultId, 0);
        result.modifiers = resultModifierList;
    }
}

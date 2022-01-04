using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinding : MonoBehaviour
{
    GridMapArrayDisplay GridMap;

    private void Awake()
    {
        GridMap = GetComponent<GridMapArrayDisplay>();
    }


    public void FindPath(Vector3 StartPos, Vector3 TargetPos)
    {
        Node StartNode = GridMap.NodeFromWorldPoint(StartPos);
        Node TargetNode = GridMap.NodeFromWorldPoint(TargetPos);

        List<Node> OpenSet = new List<Node>();
        HashSet<Node> ClosedSet = new HashSet<Node>();
        OpenSet.Add(StartNode);

        while (OpenSet.Count > 0)
        {
            Node currentNode = OpenSet[0];

        }
    }
}

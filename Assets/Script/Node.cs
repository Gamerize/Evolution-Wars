using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Node
{
    public bool walkable;
    public Vector3 worldPos;

    public int MovCost;

    public Node(bool m_walkable, Vector3 m_worldPos)
    {
        walkable = m_walkable;
        worldPos = m_worldPos;
    }

    public bool isEqual(Node b)
    {
        return (worldPos.x == b.worldPos.x) && (worldPos.z == b.worldPos.z);
    }
}

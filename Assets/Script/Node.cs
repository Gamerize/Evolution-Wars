using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    public bool walkable;
    public Vector3 worldPos;

    public Node(bool m_walkable, Vector3 m_worldPos)
    {
        walkable = m_walkable;
        worldPos = m_worldPos;
    }
}

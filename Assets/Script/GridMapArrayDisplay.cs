using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GridMapArrayDisplay : MonoBehaviour
{
    public Transform[] player;
    public LayerMask unwalkableMask;
    public Vector2 gridWorldSize;
    public float nodeRadius;
    Node[,] grid;

    float nodeDiameter;
    int gridSizeX, gridSizeY;

    private void Start()
    {

        nodeDiameter = nodeRadius * 2;
        gridSizeX = Mathf.RoundToInt(gridWorldSize.x / nodeDiameter);
        gridSizeY = Mathf.RoundToInt(gridWorldSize.y / nodeDiameter);
        DrawGrid();
    }

    void DrawGrid()
    {
        grid = new Node[gridSizeX, gridSizeY];
        Vector3 worldBottomLeft = transform.position - Vector3.right * gridWorldSize.x / 2 - Vector3.forward * gridWorldSize.y / 2;

        for (int x = 0; x < gridSizeX; x++)
        {
            for (int y = 0; y < gridSizeY; y++)
            {
                Vector3 worldPoint = worldBottomLeft + Vector3.right * (x * nodeDiameter + nodeRadius) + Vector3.forward * (y * nodeDiameter + nodeRadius);
                bool walkable = !(Physics.CheckSphere(worldPoint, nodeRadius, unwalkableMask));
                grid[x, y] = new Node(walkable, worldPoint);
            }
        }

    }


    public Node NodeFromWorldPoint(Vector3 worldPos)
    {
        float percentX = (worldPos.x + gridWorldSize.x / 2) / gridWorldSize.x;
        float percentY = (worldPos.z + gridWorldSize.y) / gridWorldSize.y;
        percentX = Mathf.Clamp01(percentX);
        percentY = Mathf.Clamp01(percentY);

        int x = Mathf.RoundToInt((gridSizeX - 1) * percentX);
        int y = Mathf.RoundToInt((gridSizeY - 1) * percentY);

        return grid[x, y];
    }

    public int NodeFromWorldPointX(Vector3 worldPos)
    {
        float percentX = (worldPos.x + gridWorldSize.x / 2) / gridWorldSize.x;
        percentX = Mathf.Clamp01(percentX);

        int x = Mathf.RoundToInt((gridSizeX - 1) * percentX);
        return x;
    }

    public int NodeFromWorldPointY(Vector3 worldPos)
    {
        float percentY = (worldPos.z + gridWorldSize.y) / gridWorldSize.y;
        percentY = Mathf.Clamp01(percentY);

        int y = Mathf.RoundToInt((gridSizeY - 1) * percentY);
        return y;
    }

    public bool CheckPlayerNode(Vector3 PlayerPos)
    {
        if (grid != null)
        {
            foreach (Node n in grid)
            {
                Node PlayerNode = NodeFromWorldPoint(PlayerPos);
                if (PlayerNode.isEqual(n))
                {
                    Debug.Log(PlayerPos);
                    return true;
                }
                else return false;
            }
        }
        return false;
    }

    public float GetNodeDistance(Node StartNode, Node TargetNode)
    {
        float DistX = Mathf.Abs(StartNode.worldPos.x - TargetNode.worldPos.x);
        float DistY = Mathf.Abs(StartNode.worldPos.z - TargetNode.worldPos.z);
        return DistX + DistY;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, new Vector3(gridWorldSize.x, 1, gridWorldSize.y));

        if (grid != null)
        {
            foreach (Node n in grid)
            {
                Gizmos.color = (n.walkable) ? Color.white : Color.red;
                for (int i = 0; i < player.Length; i++)
                {
                    Node PlayerNode = NodeFromWorldPoint(player[i].position);
                    if (PlayerNode.isEqual(n))
                    {
                        Gizmos.color = Color.blue;
                    }
                }
                Gizmos.DrawCube(n.worldPos, Vector3.one * (nodeDiameter - .1f));
            }
        }
    }
}


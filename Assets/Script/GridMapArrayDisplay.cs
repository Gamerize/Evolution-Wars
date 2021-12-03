using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridMapArrayDisplay : MonoBehaviour
{
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
        //GridMap gridmap = new GridMap(50, 50);

        //for (int i = 0; i < 50; i++)
        //{
        //    for (int j = 0; j < 50; j++)
        //    {
        //        TileSpawn(i, j);
        //    }
        //}
    }

    /*private void TileSpawn(int x, int y)
    {
        GameObject Map = new GameObject("X: "+x+" | Y: "+y);
        Map.transform.SetParent(gameObject.transform);
        Map.transform.position = new Vector3(-24.5f + x, 1, -24.5f + y);
    }*/

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

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, new Vector3(gridWorldSize.x, 1, gridWorldSize.y));

        if (grid != null)
        {
            foreach (Node n in grid)
            {
                Gizmos.color = (n.walkable) ? Color.white : Color.red;
                Gizmos.DrawCube(n.worldPos, Vector3.one * (nodeDiameter-.1f));
            }
        }
    }
}

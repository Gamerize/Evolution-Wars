using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridMapArrayDisplay : MonoBehaviour
{
    private void Start()
    {
        GridMap gridmap = new GridMap(50, 50);

        for(int i = 0; i < 50; i++)
        {
            for(int j = 0; j < 50; j++)
            {
                TileSpawn(i, j);
            }
        }
    }

    private void TileSpawn(int x, int y)
    {
        GameObject Map = new GameObject("X: "+x+" | Y: "+y);
        Map.transform.SetParent(gameObject.transform);
        Map.transform.position = new Vector3(-24.5f + x, 1, -24.5f + y);
    }
}

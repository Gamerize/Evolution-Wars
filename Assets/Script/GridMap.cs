using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class GridMap : MonoBehaviour
{
    private float length;
    private float width;
    private float cellsize;
    private float[,] gridMapArray;

    public GridMap(int width, int length, float cellsize)
    {
        this.width = width;
        this.length = length;
        this.cellsize = cellsize;

        gridMapArray = new float[width, length];

        for(int x = 0; x < gridMapArray.GetLength(0); x++)
        {
            for (int y = 0; y < gridMapArray.GetLength(1); y++)
            {
                UtilsClass.CreateWorldText(gridMapArray[x, y].ToString(), null, GetWorldPosition(x, y) ,20, Color.white, TextAnchor.MiddleCenter);
            }
        }
    }

    private Vector3 GetWorldPosition(int x, int z)
    {
        return new Vector3(x, 0, z) * cellsize;
    }

}

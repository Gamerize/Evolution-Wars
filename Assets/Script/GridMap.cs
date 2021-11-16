using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridMap : MonoBehaviour
{
    private float length;
    private float width;
    private float[,] gridMapArray;

    public GridMap(int width, int length)
    {
        this.width = width;
        this.length = length;

        gridMapArray = new float[width, length];

        Debug.Log(width + " " + length);
    }

}

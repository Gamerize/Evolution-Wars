using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridMap : MonoBehaviour
{
    private int length;
    private int width;
    private int[,] gridMapArray;

    public GridMap(int width, int length)
    {
        this.width = width;
        this.length = length;

        gridMapArray = new int[width, length];

        Debug.Log(width + " " + length);


    }

}

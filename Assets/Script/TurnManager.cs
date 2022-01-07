using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    public int TurnNum;
    public int TurnCount;
    // Update is called once per frame
    private void Start()
    {
        TurnCount = 0;
    }

    public int CurrentTurn()
    {
        TurnCount++;
        if (TurnCount > 10)
        {
            Debug.Log("reset turn");
            return TurnCount = 0;
        }
        Debug.Log(TurnCount);
        return TurnCount;
    }


}

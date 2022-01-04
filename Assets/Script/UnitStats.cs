using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitStats : MonoBehaviour
{
    //unit stats
    public int str;
    public int def;
    public int spd;
    public int skl;
    public int lck;
    public int mov;

    [SerializeField]Vector3 StartingPos;

    public string Class;

    private void Start()
    {
        transform.position = StartingPos;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

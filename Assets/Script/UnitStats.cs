using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

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

    public TextMeshProUGUI m_statsText;

    private void Start()
    {
        transform.position = StartingPos;
    }

    public void DisplayText()
    {
        m_statsText.text = "Class: " + Class + "\n--------\nStr: " + str + "\nDef: " + def + "\nSpd: " + spd + "\nSkl: " + skl + "\nLck:: " + lck + "\nMov: " + mov;
    }
}

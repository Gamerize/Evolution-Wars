using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurnTextDisplay : MonoBehaviour
{
    Text m_Text;
    public static int m_TurnValue;

    // Start is called before the first frame update
    void Start()
    {
        m_Text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        m_Text.text = "Turn " + m_TurnValue;
    }
}

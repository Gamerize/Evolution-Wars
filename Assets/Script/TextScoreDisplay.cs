using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateScoreText : MonoBehaviour
{
    Text m_Text;
    public static int m_AScoreValue;
    public static int m_BScoreValue;

    // Start is called before the first frame update
    void Start()
    {
        m_Text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        m_Text.text = m_AScoreValue + " V.S. " + m_BScoreValue;
    }
}

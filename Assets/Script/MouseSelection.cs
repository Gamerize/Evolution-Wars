using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MouseSelection : MonoBehaviour
{
    //Game objects
    public GameObject GridSelect;
    public GameObject[] Units;

    //layermask
    public LayerMask MapLayer;
    public LayerMask PlayerLayer;

    //Vector3
    public Vector3 m_WorldPos;
    RaycastHit hitData;
    Ray ray;

    bool PlayerSelected = false;

    //UI
    [SerializeField]TextMeshProUGUI m_StatsText;

    //Script
    public GridMapArrayDisplay GridArray;


    private void Update()
    { 
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hitData, 1000, MapLayer))
        {
            m_WorldPos = hitData.point;
            Debug.DrawLine(ray.origin, hitData.transform.position, Color.red, 1);
            Debug.Log(hitData.transform.gameObject);
            if(hitData.collider.tag == "Block")
            {
                GridSelect.SetActive(true);
                GridSelect.transform.position = new Vector3(m_WorldPos.x, m_WorldPos.y + 0.01f, m_WorldPos.z);
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out hitData, 1000, PlayerLayer))
            {
                m_WorldPos = hitData.point;
                Debug.Log(hitData.transform.gameObject);
                for (int i = 0; i < Units.Length; i++)
                {
                    if (Units[i].gameObject == hitData.transform.gameObject)
                    {

                    }
                }
            } 
        }
    }
}
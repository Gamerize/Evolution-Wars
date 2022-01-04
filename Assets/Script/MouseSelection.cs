using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MouseSelection : MonoBehaviour
{
    //Game objects
    public GameObject GridSelect;
    public GameObject[] WalkablePath;
    public GameObject[] Units;

    //layermask
    public LayerMask MapLayer;
    public LayerMask UnitLayer;

    //Vector3
    public Vector3 m_WorldPos;
    RaycastHit hitData;
    Ray ray;

    //UI
    [SerializeField]TextMeshProUGUI m_StatsText;

    //Script
    public GridMapArrayDisplay GridArray;
    public UnitStats[] Stats;


    private void Update()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hitData, 1000, MapLayer))
        {
            m_WorldPos = hitData.point;
            Debug.DrawLine(ray.origin, hitData.transform.position, Color.red, 1);
            Debug.Log(hitData.transform.gameObject);
            if (hitData.collider.tag == "Block")
            {
                GridSelect.SetActive(true);
                GridSelect.transform.position = new Vector3(m_WorldPos.x, m_WorldPos.y + 0.01f, m_WorldPos.z);
            }
        }

        if (Physics.Raycast(ray, out hitData, 1000, MapLayer) && Input.GetMouseButtonDown(0) && hitData.collider.tag == "Block")
        {
            m_WorldPos = hitData.point;
            Debug.DrawLine(ray.origin, hitData.transform.position, Color.red, 1);
            Debug.Log(hitData.transform.gameObject);
        }

        if (Physics.Raycast(ray, out hitData, 1000, UnitLayer) && Input.GetMouseButtonDown(1))
        {
            m_WorldPos = hitData.point;
            Debug.DrawLine(ray.origin, hitData.transform.position, Color.red, 1);
            Debug.Log(hitData.transform.gameObject);
            if (hitData.collider.tag == "Player")
            {
                
            }
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseSelection : MonoBehaviour
{
    public Vector3 worldPos;

    private void Update()
    {
        RaycastHit hitData;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if(Physics.Raycast(ray, out hitData, 1000) && Input.GetMouseButtonDown(0))
        {
            worldPos = hitData.point;
            Debug.DrawLine(ray.origin, hitData.transform.position, Color.red, 1);
            Debug.Log(hitData.transform.gameObject);
        }
    }
}

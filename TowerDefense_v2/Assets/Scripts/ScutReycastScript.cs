using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public class ScutReycastScript : MonoBehaviour
{
    List<Ray2D> pointList = new List<Ray2D>();
    void Update()
    {
        Vector2 rayVector = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Debug.DrawRay(rayVector, Vector3.forward * 20, Color.green);
        if (Input.GetMouseButtonDown(0))
        {
            var rayObj = PointRayCast(Input.mousePosition);
            rayObj.GetComponent<Image>().color = new Color(0,0,0);
             ;
        }
    }
    GameObject PointRayCast(Vector2 position)
    {
        PointerEventData pointerData = new PointerEventData(EventSystem.current);
        List<RaycastResult> resultsData = new List<RaycastResult>();
        pointerData.position = position;
        EventSystem.current.RaycastAll(pointerData, resultsData);
        if (resultsData.Count > 0)
        {
            return resultsData[0].gameObject;
        }
        return null;
    }
}

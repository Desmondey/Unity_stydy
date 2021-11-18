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
        //�P���u���q���p�x���r�p�~�y�u �{�p�����t�y�~�p�� �}���~�y�������p �r �{�p�����t�y�~�p���� �r 2D �������������p�~�����r�u
        Vector2 rayVector = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Debug.DrawRay(rayVector, Vector3.forward * 20, Color.green);
        //�D���q�p�r�|�u�~�y�u �����u�z�{�y �������y
        if (Input.GetMouseButtonDown(0))
        {
            var rayObj = PointRayCast(Input.mousePosition);
            if (rayObj !=  null)
            {
                rayObj.GetComponent<CellSelect>().SetIsWay(true);
                rayObj.GetComponent<Image>().color = new Color(0.4232645f, 0.9245283f, 0.0654147f);
            }          
        }
        //�T�t�p�|�u�~�y�u �����u�z�{�y �������y
        if (Input.GetMouseButtonDown(1))
        {
            var rayObj = PointRayCast(Input.mousePosition);
            if (rayObj != null)
            {
                rayObj.GetComponent<CellSelect>().SetIsWay(false);
                rayObj.GetComponent<Image>().color = new Color(0.7735849f, 0.2371841f, 0.2371841f);
            }
        }
    }
    //�U���~�{���y�� �����|�����u�~�y�� UI ���q���u�{���p ���� �{���p���t�y�~�p���p�} �{�|�y�{�p �}�����y
    GameObject PointRayCast(Vector2 position)
    {
        PointerEventData pointerData = new PointerEventData(EventSystem.current);
        List<RaycastResult> resultsData = new List<RaycastResult>();
        pointerData.position = position;
        EventSystem.current.RaycastAll(pointerData, resultsData);
        if (resultsData.Count > 0 && resultsData[0].gameObject.layer == 6)
        {
            return resultsData[0].gameObject;
        }
        return null;
    }
}
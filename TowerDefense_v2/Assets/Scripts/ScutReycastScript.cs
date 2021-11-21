using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public class ScutReycastScript : MonoBehaviour
{

    List<Ray2D> pointList = new List<Ray2D>();
    [SerializeField] private GameObject allWay;
    AllWayCells tempAllWay;
    private void Start()
    {
        tempAllWay = allWay.GetComponent<AllWayCells>();
    }
    void Update()
    {
        //�P���u���q���p�x���r�p�~�y�u �{�p�����t�y�~�p�� �}���~�y�������p �r �{�p�����t�y�~�p���� �r 2D �������������p�~�����r�u
        Vector2 rayVector = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Debug.DrawRay(rayVector, Vector3.forward * 20, Color.green);
        //�D���q�p�r�|�u�~�y�u �����u�z�{�y �������y
        if (Input.GetMouseButtonDown(0))
        {
            SetWayCell(PointRayCast(),true);   
        }
        //�T�t�p�|�u�~�y�u �����u�z�{�y �������y
        if (Input.GetMouseButtonDown(1))
        {
            SetWayCell(PointRayCast(), false);
        }
    }
    //�U���~�{���y�� �����|�����u�~�y�� UI ���q���u�{���p ���� �{���p���t�y�~�p���p�} �{�|�y�{�p �}�����y
    GameObject PointRayCast()
    {
        PointerEventData pointerData = new PointerEventData(EventSystem.current);
        List<RaycastResult> resultsData = new List<RaycastResult>();
        pointerData.position = Input.mousePosition;
        EventSystem.current.RaycastAll(pointerData, resultsData);

        if (resultsData.Count > 0 && resultsData[0].gameObject.layer == 6)
        {
            return resultsData[0].gameObject;
        }
        return null;
    }
    private void SetWayCell(GameObject PointRayCast, bool IsWayFlag)
    {
        if (PointRayCast.layer == 6)
        {
            Color color = IsWayFlag == true ? new Color(0.4232645f, 0.9245283f, 0.0654147f) : new Color(0.7735849f, 0.2371841f, 0.2371841f);
            var rayObj = PointRayCast;
            if (rayObj != null)
            {
                rayObj.GetComponent<CellSelect>().SetIsWay(IsWayFlag);
                rayObj.GetComponent<Image>().color = color;

                if (IsWayFlag)
                    tempAllWay.AddWayCell(rayObj);
                else
                    tempAllWay.DeleteWayCell(rayObj);
            }
        }
    }
}

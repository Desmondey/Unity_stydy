using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public class CreateWay : MonoBehaviour
{

    List<Ray2D> pointList = new List<Ray2D>();
    [SerializeField] private GameObject allWay;
    AllWayCells tempAllWay;
    ShutReycaster shutReycaster;
    private void Start()
    {
        tempAllWay = allWay.GetComponent<AllWayCells>();
        shutReycaster = GetComponent<ShutReycaster>();
    }
    void Update()
    {
        //„P„‚„u„€„q„‚„p„x„€„r„p„~„y„u „{„p„€„‚„t„y„~„p„„ „}„€„~„y„„„€„‚„p „r „{„p„€„‚„t„y„~„p„„„ „r 2D „„‚„€„ƒ„„„‚„p„~„ƒ„„„r„u
        Vector2 rayVector = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Debug.DrawRay(rayVector, Vector3.forward * 20, Color.green);
        //„D„€„q„p„r„|„u„~„y„u „‘„‰„u„z„{„y „„…„„„y
        if (Input.GetMouseButtonDown(0))
        {             
            SetWayCell(shutReycaster.PointRayCast(),true);   
        }
        //„T„t„p„|„u„~„y„u „‘„‰„u„z„{„y „„…„„„y
        if (Input.GetMouseButtonDown(1))
        {
            SetWayCell(shutReycaster.PointRayCast(), false);
        }
    }
    //„U„…„~„{„ˆ„y„‘ „„€„|„…„‰„u„~„y„‘ UI „€„q„Œ„u„{„„„p „„€ „{„€„p„‚„t„y„~„p„„„p„} „{„|„y„{„p „}„„Š„y

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

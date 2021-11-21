using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllWayCells : MonoBehaviour
{
    //„L„y„ƒ„„ „r„ƒ„u„‡ „‘„‰„u„u„{ „„…„„„y
    private List<GameObject> AllWayCell = new List<GameObject>();

    //„D„€„q„p„r„y„„„ „‘„‰„u„z„{„… „„…„„„y „r „|„y„ƒ„„
    public void AddWayCell(GameObject cell)
    {
        AllWayCell.Add(cell);
    }
    //„T„t„p„|„u„~„y„u „‘„‰„u„z„{„y „„…„„„y „y„x „|„y„ƒ„„„p
    public void DeleteWayCell(GameObject cell)
    {
        AllWayCell.Remove(cell);
    }
    //„P„€„|„…„‰„y„„„ „r„ƒ„u „‘„‰„u„z„{„y „„…„„„y
    public List<GameObject> GetAllWayCell()
    {
        return AllWayCell;
    }
    //„P„€„|„…„‰„y„„„ „r„ƒ„u „‘„‰„u„z„{„y „„…„„„y „„‚„u„€„q„‚„p„x„€„r„p„~„~„„u „r „ƒ„„„‚„€„{„…
    public string GetAllWayCellString()
    {
        string tempAllWayCell = "";
        foreach (GameObject item in AllWayCell)
        {
            tempAllWayCell += Convert.ToString(item.GetComponent<CellSelect>().CellId) + ",";
        }
        return tempAllWayCell;
    }
}

using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveMapSrc : MonoBehaviour
{
    public string path = "C:\\Unity projects\\TowerDefense_v2\\Assets\\SaveMaps";
    private string AllWayCells;
    private void Start()
    {
        
    }
    public void SaveMapInFolder()
    {
        SaveMap(path, GetLastMap());
    }
    private void SaveMap(string pathFolder, int cardNumber)
    {
        AllWayCells = GetComponent<AllWayCells>().GetAllWayCellString(); 
        StreamWriter writeMap = new StreamWriter(pathFolder + "/" + "Lvl_‡‚" + cardNumber);
        writeMap.WriteLine(AllWayCells);
        Debug.Log("„U„p„z„| „ƒ„€„‡„‚„p„~„v„~ „„€ „„…„„„y (" + path + ") „ƒ „„€„}„u„„„{„€„z " + cardNumber);
        writeMap.Close();        
    }

    public List<string> GetAllMapInFolder()
    {       
        List<string> tempArrStr = new List<string>();
        string tempString;
        string[] tempAllmap = Directory.GetFiles(path);
        foreach (string map in tempAllmap)
        //1.„P„€„|„…„‰„y„„„ „r„ƒ„u „†„p„z„|„y „„€ „„…„„„y path
        //2.„€„„„ƒ„u„‘„„„ „r„ƒ„u „†„p„z„|„ „ƒ „„€„}„u„„„{„€„z meta
        {
                tempString = map.Substring(map.IndexOf('‡‚') + 1);
                if (tempString.Contains("meta"))
                    continue;
                tempArrStr.Add(tempString);
        }
        return tempArrStr;
    }
    private int GetLastMap() 
    {
        List<int> tempMapList = new List<int>();
        int LastIntResult = 0;
        foreach (string tempStr in GetAllMapInFolder())
        {
            tempMapList.Add(int.Parse(tempStr));
        }
        //„P„€„|„…„‰„p„u„„ „~„p„y„q„€„|„„Š„u„u „‰„y„ƒ„|„€ + 1
        //„y„|„y
        //„X„y„ƒ„|„€ „„‚„€„„…„‹„u„~„~„€„u „„€ „‡„‚„€„~„€„|„€„s„y„y
        for (int i = 0; i <= tempMapList.Count + 1; i++)
        {
            if(tempMapList.Find((x) => x == i) >= i)
            {
                continue;
            }
            LastIntResult = i;
            break;
            
        }
        print(LastIntResult);
        return LastIntResult;
    }
}

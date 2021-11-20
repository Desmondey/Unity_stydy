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
        SaveMap(path, GetLastMap(path));
    }
    private void SaveMap(string pathFolder, int cardNumber)
    {
        AllWayCells = GetComponent<AllWayCells>().GetAllWayCellString(); 
        StreamWriter writeMap = new StreamWriter(pathFolder + "/" + "Lvl_��" + cardNumber);
        writeMap.WriteLine(AllWayCells);
        Debug.Log("�U�p�z�| ���������p�~�v�~ ���� �������y (" + path + ") �� �����}�u���{���z " + cardNumber);
        writeMap.Close();        
    }

    private int GetLastMap(string pathFolder)
    {
        int LastIntResult = 0;
        List<int> tempArr = new List<int>();
        string tempString;
        string[] tempAllmap = Directory.GetFiles(pathFolder);
        foreach (string map in tempAllmap)            
        //1.�P���|�����y���� �r���u ���p�z�|�y ���� �������y path
        //2.�������u������ �r���u ���p�z�|�� �� �����}�u���{���z meta
        {

            tempString = map.Substring(map.IndexOf('��')+1);
            if (tempString.Contains("meta"))
                continue;
            tempArr.Add(int.Parse(tempString));
        }
        //�P���|�����p�u�� �~�p�y�q���|�����u�u ���y���|�� + 1
        //�y�|�y
        //�X�y���|�� �������������u�~�~���u ���� �������~���|���s�y�y
        for (int i = 0; i <= tempArr.Count + 1; i++)
        {
            if(tempArr.Find((x) => x == i) >= i)
            {
                continue;
            }
            LastIntResult = i;
            break;
        }
        return LastIntResult;
    }
}

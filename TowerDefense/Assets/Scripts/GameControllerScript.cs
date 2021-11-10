using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControllerScript : MonoBehaviour
{
    int[] pathId = { 2, 24, 46, 47, 48, 49 , 50, 51, 52, 53,
        54, 55, 56, 57, 58, 59, 60, 61, 62, 63, 64, 65, 87, 109, 
        108, 107, 106, 105, 127, 149, 150, 151, 152, 153, 175, 
        197, 219, 241, 263};

    List<CallScript> AllCells = new List<CallScript>();
    public int CellCount;
    public GameObject cellsPref;
    public Transform cellGroup;
    private void Awake()
    {
        CreateCells();
    }
    void Start()
    {      
       
        CreatePath();
    }
    void CreateCells()
    {
        for (int i = 0; i < CellCount; i++)
        {
            GameObject tmpCell = Instantiate(cellsPref);
            tmpCell.transform.SetParent(cellGroup, false);
            tmpCell.GetComponent<CallScript>().id = i + 1;
            tmpCell.GetComponent<CallScript>().SetState(0);
            AllCells.Add(tmpCell.GetComponent<CallScript>());
        }
    }
    void CreatePath()
    {
        for (int i = 0; i < pathId.Length; i++)
        {

            AllCells[pathId[i] - 1].SetState(1);
        }
    }
}

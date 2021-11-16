using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LvlManagerScript : MonoBehaviour
{
    [SerializeField] private GameObject _cellPref;
    [SerializeField] private Transform _cellParent;

    public Sprite[] tileSpr = new Sprite[2];
    public List<GameObject> WayPoints = new List<GameObject>();
    GameObject[,] allCells = new GameObject[10,16];
    GameObject firstCell;
    public int fieldWidth, fieldHeight;
    int curWayX, curWayY;

    void Start()
    {
        CreateLvl();
        LoadWayPoints();
    }
    void CreateLvl()
    {
        Vector2 worldVec = Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height));
        for (int i = 0; i < fieldHeight; i++)
        {
            for (int j = 0; j < fieldWidth; j++)
            {
                int sprIndex = int.Parse(LoadLvlText(1)[i].ToCharArray()[j].ToString());
                Sprite spr = tileSpr[sprIndex];
                bool isGround = spr == tileSpr[1] ? true : false;

                CreateCell(j, i, worldVec, spr, isGround);
            }
        }
    }
    void CreateCell(int x, int y, Vector2 wVec, Sprite spr, bool isGround)
    {
        GameObject tempCell = Instantiate(_cellPref, wVec, Quaternion.identity);
        tempCell.transform.SetParent(_cellParent, false);
        tempCell.GetComponent<SpriteRenderer>().sprite = spr;

        float sprSizeX = tempCell.GetComponent<SpriteRenderer>().bounds.size.x;
        float sprSizeY = tempCell.GetComponent<SpriteRenderer>().bounds.size.y;

        tempCell.transform.position = new Vector2(wVec.x + (sprSizeX * x), wVec.y + (sprSizeY * -y));
        if (isGround)
        {
            tempCell.GetComponent<CallScript>().isGround = true;
            if (firstCell == null)
            {
                firstCell = tempCell;
                curWayX = x;
                curWayY = y;
            }
        }
        allCells[y, x] = tempCell;
    }
    string[] LoadLvlText(int lvlNumber)
    {
        TextAsset tmpTxt = Resources.Load<TextAsset>("LvlGround" + lvlNumber);
        string tempStr = tmpTxt.text.Replace(Environment.NewLine, string.Empty);
        return tempStr.Split(',');
    }
    void LoadWayPoints()
    {
        GameObject currWayGo;
        WayPoints.Add(firstCell);

        while (true)
        {
            currWayGo = null;
            if (curWayX > 0 && allCells[curWayY, curWayX - 1].GetComponent<CallScript>().isGround &&
                !WayPoints.Exists(x => x == allCells[curWayY, curWayX - 1]))
            {
                currWayGo = allCells[curWayY, curWayX - 1];
                curWayX--;
                Debug.Log("Next Cell is Left");
            }
            else if (curWayX < (fieldWidth - 1) && allCells[curWayY, curWayX + 1].GetComponent<CallScript>().isGround &&
                !WayPoints.Exists(x => x == allCells[curWayY, curWayX + 1]))
            {
                currWayGo = allCells[curWayY, curWayX + 1];
                curWayX++;
                Debug.Log("Next Cell is Right");
            }
            else if (curWayX < 0 && allCells[curWayY - 1, curWayX].GetComponent<CallScript>().isGround &&
                !WayPoints.Exists(x => x == allCells[curWayY - 1, curWayX]))
            {
                currWayGo = allCells[curWayY - 1, curWayX];
                curWayY--;
                Debug.Log("Next Cell is Up");
            }
            else if (curWayX < (fieldHeight - 1) && allCells[curWayY + 1, curWayX].GetComponent<CallScript>().isGround &&
                !WayPoints.Exists(x => x == allCells[curWayY + 1, curWayX]))
            {
                currWayGo = allCells[curWayY + 1, curWayX];
                curWayY++;
                Debug.Log("Next Cell is Down");
            }
            else
                break;

            WayPoints.Add(currWayGo);
        }
    }
}

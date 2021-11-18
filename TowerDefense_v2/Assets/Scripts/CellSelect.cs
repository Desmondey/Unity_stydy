using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellSelect : MonoBehaviour
{
    [SerializeField] private bool _isWay = false;
    public int CellId;

    public void SetIsWay(bool way)
    {
        _isWay = way;
    }
    public void SetCellId(int id)
    {
        CellId = id;
    }
}

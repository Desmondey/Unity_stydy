using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerationFields : MonoBehaviour
{
    [SerializeField] private GameObject _prefCellGround;
    [SerializeField] private GameObject _prefCellWay;
    private int _cellNumbers = 136;
    private void Start()
    {
        CreateField();
    }
    void CreateField()
    {
        for (int i = 0; i < _cellNumbers; i++)
        {
            GameObject tempCell = Instantiate(_prefCellGround);
            tempCell.transform.SetParent(transform, false);
        }
    }
}

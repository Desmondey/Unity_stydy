using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WayCreator : MonoBehaviour
{
    private GameObject _createWayButton;
    
    private void Start()
    {
        _createWayButton = GetComponent<GameObject>();
    }
    private void Update()
    {   
        Vector2 rayVector = Camera.main.ScreenToWorldPoint(Input.mousePosition);   
        Debug.DrawRay(rayVector, Vector3.forward * 20, Color.green);  
        if (Input.GetMouseButtonDown(0))
        {
            
            RaycastHit2D[] _clickOnObject = Physics2D.RaycastAll(rayVector, Vector3.forward, 20f);    

            //print("click))) "+ _clickOnObject[0]);
            foreach (var item in _clickOnObject)
            {
                print(item);
            }
            if (_clickOnObject != null)
            {
                print("popal");
                if (false)
                {
                   // _clickOnObject.collider.gameObject.GetComponent<CellSelect>().HitRay();
                }
            }              
        }
    }
    public void CreateWay()
    {
        
    }
}

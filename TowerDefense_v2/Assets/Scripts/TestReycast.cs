using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestReycast : MonoBehaviour
{

    private void Update()
    {
        //Ray2D ray = new Ray2D(transform.position, transform.forward);       
        //Debug.DrawRay(tempPos, Vector2.right * 20, Color.red);

        if (Input.GetMouseButtonDown(0))
        {
            Vector2 tempPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D tempHit = Physics2D.Raycast(tempPos, Vector3.forward);
            if (tempHit)
            {
                tempHit.transform.gameObject.SetActive(false);
                print("Est probitie");
            }
        }

    }
}

using System;
using System.Collections.Generic;
using UnityEngine;

public class CircleMove : MonoBehaviour
{
    [SerializeField] private float _speed;
    private Transform _circlePosition;
    private Vector2 _mouseClickEndPoint;
    private bool _mouseClickBool = false;    
    Vector3 dir = Vector3.zero;
    private void Update()
    {      
        if (Input.GetMouseButtonDown(0))
        {
            _mouseClickBool = true;
            _mouseClickEndPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);           
            print(_mouseClickEndPoint);
        }
        if (_mouseClickBool)
        {
            dir = (_mouseClickEndPoint - (Vector2)transform.position).normalized;
            transform.Translate(dir * _speed * Time.deltaTime);
        }

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CircleConsistentMove : MonoBehaviour
{
    [SerializeField] private Slider _speed;
    private LineRenderer _linerender;
    private List <Vector2> _mouseClickEndPoint;
    private bool _mouseClickBool = false;
    Vector2 dirVector;
    Vector2 dir = Vector2.zero;
    private void Start()
    {
        _linerender = GetComponent<LineRenderer>();
        _mouseClickEndPoint = new List<Vector2>();
        _linerender.startWidth = 5f;
        _linerender.endWidth = 5f;
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _mouseClickBool = true;
            dir = Camera.main.ScreenToWorldPoint(Input.mousePosition);            
            _mouseClickEndPoint.Add(dir);
            
        }
        if (_mouseClickBool)
        {
            
            dirVector = (_mouseClickEndPoint[0] - (Vector2)transform.position).normalized;
            transform.Translate(dirVector * _speed.value * Time.deltaTime * 10);
            _linerender.SetPosition(1,dirVector);
            if (Vector3.Distance(_mouseClickEndPoint[0], transform.position) < 0.05f)
            {
                //print("Hay)))");
                _mouseClickEndPoint.RemoveAt(0);
                if (_mouseClickEndPoint.Count == 0f)
                {
                    _mouseClickBool = false;
                }
            }
        }

    }
}

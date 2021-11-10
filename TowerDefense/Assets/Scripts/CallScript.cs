using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CallScript : MonoBehaviour
{
    public int state ,id;
    public Color normCol, pathCol;

    void Start()
    {
        
    }

    void Update()
    {
        
    }
    public void SetState(int i)
    {
        state = i;
        if (i == 0)
        {
            GetComponent<Image>().color = normCol;
        }
        if (i == 1)
        {
            GetComponent<Image>().color = pathCol;
        }
    }
}

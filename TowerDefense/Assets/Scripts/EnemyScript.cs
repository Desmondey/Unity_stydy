using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public GameObject WayPointsParent; // �R�|�u������ �~�p���������z�{�y �~�u �x�p�q������ �r�������p�r�y����
    List<GameObject> wayPoints = new List<GameObject>();
    int wayIndex = 0;
    public float speed = 15f;
    private void Start()
    {
        //wayPoints = GameObject.Find("Main Camera").GetComponent<GameControllerScript>().WayPoints;
        GetWayPoints();
    }
    private void Update()
    {
        Move();
    }
    private void Move()
    {
        Vector3 dir = wayPoints[wayIndex].transform.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, wayPoints[wayIndex].transform.position) < 0.3f)
        {
            if (wayIndex < wayPoints.Count - 1)
            {
                wayIndex++;
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
    public void GetWayPoints()
    {
        for (int i = 0; i < WayPointsParent.transform.childCount; i++)
        {
            wayPoints.Add(WayPointsParent.transform.GetChild(i).gameObject);
        }
    }
}

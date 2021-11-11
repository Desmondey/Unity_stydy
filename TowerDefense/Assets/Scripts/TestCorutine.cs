using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCorutine : MonoBehaviour
{
    [SerializeField] private GameObject _enemyPref;
    private Vector2 _enemySpawnVec;
    private void Start()
    {
        
    }
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            _enemySpawnVec = new Vector2(Random.Range(0.01f, 1f), Random.Range(0.1f, 2f));
            StartCoroutine("Spawn");
        }        
    }
    private IEnumerator Spawn()
    {
        GameObject Enemy = Instantiate(_enemyPref, _enemySpawnVec, Quaternion.identity);
        Enemy.transform.SetParent(gameObject.transform);
        yield return new WaitForSeconds(1f);
    }
}

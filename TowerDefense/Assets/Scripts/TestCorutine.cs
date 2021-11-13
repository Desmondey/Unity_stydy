using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCorutine : MonoBehaviour
{
    [SerializeField] private GameObject _enemyPref;
    private Vector2 _enemySpawnVec;
    private List<GameObject> _enemyList = new List<GameObject>();
    private void Start()
    {  
        StartCoroutine(Spawn());       
    }
    void Update()
    {           
        
    }
    private IEnumerator Spawn()
    {
        while (true)
        {   
            _enemySpawnVec = new Vector2(Random.Range(0.01f, 1f), Random.Range(0.1f, 2f));             
            GameObject Enemy = Instantiate(_enemyPref, _enemySpawnVec, Quaternion.identity);
            Enemy.transform.SetParent(gameObject.transform);
            _enemyList.Add(Enemy);
            yield return new WaitForSeconds(0.1f);
            if (_enemyList.Count >= 15f)
            {
                for (int i = 1; i <= _enemyList.Count - 8f; i++)
                {
                    print(i);
                    Destroy(_enemyList[i]);
                    _enemyList.RemoveAt(i);
                }
            }
        }
    }
    private void ClearEnemyList(List<GameObject> EnemyList)
    {
        EnemyList.Clear();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerScript : MonoBehaviour
{
    public float TimeToSpawn = 1f;
    int spawnCount = 0;
    public GameObject enemyPref, wayPointParent;
    private void Update()
    {
        if (TimeToSpawn <= 0)
        {
            StartCoroutine(SpawnEnemy(spawnCount + 1));
            TimeToSpawn = 4;
        }
        TimeToSpawn -= Time.deltaTime;
    }        
    IEnumerator SpawnEnemy(int enemyCount)
        {
            spawnCount++;
            for (int i = 0; i < enemyCount; i++)
            {
                GameObject tmpEnemy = Instantiate(enemyPref);
                tmpEnemy.transform.SetParent(gameObject.transform, false);
                tmpEnemy.GetComponent<EnemyScript>().WayPointsParent = wayPointParent;
                yield return new WaitForSeconds(0.2f);
            }           
        }
}

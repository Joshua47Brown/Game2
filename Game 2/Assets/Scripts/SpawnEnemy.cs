using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour {
    public GameObject enemy;
    public float enemySpawnRate = 1;
    public float enemySpawnRateTimer;

	void Update ()
    {
        if (enemySpawnRateTimer > 0)
        {
            enemySpawnRateTimer -= Time.deltaTime;
        }
        if (enemySpawnRateTimer < 0)
        {
            enemySpawnRateTimer = 0;
        }

        if (enemySpawnRateTimer == 0)
        {
            enemySpawnRateTimer = enemySpawnRate;
            Instantiate(enemy, transform.position, transform.rotation);
        }
    }
}

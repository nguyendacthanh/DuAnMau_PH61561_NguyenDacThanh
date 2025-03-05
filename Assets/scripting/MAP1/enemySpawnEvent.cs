using System.Collections;
using UnityEngine;

public class enemySpawnEvent : MonoBehaviour
{
    public GameObject enemy;
    public int maxEnemies = 5;
    private int count = 0;
    private void Start()
    {
        StartCoroutine(spawnEnemy());
    }
    IEnumerator spawnEnemy()
    {
        while (true)
        {
            if (count < maxEnemies)
            {
                float getRandomX = Random.Range(-60f, -5f);
                Vector3 viTriRandom_spawn = new Vector3(getRandomX, 30f, 1);
                GameObject newEnemy = Instantiate(enemy, viTriRandom_spawn, Quaternion.identity);
                count++;
                newEnemy.GetComponent<Enemy1>().spawnManager = this;

                yield return new WaitForSeconds(Random.Range(1, 5));
            }
            else { 
                yield return new WaitForSeconds(1f);

            }
        }
    }
    public void DecreaseEnemyCount()
    {
        count--;  
    }
}

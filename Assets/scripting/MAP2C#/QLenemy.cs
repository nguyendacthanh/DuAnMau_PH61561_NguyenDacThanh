using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QLenemy: MonoBehaviour
{
    public GameObject enemy; 
    public int maxEnemies = 7; 
    public float spawnTime = 2f; 
    public float moveTime = 2f; 

    private List<enemy> enemies = new List<enemy>(); 

    void Start()
    {
        StartCoroutine(SpawnEnemy());
        StartCoroutine(MoveEnemiesRandomly());
    }

    IEnumerator SpawnEnemy()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnTime);

            if (enemies.Count < maxEnemies)
            {
                float spawnX = Random.Range(-50f, -15f);
                float spawnY = 20f;
                GameObject newEnemyObj = Instantiate(enemy, new Vector3(spawnX, spawnY, 0), Quaternion.identity);

                enemy newEnemy = newEnemyObj.GetComponent<enemy>();
                if (newEnemy != null)
                {
                    newEnemy.SetQLenemy(this); 
                    enemies.Add(newEnemy); 
                }
            }
        }
    }

    public void RegisterEnemy(enemy enemy)
    {
        if (!enemies.Contains(enemy))
        {
            enemies.Add(enemy);
        }
    }

    IEnumerator MoveEnemiesRandomly()
    {
        while (true)
        {
            yield return new WaitForSeconds(moveTime);

            foreach (enemy enemy in enemies)
            {
                if (enemy != null)
                {
                    enemy.MoveToRandomPosition();
                }
            }
        }
    }
}

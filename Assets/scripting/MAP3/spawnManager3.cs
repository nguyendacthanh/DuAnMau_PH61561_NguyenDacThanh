using System.Collections;
using UnityEngine;

public class spawnManager3 :MonoBehaviour
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
                float getRandomY = Random.Range(-30f, -4f);
                Vector3 viTriRandom_spawn = new Vector3(27, getRandomY, 1);
                GameObject newEnemy = Instantiate(enemy, viTriRandom_spawn, Quaternion.identity);
                GameObject newEnemy2 = Instantiate(enemy, viTriRandom_spawn, Quaternion.identity);
                GameObject newEnemy3 = Instantiate(enemy, viTriRandom_spawn, Quaternion.identity);
                count++;
                newEnemy.GetComponent<enemy3>().spawnManager = this;

                yield return new WaitForSeconds(Random.Range(1, 5));
            }
            else
            {
                yield return new WaitForSeconds(1f);

            }
        }
    }
    public void DecreaseEnemyCount()
    {
        count--;
    }
}

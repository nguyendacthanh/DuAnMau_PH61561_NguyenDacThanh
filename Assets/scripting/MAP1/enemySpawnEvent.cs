using System.Collections;
using UnityEngine;

public class enemySpawnEvent : MonoBehaviour
{
    public GameObject enemy;
    private void Start()
    {
        StartCoroutine(spawnEnemy());
    }
    IEnumerator spawnEnemy() {
        while (true)
        {
            float getRandomX = Random.Range(-60f, -5f);
            Vector3 viTriRandom_spawn = new Vector3(getRandomX, 30f, 1);
            Instantiate(enemy, viTriRandom_spawn, Quaternion.identity);
            yield return new WaitForSeconds(Random.Range(1, 5));
        }
    }
}

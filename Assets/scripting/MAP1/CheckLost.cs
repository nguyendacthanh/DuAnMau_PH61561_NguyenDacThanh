using UnityEngine;

public class CheckLost : MonoBehaviour
{
    
    public GameObject lostPanel;        
    public GameObject enemySpawnEvent;
    public GameObject enemy;
    void Update()
    {
        CheckEnemyCount();
    }

    private void CheckEnemyCount()
    {
        int enemyCount = GameObject.FindGameObjectsWithTag("main").Length;
        
        if (enemyCount == 0) 
        {
            LostGame();
        }
    }

    private void LostGame()
    {
        DestroyAllEnemies();
        lostPanel.SetActive(true); 
        if (enemySpawnEvent != null)
        {
            enemySpawnEvent.SetActive(false);
            Destroy(enemy);

        }
    }
    void DestroyAllEnemies()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("enemy");

        foreach (GameObject enemy in enemies)
        {
            Destroy(enemy);
        }
    }
}

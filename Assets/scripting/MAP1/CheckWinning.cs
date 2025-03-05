using UnityEngine;

public class CheckWinning : MonoBehaviour
{
    public int totalEnemiesToWin = 2; // Số lượng enemy cần tiêu diệt để thắng
    public GameObject winPanel;        // Panel hiển thị khi chiến thắng
    public GameObject enemySpawnEvent; // Đối tượng spawn enemy cần tắt

    private int enemiesDefeated = 0; // Đếm số lượng enemy bị tiêu diệt

    public void EnemyDefeated()
    {
        enemiesDefeated++;

        if (enemiesDefeated >= totalEnemiesToWin)
        {
            WinGame();
        }
    }

    private void WinGame()
    {
        DestroyAllEnemies();
        winPanel.SetActive(true); // Hiển thị panel thắng
        if (enemySpawnEvent != null)
        {
            enemySpawnEvent.SetActive(false); // Tắt sự kiện spawn enemy
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

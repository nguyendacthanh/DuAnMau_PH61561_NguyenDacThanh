using UnityEngine;

public class CheckLost : MonoBehaviour
{
    public GameObject losePanel;       // Panel hiển thị khi thua
    public GameObject enemySpawnEvent; // Sự kiện spawn quái

    void Update()
    {
        CheckMainCharacter();
    }

    private void CheckMainCharacter()
    {
        // Tìm GameObject có tag "Main"
        GameObject mainCharacter = GameObject.FindGameObjectWithTag("main");

        // Nếu không tìm thấy Main thì hiển thị màn thua
        if (mainCharacter == null)
        {
            LostGame();
        }
    }

    private void LostGame()
    {
        DestroyAllEnemies();
        if (losePanel != null)
        {
            losePanel.SetActive(true); // Hiển thị panel thua
        }

        if (enemySpawnEvent != null)
        {
            enemySpawnEvent.SetActive(false); // Dừng spawn quái
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

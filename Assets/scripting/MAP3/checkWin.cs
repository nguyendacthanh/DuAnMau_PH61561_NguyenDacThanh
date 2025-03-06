using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class checkWin : MonoBehaviour
{
    public float gameTime = 90f; // 90 giây
    public GameObject winPanel; // Panel hiển thị khi thắng
    public GameObject enemySpawnEvent; // Đối tượng spawn enemy cần tắt
    public TMP_Text timerText; // (Tùy chọn) Hiển thị thời gian

    private float timer;

    void Start()
    {
        timer = gameTime;
    }

    void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;

            // Cập nhật hiển thị thời gian (nếu có UI)
            if (timerText != null)
            {
                timerText.text = "Thời gian: " + Mathf.Ceil(timer).ToString() + "s";
            }

            if (timer <= 0)
            {
                WinGame();
            }
        }
    }

    private void WinGame()
    {
        DestroyAllEnemies();
        winPanel.SetActive(true); // Hiển thị bảng thắng
        if (enemySpawnEvent != null)
        {
            enemySpawnEvent.SetActive(false); // Dừng spawn enemy
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

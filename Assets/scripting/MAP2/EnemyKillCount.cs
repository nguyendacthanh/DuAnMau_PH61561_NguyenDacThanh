using TMPro;
using UnityEngine;

public class EnemyKillCount : MonoBehaviour
{
    public int totalEnemiesToKill = 25; // Số quái cần tiêu diệt
    private int enemiesKilled = 0;      // Số quái đã tiêu diệt
    public TMP_Text enemyCounterText;   // Text hiển thị số quái đã giết

    void Start()
    {
        UpdateEnemyCounterUI(); 
    }
    

    public void IncreaseKillCount()
    {
        enemiesKilled++;  // Tăng số quái đã giết
        UpdateEnemyCounterUI();
    }

    void UpdateEnemyCounterUI()
    {
        if (enemyCounterText != null)
        {
            enemyCounterText.text = "Số lượng quái đã giết: " + enemiesKilled + "/" + totalEnemiesToKill;
        }
        else
        {
            Debug.LogWarning("⚠ Chưa gán TMP_Text cho enemyCounterText!");
        }
    }
}

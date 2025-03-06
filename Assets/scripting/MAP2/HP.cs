using System;
using TMPro;
using UnityEngine;

public class HP : MonoBehaviour
{
    Animator animator;
    [Header("Thiết lập HP")]
    public int maxHP = 5;         // HP tối đa, có thể chỉnh sửa trong Inspector
    public int currentHP;         // HP hiện tại

    [Header("Text hiển thị HP")]
    public TextMeshPro hpText;    // TMP sẽ được gán vào đây

    [Header("Vị trí HP")]
    public Vector3 offset = new Vector3(0, 1.5f, 0); // Điều chỉnh vị trí hiển thị HP

    void Start()
    {
        animator = GetComponent<Animator>();
            currentHP = maxHP; // Khởi tạo HP bằng maxHP
            UpdateHPUI();

    }

    void Update()
    {


        if (hpText != null)
        {
            hpText.transform.position = transform.position + offset; // Luôn đi theo nhân vật
        }

    }

    public void TakeDamage(int damage)
    {
        currentHP -= damage;  // Giảm HP
        UpdateHPUI();         // Cập nhật lại UI

        if (currentHP <= 0)
        {
            Die();
            if (this.gameObject.CompareTag("enemy"))
            {
                EnemyKillCount counter = FindAnyObjectByType<EnemyKillCount>();
                if (counter != null)
                {
                    counter.IncreaseKillCount();
                }
            }
            Destroy(gameObject);

        }
    }

    public void UpdateHPUI()
    {
        if (hpText != null)
        {
            hpText.text = "HP: " + currentHP; // Hiển thị HP dạng "HP: 3"
        }
        else
        {
            Debug.LogError("⚠ Chưa gán TextMeshPro cho nhân vật: " + gameObject.name);
        }
    }
    private void Die()
    {
        CheckWinning winManager = FindFirstObjectByType<CheckWinning>();

        if (winManager != null)
        {
            winManager.EnemyDefeated(); // Gọi hàm tăng số lượng enemy bị tiêu diệt
        }


        
            animator.SetTrigger("death");
            Destroy(gameObject, 0.5f);
        


    }
}

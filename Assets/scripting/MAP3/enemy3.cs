using System.Collections;
using UnityEngine;

public class enemy3 : MonoBehaviour
{
    private Rigidbody2D rb;


    //phan di chuyen
    public float moveSpeed = 15f;
    public float timePerMove = 2f;
    //public GameObject eventChanceMove;
    private bool isMovingRandom = false;

    //phan auto ban
    private Animator animator;
    public GameObject bullet;
    public Transform vitri;
    public bool canfire = true;


    public int damage = 1;


    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
        rb.linearVelocity = Vector2.down * moveSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        HP hp = collision.GetComponent<HP>();

        if (collision.gameObject.CompareTag("eventChanceMove") && !isMovingRandom)
        {
            isMovingRandom = true;
            StartCoroutine(SetRandomMove());
            StartCoroutine(setfirer());
        }
        if (collision.CompareTag("main"))
        {

            hp.TakeDamage(damage);
            animator.SetTrigger("death");
            Destroy(gameObject, 0.5f);
            Die();
        }

    }

    IEnumerator SetRandomMove()
    {
        rb.linearVelocity = Vector2.zero;

        while (true)
        {
            yield return new WaitForSeconds(timePerMove);

            float x = Random.Range(-50, 0);
            float y = Random.Range(-8, -7);
            Vector2 targetPosition = new Vector2(Random.Range(-65, -10), Random.Range(-11, -9));

            Vector2 moveDirection = (targetPosition - rb.position).normalized;

            rb.linearVelocity = moveDirection * moveSpeed;
        }
    }
    IEnumerator setfirer()
    {
        while (true)
        {
            yield return new WaitForSeconds(1.5f);
            animator.SetTrigger("enemy_atk");
            Instantiate(bullet, vitri.position, Quaternion.Euler(0, 0, 270));

        }

    }
    public enemySpawnEvent spawnManager;

    void OnDestroy()
    {
        if (spawnManager != null)
        {
            spawnManager.DecreaseEnemyCount();
        }
    }


    // đếm số lượng quái bị giết để theo dõi tiến trình hoàn thành nhiệm vụ, check điều kiện thắng
    private void Die()
    {
        CheckWinning winManager = FindFirstObjectByType<CheckWinning>();
        EnemyKillCount counter = FindAnyObjectByType<EnemyKillCount>();
        if (counter != null)
        {
            counter.IncreaseKillCount();
        }
        if (winManager != null)
        {
            winManager.EnemyDefeated();
        }

        Destroy(gameObject);
    }
}

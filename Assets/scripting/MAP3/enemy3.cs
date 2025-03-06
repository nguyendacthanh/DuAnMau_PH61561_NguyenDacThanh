using System.Collections;
using UnityEngine;

public class enemy3 : MonoBehaviour
{
    private Rigidbody2D rb;


    //phan di chuyen
    public float moveSpeed = 15f;
    public float timePerMove = 3f;
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
        rb.linearVelocity = Vector2.left * moveSpeed;
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

        }

    }

    IEnumerator SetRandomMove()
    {
        rb.linearVelocity = Vector2.zero;

        while (true)
        {
            yield return new WaitForSeconds(timePerMove);

            float x = Random.Range(-16, 0);
            float y = Random.Range(-30, -7);
            Vector2 targetPosition = new Vector2(Random.Range(-10, -5), Random.Range(-11, -9));

            Vector2 moveDirection = (targetPosition - rb.position).normalized;

            rb.linearVelocity = moveDirection * moveSpeed;
        }
    }
    IEnumerator setfirer()
    {
        while (true)
        {
            yield return new WaitForSeconds(3f);
            animator.SetTrigger("enemy_atk");
            Instantiate(bullet, vitri.position, Quaternion.identity);

        }

    }
    public spawnManager3 spawnManager;

    void OnDestroy()
    {
        if (spawnManager != null)
        {
            spawnManager.DecreaseEnemyCount();
        }
    }
}

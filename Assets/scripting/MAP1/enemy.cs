using System.Collections;
using UnityEngine;

public class enemy : MonoBehaviour
{
    private Rigidbody2D rb;


    //phan di chuyen
    public float moveSpeed = 15f;
    public float timePerMove = 2f;
    //phan auto ban
    private Animator animator;
    public GameObject bullet;
    public Transform vitri;
    public bool canfire = true;

    private bool movingUp = true;
    public int damage = 1;


    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
        rb.linearVelocity = Vector2.down * moveSpeed;
        if (canfire == true)
        {
            StartCoroutine(setfirer());
        }

    }
    void Update()
    {
        MoveCharacter();
        
    }

    void MoveCharacter()
    {
        if (movingUp)
        {
            rb.linearVelocity = new Vector2(0, moveSpeed);
        }
        else
        {
            rb.linearVelocity = new Vector2(0, -moveSpeed);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        HP hP = GetComponent<HP>();
        if (collision.gameObject.CompareTag("wall"))
        {
            movingUp = !movingUp; // Đảo hướng di chuyển
        }
        if (collision.gameObject.CompareTag("main"))
        {
            hP.TakeDamage(damage);
        }
    }

    IEnumerator setfirer()
    {
        while (true)
        {
            canfire = false;
            animator.SetTrigger("enemy_atk");
            Instantiate(bullet, vitri.position, Quaternion.Euler(0, 0, 0));
            yield return new WaitForSeconds(2f);

            canfire = true;
        }
    }
}

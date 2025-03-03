using System.Collections;
using UnityEngine;

public class Enemy1 : MonoBehaviour
{
    private Rigidbody2D rb;


    //phan di chuyen
    public float moveSpeed = 15f;
    public float timePerMove = 2f;
    //public GameObject eventChanceMove;
    private bool isMovingRandom = false;

    //phan auto ban
    public GameObject bullet;
    public Transform vitri;
    public bool canfire = true;
    

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
        rb.linearVelocity = Vector2.down * moveSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("eventChanceMove") && !isMovingRandom)
        {
            isMovingRandom = true;
            StartCoroutine(SetRandomMove());
            StartCoroutine(setfirer());
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
        while (true) {
            yield return new WaitForSeconds(1.5f);
            Instantiate(bullet,vitri.position, Quaternion.Euler(0, 0, 270));
        }
    
    }
}

using System.Collections;
using UnityEngine;

public class Main : MonoBehaviour
{
    private float moveSpeed = 20f;
    private Rigidbody2D rb;
    private Vector2 movement;
    public GameObject bulletPrefab;
    public Transform vitri;
    public float fireRate = 0.2f;
    private bool canFire = true;
    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal"); 
        movement.y = Input.GetAxisRaw("Vertical");
        if (Input.GetKeyDown(KeyCode.Space) && canFire)
        {
            StartCoroutine(Fire());
        }
    }

    void FixedUpdate()
    {
        rb.linearVelocity = movement * moveSpeed;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("wall")) {
        Destroy(gameObject);
        }
    }
    IEnumerator Fire()
    {
        canFire = false;
        animator.SetTrigger("atk");
        Instantiate(bulletPrefab,vitri.position, Quaternion.Euler(0, 0, 90));
        yield return new WaitForSeconds(fireRate);
        canFire = true;
    }

}

using System.Collections;
using UnityEngine;

public class Main1 : MonoBehaviour
{
    public float moveSpeed = 15f;
    private Rigidbody2D rb;
    private Vector2 movement;
    public GameObject bulletPrefab;
    public Transform vitri;
    public float fireRate = 0.5f;
    private bool canFire = true;
    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (movement != Vector2.zero)
        {
            animator.SetBool("run", true);
        }
        else
        {
            animator.SetBool("run", false);
        }
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
        Destroy(gameObject,2f);
        }
    }
    IEnumerator Fire()
    {
        canFire = false;
        Instantiate(bulletPrefab,vitri.position, Quaternion.Euler(0, 0, 90));
        animator.SetTrigger("attack");
        yield return new WaitForSeconds(fireRate);
        canFire = true;
    }

}

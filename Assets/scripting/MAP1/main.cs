using System.Collections;
using UnityEngine;

public class main :MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private float moveSpeed = 20f;
    private Rigidbody2D rb;
    private Vector2 movement;
    public GameObject bulletPrefab, bulletPrefab2;
    public Transform vitri,vitri2;
    public float fireRate = 0.2f;
    private bool canFire = true;
    Animator animator;
    public int damage = 1;

    public int checkHeal = 1;
    private HP healing;
    public GameObject winPanel;
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        healing = GetComponent<HP>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        if (movement.x > 0)
        {
            spriteRenderer.flipX = false; 
        }
        else if (movement.x < 0)
        {
            spriteRenderer.flipX = true; 
        }
        if (Input.GetKeyDown(KeyCode.Space) && canFire && spriteRenderer.flipX==false)
        {
            StartCoroutine(Fire());
        }
        else if (Input.GetKeyDown(KeyCode.Space) && canFire && spriteRenderer.flipX == true)
        {
            StartCoroutine(Fire2());

        }

    }

    void FixedUpdate()
    {
        rb.linearVelocity = movement * moveSpeed;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("wall"))
        {
            HP hP = GetComponent<HP>();
            if (hP != null) {
                hP.TakeDamage(damage);
            }

        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("HP"))
        {
            Heal();
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("win"))
        {
            winPanel.SetActive(true);
        }

    }



    IEnumerator Fire()
    {
        canFire = false;
        animator.SetTrigger("atk");
        Instantiate(bulletPrefab, vitri.position, Quaternion.identity);
        yield return new WaitForSeconds(fireRate);
        canFire = true;
    }
    IEnumerator Fire2()
    {
        canFire = false;
        animator.SetTrigger("atk");
        Instantiate(bulletPrefab2, vitri2.position, Quaternion.identity);
        yield return new WaitForSeconds(fireRate);
        canFire = true;
    }
    private void Heal()
    {
        if (healing != null && healing.currentHP < healing.maxHP)
        {
            healing.currentHP += 1; // Tăng 1 HP
            healing.UpdateHPUI(); // Cập nhật hiển thị HP
        }
    }
}

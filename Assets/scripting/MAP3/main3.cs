using System.Collections;
using UnityEngine;

public class main3 : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private float moveSpeed = 20f;
    private Rigidbody2D rb;
    private Vector2 movement;
    public GameObject bulletPrefab;
    public Transform vitri;
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
        if (canFire && Input.GetKeyDown(KeyCode.Space)) {
            StartCoroutine(Fire());

        }



    }

    void FixedUpdate()
    {
        rb.linearVelocity = movement * moveSpeed;
    }
    //private void OnCollisionEnter2D(Collision2D collision)
    //{

    //    if (collision.gameObject.CompareTag("wall"))
    //    {
    //        HP hP = GetComponent<HP>();
    //        if (hP != null)
    //        {
    //            hP.TakeDamage(damage);
    //        }

    //    }

    //}
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

    private void Heal()
    {
        if (healing != null && healing.currentHP < healing.maxHP)
        {
            healing.currentHP += 1; // Tăng 1 HP
            healing.UpdateHPUI(); // Cập nhật hiển thị HP
        }
    }
}

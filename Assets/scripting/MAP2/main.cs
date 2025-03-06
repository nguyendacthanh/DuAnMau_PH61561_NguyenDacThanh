using System.Collections;
using Unity.VisualScripting;
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
    public int damage = 1;

    public int checkHeal = 1;
    public GameObject HeathPoint;
    private HP healing;
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        healing = GetComponent<HP>();
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal"); 
        movement.y = Input.GetAxisRaw("Vertical");
        if (Input.GetKeyDown(KeyCode.Space) && canFire)
        {
            StartCoroutine(Fire());
        }
        if (Input.GetKeyDown(KeyCode.E) && checkHeal==1)
        {
            float getRandomX = Random.Range(-60f, -5f);
            Vector3 viTriRandom_spawn = new Vector3(getRandomX, 30f, 1);
            GameObject newEnemy = Instantiate(HeathPoint, viTriRandom_spawn, Quaternion.identity);
            checkHeal = 0;
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
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("HP"))
        {
            Heal();

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
    private void Heal()
    {
        if (healing != null && healing.currentHP < healing.maxHP)
        {
            healing.currentHP += 1; // Tăng 1 HP
            healing.UpdateHPUI(); // Cập nhật hiển thị HP
        }
    }

}

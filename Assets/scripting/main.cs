using System.Collections;
using UnityEngine;

public class Main : MonoBehaviour
{
    public float moveSpeed = 15f;
    private Rigidbody2D rb;
    private Vector2 movement;
    public GameObject bulletPrefab;
    public Transform vitri;
    public float fireRate = 0.2f;
    private bool canFire = true;

    void Start()
    {
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
        Instantiate(bulletPrefab,vitri.position, Quaternion.Euler(0, 0, 90));
        yield return new WaitForSeconds(fireRate);
        canFire = true;
    }

}

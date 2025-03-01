using System.Collections;
using UnityEngine;

public class enemy1 :MonoBehaviour
{
    public float moveSpeed = 15f;
    public float moveInterval = 2f;

    private Rigidbody2D rb;


    //phan lien quan den ban dan
    public GameObject bulletPrefab;
    public Transform viTriChanceMove;
    //public float fireRate = 1.5f;
    //private bool canFire = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
        
        
    }

    void FixedUpdate()
    {
        rb.linearVelocity = Vector2.down * moveSpeed;


    }
 

    //IEnumerator Fire()
    //{
    //    canFire = false;
    //    Instantiate(bulletPrefab, vitri.position, Quaternion.Euler(0, 0, 270));
    //    yield return new WaitForSeconds(fireRate);
    //    canFire = true;
    //}
}

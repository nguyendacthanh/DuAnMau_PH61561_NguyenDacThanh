using System.Collections;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public float moveSpeed = 15f; 
    public float moveInterval = 2f; 

    private Rigidbody2D rb;
    private bool isMovingRandomly = false;
    private QLenemy qlEnemy;

    //phan lien quan den ban dan
    public GameObject bulletPrefab;
    public Transform vitri;
    public float fireRate = 1.5f;
    private bool canFire = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
    }

    void FixedUpdate()
    {
        if (!isMovingRandomly)
        {
            rb.linearVelocity = new Vector2(0, -moveSpeed);
        }
        if (canFire)
        {
            StartCoroutine(Fire());
        }
    }

    public void SetQLenemy(QLenemy ql)
    {
        qlEnemy = ql;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("event") && !isMovingRandomly)
        {
            isMovingRandomly = true;
            rb.linearVelocity = Vector2.zero;

            if (qlEnemy != null)
            {
                qlEnemy.RegisterEnemy(this); 
            }
        }
    }

    public void MoveToRandomPosition()
    {
        StartCoroutine(MoveToPosition());
    }

    IEnumerator MoveToPosition()
    {
        Vector3 startPos = transform.position;
        Vector3 targetPos = new Vector3(Random.Range(-65f, 0f), Random.Range(-16f, -1f), transform.position.z);

        float elapsedTime = 0f;
        while (elapsedTime < moveInterval)
        {
            transform.position = Vector3.Lerp(startPos, targetPos, elapsedTime / moveInterval);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = targetPos;
    }
    IEnumerator Fire()
    {
        canFire = false;
        Instantiate(bulletPrefab, vitri.position, Quaternion.Euler(0, 0, 270));
        yield return new WaitForSeconds(fireRate);
        canFire = true;
    }
}

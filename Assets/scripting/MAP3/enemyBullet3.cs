using UnityEngine;

public class enemyBullet3 : MonoBehaviour
{
    public float speed = 20f;
    private Rigidbody rb;
    public int damage = 1;
    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        HP hp = other.GetComponent<HP>();

        if (other.CompareTag("main"))
        {

            if (hp != null)
            {

                hp.TakeDamage(damage);
            }
            Destroy(gameObject);
        }
        if (other.CompareTag("gate"))
        {
            hp.TakeDamage(damage);
            Destroy(gameObject);

        }
    }
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        Destroy(gameObject, 5f);

    }
}

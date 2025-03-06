using UnityEngine;

public class bullet_map1 : MonoBehaviour
{
    public float speed = 40f;
    private Rigidbody rb;
    public int damage = 1;
    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("enemy"))
        {
            HP hp = other.GetComponent<HP>();

            if (hp != null)
            {

                hp.TakeDamage(damage);
            }
            Destroy(gameObject);
        }
        if (other.CompareTag("wall"))
        {
            Destroy(gameObject);

        }
    }
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        Destroy(gameObject,6f);

    }
}

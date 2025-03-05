using Unity.VisualScripting;
using UnityEngine;

public class enemyBullet : MonoBehaviour
{
    public float speed = 20f;
    private Rigidbody rb;
    public int damage = 1;

    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }
   
    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("main"))
        {
            HP hp = other.GetComponent<HP>();

            if (hp != null)
            {
                hp.TakeDamage(damage);
            }
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        Destroy(gameObject, 3f);
    }
}

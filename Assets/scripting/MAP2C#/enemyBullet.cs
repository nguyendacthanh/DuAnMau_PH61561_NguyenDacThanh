using Unity.VisualScripting;
using UnityEngine;

public class enemyBullet : MonoBehaviour
{
    public float speed = 20f;
    private Rigidbody rb;
    
    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }
   
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(""))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        Destroy(gameObject, 3f);
    }
}

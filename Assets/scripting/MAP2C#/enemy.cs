using UnityEngine;

public class enemy : MonoBehaviour
{
    public float moveSpeed = 15f; 
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0; 
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(0, -moveSpeed); 
    }
}

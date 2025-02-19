using UnityEngine;

public class setCamera : MonoBehaviour
{
    public float Speed = 1.5f;
    private Rigidbody2D rb;
    private Vector2 vt;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        vt.x = 1;
        vt.y = 0;
    }
    private void FixedUpdate()
    {
        rb.linearVelocityX = 10 * Speed;
    }
}

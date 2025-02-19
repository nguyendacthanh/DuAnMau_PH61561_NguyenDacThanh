using UnityEngine;

public class EnemyTrai_Phai : MonoBehaviour 
{
    private Rigidbody2D rb;
    public float speed = 10f;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        rb.linearVelocityX = speed;
    }
}

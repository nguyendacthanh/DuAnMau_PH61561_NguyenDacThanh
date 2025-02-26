using UnityEngine;

public class Map2:MonoBehaviour
{
    public float speed = 10f; 

    void Update()
    {
        transform.position += Vector3.down * speed * Time.deltaTime;
    }
  
}

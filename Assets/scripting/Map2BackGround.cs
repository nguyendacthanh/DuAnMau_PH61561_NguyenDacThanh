using UnityEngine;

public class Map2:MonoBehaviour
{
    public float speed = 10f;
    public GameObject mapresetPosition;
    public GameObject startPosition; 

    void Update()
    {
        transform.position += Vector3.down * speed * Time.deltaTime;

        if (transform.position.y <= mapresetPosition.transform.position.y)
        {
            transform.SetPositionAndRotation(startPosition.transform.position, startPosition.transform.rotation);
        }
        Debug.Log("Map reset về vị trí: " + transform.position);

    }
}
  


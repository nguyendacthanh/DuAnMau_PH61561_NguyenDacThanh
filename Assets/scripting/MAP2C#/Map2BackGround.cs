using UnityEngine;

public class Map2:MonoBehaviour
{
    public float speed = 5f;
    public GameObject mapresetPosition;
    public GameObject startPosition; 

    void Update()
    {
        transform.position += Vector3.down * speed * Time.deltaTime;

        if (transform.position.y*1.0 <= mapresetPosition.transform.position.y*1.0)
        {
            transform.SetPositionAndRotation(startPosition.transform.position, startPosition.transform.rotation);
        }
        Debug.Log("Map reset về vị trí: " + transform.position);

    }
    
   
}
  


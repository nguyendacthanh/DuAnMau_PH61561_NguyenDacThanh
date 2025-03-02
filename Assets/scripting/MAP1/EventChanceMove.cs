using System.Collections;
using UnityEngine;

public class EventChanceMove : MonoBehaviour
{
    public GameObject doiTuongEvent;
    private float timePerMove = 1.5f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == doiTuongEvent) {
            StartCoroutine(setTimePerMove());
        }
    }
    public void setMove()
    {

        doiTuongEvent.transform.position = new Vector3(Random.Range(-65,0),Random.Range(-16,0),1);
    }
    IEnumerator setTimePerMove()
    {
        setMove();
        yield return new WaitForSeconds(timePerMove);
    }
   
}

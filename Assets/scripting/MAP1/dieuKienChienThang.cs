using UnityEngine;

public class dieuKienChienThang : MonoBehaviour
{
    public GameObject GameObject;
    void Update()
    {
        CountEnemies();
    }

    void CountEnemies()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("enemy");

        if (enemies.Length == 0)
        {
            GameObject.SetActive(false);
        }
    }


}

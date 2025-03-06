using System.Collections;
using UnityEngine;

public class enemyAttack : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform vitri;
    public float fireRate = 1.5f;
    private bool canFire = true;

    private void Update()
    {
       if (canFire)
        {
            StartCoroutine(Fire());
        }
    }
    IEnumerator Fire()
    {
        canFire = false;
        Instantiate(bulletPrefab, vitri.position, Quaternion.Euler(0, 0, 270));
        yield return new WaitForSeconds(fireRate);
        canFire = true;
    }
}

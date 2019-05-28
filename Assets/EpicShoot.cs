using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EpicShoot : MonoBehaviour
{
    public GameObject bullet;
    float spreadAngle = 26;
    public float bullets = 14;
    public GameObject startPos;

    public float fireRate = 6;
    float nextFire = 0;
    private void Start()
    {
        if (startPos == null)
            startPos = gameObject;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.G) && nextFire <= Time.time)
        {
            nextFire = fireRate + Time.time;
            Shoot();
        }           
    }
    void Shoot()
    {
        spreadAngle = 365 / bullets;
        for (int i = 0; i < bullets; i++)
        {
            float startAngle = (bullets - 1) * spreadAngle;
            GameObject clone =
            Instantiate(bullet, startPos.transform.position, startPos.transform.rotation * Quaternion.Euler(0, 0, -startAngle + spreadAngle * i));
        }
    }
}

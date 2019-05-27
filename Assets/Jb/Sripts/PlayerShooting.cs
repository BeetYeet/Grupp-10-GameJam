using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject heavyBullet;
    public GameObject lightullet;
    public Transform[] bulletSpawnPos;
    public float lightFireSpeed;
    float lightNextFire;

    public float heavyFireSpeed;
    float heavyNextFire;

    private void Update()
    {
        if (Input.GetButtonDown("Fire1") && lightNextFire >= Time.time)
        {
            lightNextFire = Time.time + lightFireSpeed;
            Shoot(lightullet);
        }
        if(Input.GetKeyDown(KeyCode.R) && heavyNextFire >= Time.time)
        {
            heavyNextFire = Time.time + heavyFireSpeed;
            Shoot(heavyBullet);
        }
    }
    void Shoot(GameObject bullet)
    {
        for (int i = 0; i < bulletSpawnPos.Length; i++)
        {
            GameObject playerBullet = Instantiate(bullet, bulletSpawnPos[i].position, transform.rotation);
        }
    }
}

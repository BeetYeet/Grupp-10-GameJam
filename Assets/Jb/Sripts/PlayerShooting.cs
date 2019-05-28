using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject heavyBullet;
    public GameObject lightullet;
    public Transform[] bulletSpawnPos;
    public float lightFireSpeed = 1;
    float lightNextFire = 0;

    public float heavyBulletAmount = 12;
    public float heavyFireSpeed = 6;
    float heavyNextFire = 0;

    public bool hasLightAmmo = true;
    public bool hasHeavyAmmo = true;
    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            for (int i = 0; i < bulletSpawnPos.Length; i++)
            {
                bulletSpawnPos[i].gameObject.SetActive(true);
            }
        }
        if (Input.GetMouseButtonUp(0) && hasLightAmmo && lightNextFire <= Time.time)
        {
            lightNextFire = Time.time + lightFireSpeed;
            ShootLight(lightullet);
            for (int i = 0; i < bulletSpawnPos.Length; i++)
            {
                bulletSpawnPos[i].gameObject.SetActive(false);
            }

        }
        if(Input.GetKeyDown(KeyCode.R) && hasHeavyAmmo && heavyNextFire <= Time.time)
        {
            heavyNextFire = Time.time + heavyFireSpeed;
            ShootHeavy(heavyBullet, heavyBulletAmount);
        }
    }
    void ShootLight(GameObject bullet)
    {
        var lootBase = GetComponent<PlayerLootBase>();
        for (int i = 0; i < bulletSpawnPos.Length; i++)
        {
            GameObject playerBullet = Instantiate(bullet, bulletSpawnPos[i].position, bulletSpawnPos[i].transform.rotation);
            lootBase.lightBullets -= 1;
        }
        lootBase.CanShootCheck();
        
    }
    void ShootHeavy(GameObject bullet, float bullets)
    {
        var lootBase = GetComponent<PlayerLootBase>();
      
        float spreadAngle = 365 / bullets;
        for (int i = 0; i < (int)bullets; i++)
        {
            float startAngle = (bullets - 1) * spreadAngle;
            GameObject clone =
            Instantiate(bullet, transform.position, transform.rotation * Quaternion.Euler(0, 0, -startAngle + spreadAngle * i));
            lootBase.heavyBullets -= 1;
        }
            lootBase.CanShootCheck();
    }
}

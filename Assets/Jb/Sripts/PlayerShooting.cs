using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject heavyBullet;
    public GameObject lightullet;
    public Transform[] bulletSpawnPos;
    public float lightFireSpeed;
    float lightNextFire = 0;

    public float heavyFireSpeed;
    float heavyNextFire = 0;

    public bool hasLightAmmo = true;
    public bool hasHeavyAmmo = true;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && hasLightAmmo && lightNextFire <= Time.time)
        {
            lightNextFire = Time.time + lightFireSpeed;
            ShootLight(lightullet);

        }
        if(Input.GetKeyDown(KeyCode.R) && hasHeavyAmmo && heavyNextFire <= Time.time)
        {
            heavyNextFire = Time.time + heavyFireSpeed;
            ShootHeavy(heavyBullet);
        }
    }
    void ShootLight(GameObject bullet)
    {
        var lootBase = GetComponent<PlayerLootBase>();
        for (int i = 0; i < bulletSpawnPos.Length; i++)
        {
            GameObject playerBullet = Instantiate(bullet, bulletSpawnPos[i].position, bulletSpawnPos[i].transform.rotation);
            lootBase.lightBullets -= 1;
            lootBase.CanShootCheck();
        }
    }
    void ShootHeavy(GameObject bullet)
    {
        var lootBase = GetComponent<PlayerLootBase>();
        for (int i = 0; i < bulletSpawnPos.Length; i++)
        {
            GameObject playerBullet = Instantiate(bullet, bulletSpawnPos[i].position, bulletSpawnPos[i].transform.rotation);
            lootBase.heavyBullets -= 1;
            lootBase.CanShootCheck();
        }
    }
}

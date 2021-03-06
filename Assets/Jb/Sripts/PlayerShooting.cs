﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public AudioClip heavyShootSound;
    public GameObject heavyBullet;
    public GameObject lightullet;
    public Transform[] bulletSpawnPos;
    public float lightFireSpeed = 1;
    //float lightNextFire = 0;

    public float heavyBulletAmount = 12;
    public float heavyFireSpeed = 6;
    float heavyNextFire = 0;

    public bool hasLightAmmo = true;
    private void Update()
    {       
        if(Input.GetKeyDown(KeyCode.R) && heavyNextFire <= Time.time)
        {
            GetComponent<AudioSource>().clip = heavyShootSound;
            GetComponent<AudioSource>().Play();
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

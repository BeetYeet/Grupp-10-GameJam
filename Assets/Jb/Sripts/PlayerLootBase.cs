using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLootBase : MonoBehaviour
{
    //rördu dör du
    public float totalWood = 0;
    public float lightBullets = 0;
    public float heavyBullets = 0;
    PlayerShooting playerShooting;
    private void Awake()
    {
        playerShooting = GetComponent<PlayerShooting>();
    }
    public void AddLoot(float wood, float lightBullets, float heavyBullets)
    {
        totalWood += wood;
        this.lightBullets += lightBullets;
        this.heavyBullets += heavyBullets;
    }
    public void CanShootCheck()
    {
        if (lightBullets >= 0)
           playerShooting.hasLightAmmo = true;
        else if (lightBullets <= 0)
            playerShooting.hasLightAmmo = false;

        if (heavyBullets >= 0)
            playerShooting.hasHeavyAmmo = true;
        else if (heavyBullets <= 0)
            playerShooting.hasHeavyAmmo = false;
    }
}

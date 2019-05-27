using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLootBase : MonoBehaviour
{
    //rördu dör du
    public float totalWood = 0;
    public float lightBullets = 0;
    public float heavyBullets = 0;

    public void AddLoot(float wood, float lightBullets, float heavyBullets)
    {
        totalWood += wood;
        this.lightBullets += lightBullets;
        this.heavyBullets += heavyBullets;
    }
}

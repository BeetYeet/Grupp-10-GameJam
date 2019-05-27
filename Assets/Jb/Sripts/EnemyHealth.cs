using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour, IHealth
{
    public ScriptebleHealth scriptebleHealth;
    public LootDropBase lootDropBase;
    private float health;
    public float CurrentHealth => health;

    void Start()
    {
        health = scriptebleHealth.StartHealth;
    }

    public void DropItems()
    {
        var wood  = lootDropBase.amountOfWoodDrop;
        var lightBullets = lootDropBase.amountOflightBulletDrop;
        var heavyBullets = lootDropBase.amountOfHeavyBulletDrop;

        GameObject enemyDrop = Instantiate(lootDropBase.dropObj, transform.position, lootDropBase.dropObj.transform.rotation);
        enemyDrop.GetComponent<DropObjScript>().w = wood;
        enemyDrop.GetComponent<DropObjScript>().l = lightBullets;
        enemyDrop.GetComponent<DropObjScript>().h = wood;
    }

    public void TakeDmg(float amount = 1)
    {
        if (amount <= 0)
            amount = 1;

        health -= amount;
    }
    public void OnDeath()
    {
        DropItems();
        Destroy(gameObject);
    }
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.P)) //Går att byta ut till typ "tar skada" eller "On death"
            DropItems();
    }
}

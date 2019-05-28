using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour, IHealth
{
    public ScriptebleHealth scriptebleHealth;
    public LootDropBase lootDropBase;
    private float health;
    public float CurrentHealth => health;
    private SpriteRenderer rend;
    void Start()
    {
        health = scriptebleHealth.StartHealth;
        rend = GetComponent<SpriteRenderer>();
    }


    public void DropItems()
    {
        //rör du dör du
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
        StartCoroutine(flashColor(Color.white));
        health -= amount;
        if (health <= 0)
        {
            OnDeath();
        }
    }
    public void OnDeath()
    {
        DropItems();
        Destroy(gameObject);
    }
    IEnumerator flashColor (Color flashColor, float resetTime = 0.2f)
    {
        var color = rend.color;
        rend.color = flashColor;
        yield return new WaitForSeconds(resetTime);
        rend.color = color;
    }
}

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
    private Sprite flashSprite;
    private Sprite startSprite;
    void Start()
    {
        health = scriptebleHealth.StartHealth;
        rend = GetComponent<SpriteRenderer>();
        flashSprite = scriptebleHealth.flashSprite;
        startSprite = rend.sprite;
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
        //reputation.reputatuion += (int)scriptebleHealth.repBoast;
        StartCoroutine(FlashSprite(flashSprite));
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
    IEnumerator FlashSprite (Sprite flashSprite, float resetTime = 0.2f)
    {
        rend.sprite = flashSprite;
        yield return new WaitForSeconds(resetTime);
        rend.sprite = startSprite;
    }
}

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
    private Color[] colors;
    SpriteRenderer[] sprites;
    void Start()
    {
        health = scriptebleHealth.StartHealth;
        rend = GetComponent<SpriteRenderer>();
        sprites =  GetComponentsInChildren<SpriteRenderer>();
        colors = new Color[sprites.Length];
        for (int i = 0; i < colors.Length; i++)
        {
            colors[i] = sprites[i].color;
        }
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
        enemyDrop.GetComponent<DropObjScript>().h = heavyBullets;
    }

    public void TakeDmg(float amount = 1)
    {
        if (amount <= 0)
            amount = 1;
        //reputation.reputatuion += (int)scriptebleHealth.repBoast;
        StartCoroutine(PlayAudio(scriptebleHealth.hurtClip));
        StartCoroutine(FlashSprite());
        health -= amount;
        if (health <= 0)
        {
            StartCoroutine(PlayAudio(scriptebleHealth.boomClip));
            OnDeath();
        }
    }
    public void OnDeath()
    {
        DisableStuff();
        DropItems();
        Repp.changeRep(scriptebleHealth.repBoast);
        switch (GetComponent<AIController>().behavor)
        {
            case AIController.Behavor.Pasive:
                StatBlock.merchantsKilled++;
                break;
            case AIController.Behavor.Defensive:
                StatBlock.piratesKilled++;
                break;
            case AIController.Behavor.Offecive:
                StatBlock.navyKilled++;
                break;
            default:
                break;
        }
        Destroy(gameObject, GetComponent<AudioSource>().clip.length);
    }
    IEnumerator FlashSprite (float resetTime = 0.2f)
    {
        for (int i = 0; i < colors.Length; i++)
        {
            sprites[i].color = Color.Lerp(colors[i], Color.red, 0.4f);
        }
        yield return new WaitForSeconds(resetTime);
        for (int x = 0; x < colors.Length; x++)
        {
            sprites[x].color = colors[x];
        }
    }
    IEnumerator PlayAudio(AudioClip clip)
    {
        if(GetComponent<AudioSource>() == null)        
            gameObject.AddComponent<AudioSource>();
        
        GetComponent<AudioSource>().clip = clip;
        GetComponent<AudioSource>().Play();
        yield return new WaitForEndOfFrame();
    }
    void DisableStuff()
    {
        GetComponent<Collider2D>().enabled = false;
        if(GetComponent<SpriteRenderer>() != null)
            GetComponent<SpriteRenderer>().enabled = false;


        foreach (SpriteRenderer sprite in GetComponentsInChildren<SpriteRenderer>())
        {
            sprite.enabled = false;
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<IHealth>().TakeDmg(); //player tar dmg
            StatBlock.shotsHit++;
            TakeDmg();
        }
    }
}

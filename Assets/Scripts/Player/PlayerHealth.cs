using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour, IHealth
{
    public AudioClip fallApartclip;
    public float health;
    private float maxHealth;
    public ScriptebleHealth scriptebleHealth;
    PlayerLootBase playerLootBase;
    PlayerShooting playerShooting;
    public float CurrentHealth => health;
    private void Start()
    {
        playerLootBase = GetComponent<PlayerLootBase>();
        health = scriptebleHealth.StartHealth;
        maxHealth = scriptebleHealth.MaxHealth;
        StartCoroutine(FallApart());
    }

    public void DropItems()
    {
    }

    public void OnDeath()
    {
        StartCoroutine(PlayAudio(scriptebleHealth.boomClip));
		UIHandler.i.die(true);
        print("Died");
    }

    public void TakeDmg(float amount = 1)
    {
        playerLootBase.AddLoot(-WoodLose(12, 24), -LightLose(4, 8), -HeavyLose(1, 3));
        playerLootBase.CanShootCheck();
        StartCoroutine(PlayAudio(scriptebleHealth.hurtClip));

        if (playerLootBase.totalWood <= 0)
            OnDeath();
    }
    IEnumerator FallApart()
    {
        TakeDmg(1);
        StartCoroutine(PlayAudio(fallApartclip));
        yield return new WaitForSeconds(Random.Range(1f, 4f));
        StartCoroutine(FallApart());
    }

    IEnumerator PlayAudio(AudioClip clip)
    {
        if (GetComponent<AudioSource>() == null)
            gameObject.AddComponent<AudioSource>();

        GetComponent<AudioSource>().clip = clip;
        GetComponent<AudioSource>().Play();
        yield return new WaitForEndOfFrame();
    }

    void DisableStuff()
    {
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<Collider2D>().enabled = false;
    }

    float WoodLose(int minLose, int maxLose)
    {
       return Random.Range(minLose, maxLose);
    }
    float LightLose(int minLose, int maxLose)
    {
       return Random.Range(minLose, maxLose);
    }
    float HeavyLose(int minLose, int maxLose)
    {
       return Random.Range(minLose, maxLose);
    }

}

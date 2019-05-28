using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour, IHealth
{
    private float health;
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
        print("Died");
    }

    public void TakeDmg(float amount = 1)
    {
        playerLootBase.AddLoot(-WoodLose(12, 24), -LightLose(4, 8), -HeavyLose(1, 3));
        playerLootBase.CanShootCheck();

        if (playerLootBase.totalWood <= 0)
            OnDeath();
    }
    IEnumerator FallApart()
    {
        TakeDmg(1);
        yield return new WaitForSeconds(Random.Range(1, 3));
        StartCoroutine(FallApart());
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

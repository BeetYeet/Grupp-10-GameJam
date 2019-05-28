using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour, IHealth
{
    ScriptebleHealth scriptebleHealth;
    public float CurrentHealth => throw new System.NotImplementedException();

    public void DropItems()
    {
        throw new System.NotImplementedException();
    }

    public void OnDeath()
    {
        throw new System.NotImplementedException();
    }

    public void TakeDmg(float amount = 1)
    {
        throw new System.NotImplementedException();
    }
}

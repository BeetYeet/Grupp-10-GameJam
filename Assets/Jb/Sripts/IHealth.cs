using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface  IHealth 
{
    //rördu dör du
    float CurrentHealth { get; }
    void TakeDmg(float amount = 1);
    void DropItems();
    void OnDeath();
}

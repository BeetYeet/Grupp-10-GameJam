using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ScriptebleHealth : ScriptableObject
{
    public float difficulty;
    public AudioClip bumpSound;
    public AudioClip boomClip;
    public AudioClip hurtClip;
    public Sprite flashSprite;
    public float StartHealth;
    public float MaxHealth;
    public float repBoast;
}

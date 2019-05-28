using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class SimpleEnemyMoveStats : ScriptableObject
{
    public float speedForward;
    public float rotSpeed;
    public float changeDirTime;
    public float anglesPerChange;
}

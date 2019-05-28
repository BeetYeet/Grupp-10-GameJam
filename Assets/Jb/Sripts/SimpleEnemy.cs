using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleEnemy : MonoBehaviour
{
    public SimpleEnemyMoveStats enemyMoveStats;
    float endRot = 30;
    float startRot;
    private void Start()
    {
        StartCoroutine(changeDir());
    }
    private void Update()
    {
        transform.Translate(new Vector3(0, enemyMoveStats.speedForward * Time.deltaTime));
    }
    IEnumerator changeDir()
    {
        endRot = transform.eulerAngles.z + enemyMoveStats.anglesPerChange;
        startRot = transform.eulerAngles.z;
        float t = 0;
        while (t < 1)
        {
            transform.rotation = Quaternion.Euler(0, 0, Mathf.Lerp(startRot, endRot, t));
            t += enemyMoveStats.rotSpeed * Time.deltaTime;
            yield return null;
        }
        yield return new WaitForSeconds(enemyMoveStats.changeDirTime);
        StartCoroutine(changeDir());
    }
}

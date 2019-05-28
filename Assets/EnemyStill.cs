using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStill : MonoBehaviour
{
    public SimpleEnemyMoveStats moveStats;
    bool playerDetected = false;
    bool doSmootRotation = true;
    private void Update()
    {
        if (playerDetected == false)
            transform.Translate(Vector3.up * moveStats.speedForward * Time.deltaTime);
    }


    private Vector2 lastPos;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            lastPos = transform.position;
            playerDetected = true;

            transform.RotateAround(collision.gameObject.transform.position, Vector3.forward, moveStats.rotSpeed * Time.deltaTime);

            if (doSmootRotation)
            {
                StartCoroutine(smoothRotation());
            }
            Vector2 diff = lastPos - (Vector2)transform.position;
            diff.Normalize();

            float ang = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, ang + 90);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerDetected = false;
        }
    }
    IEnumerator smoothRotation()
    {
        doSmootRotation = false;
        yield return new WaitForEndOfFrame();
    }
}

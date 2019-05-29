using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStill : MonoBehaviour
{
    public Transform bulletPos;
    public GameObject bullet;
    public SimpleEnemyMoveStats moveStats;
    bool playerDetected = false;
    bool doSmootRotation = true;
    bool doSpin = false;
    bool canShoot = true;
    private void Update()
    {
        if (playerDetected == false)
            transform.Translate(Vector3.up * moveStats.speedForward * Time.deltaTime);
    }


    private Vector2 lastPos;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
            StartCoroutine(Shoot());
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            StartCoroutine(DebugColl());
            canShoot = true;
            if (doSpin)
            {
                playerDetected = true;
                lastPos = transform.position;

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
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerDetected = false;
            canShoot = false;
        }
    }
    IEnumerator smoothRotation()
    {
        doSmootRotation = false;
        yield return new WaitForEndOfFrame();
    }
    IEnumerator DebugColl()
    {
        yield return new WaitForSeconds(0.6f);
        doSpin = true;
    }
    IEnumerator Shoot()
    {
        yield return new WaitForSeconds(3);
        if(canShoot)
        {
            GameObject clone = Instantiate(bullet, bulletPos.position, bulletPos.rotation);
            StartCoroutine(Shoot());
        }
    }
}

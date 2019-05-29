using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropObjScript : MonoBehaviour
{
    public float degreesPerSec = 45;
    public float swaySpeed = 5;
    public float swayReduction = 7f;
    //rördu dör du
    [HideInInspector]
    public float w, l, h;
    Vector3 startPos;
    private void Start()
    {
        startPos = transform.position;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerLootBase>().AddLoot(w, l, h);
            DisableStuff();
            GetComponent<AudioSource>().Play();
            Destroy(gameObject, GetComponent<AudioSource>().clip.length);
        }
    }
    void DisableStuff()
    {
        if (GetComponent<Collider2D>() != null)        
            GetComponent<Collider2D>().enabled = false;

        foreach (SpriteRenderer sprite in GetComponentsInChildren<SpriteRenderer>())
        {
            sprite.enabled = false;
        }


    }
    private void Update()
    {
        transform.position = startPos + Vector3.up * Mathf.Sin(swaySpeed * (Time.time)) / swayReduction;
        transform.Rotate(Vector3.forward, degreesPerSec * Time.deltaTime);
    }
}

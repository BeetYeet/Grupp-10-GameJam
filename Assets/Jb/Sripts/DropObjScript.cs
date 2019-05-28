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
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerLootBase>().AddLoot(w, l, h);
            GetComponent<AudioSource>().Play();
            DisableStuff();
            Destroy(gameObject, GetComponent<AudioSource>().clip.length);
        }
    }
    void DisableStuff()
    {
        GetComponent<Renderer>().enabled = false;
        if (GetComponent<Collider2D>() != null)        
            GetComponent<Collider2D>().enabled = false;

        if (GetComponent<Collider>() != null)
            GetComponent<Collider>().enabled = false;


    }
    private void Update()
    {
        transform.position = startPos + Vector3.up * Mathf.Sin(swaySpeed * (Time.time)) / swayReduction;
        transform.Rotate(Vector3.forward, degreesPerSec * Time.deltaTime);
    }
}

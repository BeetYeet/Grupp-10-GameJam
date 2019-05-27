using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropObjScript : MonoBehaviour
{
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
            Destroy(gameObject);
        }
    }
    private void Update()
    {
        transform.position = startPos + Vector3.up * Mathf.Sin(swaySpeed * (Time.time)) / swayReduction;
    }
}

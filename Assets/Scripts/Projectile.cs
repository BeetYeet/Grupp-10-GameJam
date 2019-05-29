using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    public float speed = 2;
    public float range = 4, randRange = 1;

    private float deractionX, deractionY;

    // Start is called before the first frame update
    void Awake()
    {
        float v = transform.localRotation.z * Mathf.Deg2Rad;
        deractionX = Mathf.Sin(v) * speed;
        deractionY = Mathf.Cos(v) * speed;
        Destroy(gameObject, range + Random.Range(0, randRange));
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(new Vector3(deractionX, deractionY));
    }
}

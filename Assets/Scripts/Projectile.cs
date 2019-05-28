using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    public float speed = 2;
    public float time = 4, randTime = 1;

    private float deractionX, deractionY;

    // Start is called before the first frame update
    void Start()
    {
        float v = transform.localRotation.z * 0.0174533f;
        deractionX = Mathf.Sin(v) * speed;
        deractionY = Mathf.Cos(v) * speed;
        //Destroy(gameObject, time + Random.Range(-randTime, randTime));
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(new Vector3(deractionX, deractionY));
    }
}

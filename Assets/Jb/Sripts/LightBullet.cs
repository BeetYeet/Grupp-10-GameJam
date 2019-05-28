using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightBullet : MonoBehaviour
{
    public float bulletSpeed = 5;
    
    [HideInInspector]
    public float extraSpeed = 0;
    void Update()
    {
        MoveBullet();
    }
    public void MoveBullet()
    {
        transform.Translate(Vector3.up * (bulletSpeed + extraSpeed) * Time.deltaTime);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag =="Enemy")
        {
            collision.gameObject.GetComponent<IHealth>().TakeDmg();
            Destroy(gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinnigEnemy : MonoBehaviour
{   
    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(gameObject.transform.parent.position, transform.forward, 90 * Time.deltaTime);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sail : MonoBehaviour
{

    public float windDeraction = -45;
    public Transform parent;


    // Update is called once per frame
    void FixedUpdate()
    {


        transform.localRotation = Quaternion.Euler(0, 0, Mathf.PingPong(parent.localRotation.eulerAngles.z - windDeraction, 90) - 45);



    }
}

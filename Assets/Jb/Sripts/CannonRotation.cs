using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonRotation : MonoBehaviour
{
    [Range(0, 3)]
    public float speed = 2;
    public float startRot;
    public float endRot;
    float t = 0;
    bool fucker = true;
    private void Start()
    {
        endRot = startRot + transform.eulerAngles.z;
        startRot -= transform.eulerAngles.z;
        if (startRot <= 0)
        {
            startRot = Mathf.Abs(startRot);
        }
        if (transform.eulerAngles.z >= 180)
        {
            float temp = startRot;
            startRot = endRot;
            endRot = temp;
        }
    }
    void Update()
    {

        transform.localRotation = Quaternion.Euler(0, 0, Mathf.Lerp(startRot, endRot, t));
        t += speed * Time.deltaTime;

        if (t >= 1)
        {
            float temp = startRot;
            startRot = endRot;
            endRot = temp;
            t = 0;
            //Destroy(clone);
        }
    }
}

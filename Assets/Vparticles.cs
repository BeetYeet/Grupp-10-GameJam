using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vparticles : MonoBehaviour
{
    public PlayerController pc;
    public float degrees = 180;
    private ParticleSystem ps;
    private ParticleSystem.EmissionModule pse;

    // Start is called before the first frame update
    void Start()
    {
        ps = GetComponent<ParticleSystem>();
        pse = ps.emission;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        pse.rateOverTimeMultiplier = Mathf.Abs( pc.rotationVelocity)*10 * pc.forwardVelocity;
        transform.localRotation = Quaternion.Euler(0,0, -degrees * pc.rotationVelocity);
        //Debug.Log(pc.rotationVelocity);
    }
}

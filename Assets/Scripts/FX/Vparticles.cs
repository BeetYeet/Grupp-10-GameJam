using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vparticles : MonoBehaviour
{
    public ControlerBase pc;
    public float degrees = 90;
    private ParticleSystem ps;
    private ParticleSystem.EmissionModule pse;
    private ParticleSystem.MainModule psMain;
    public float speed = 0.8f;

    // Start is called before the first frame update
    void Start()
    {
        ps = GetComponent<ParticleSystem>();
        pse = ps.emission;
        psMain = ps.main;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        psMain.startSpeedMultiplier = speed * pc.forwardVelocity;
        pse.rateOverTimeMultiplier = Mathf.Abs( pc.rotationVelocity)*10 * pc.forwardVelocity;
        transform.localRotation = Quaternion.Euler(0,0, -degrees * pc.rotationVelocity);
        //Debug.Log(pc.rotationVelocity);
    }
}

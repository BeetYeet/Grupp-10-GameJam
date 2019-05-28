using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class particlesBySpeed : MonoBehaviour
{
    public PlayerController pc;
    private ParticleSystem ps;
    private ParticleSystem.EmissionModule pse;

    // Start is called before the first frame update
    void Start()
    {
        ps = GetComponent<ParticleSystem>();
        pse = ps.emission;
    }

    // Update is called once per frame
    void Update()
    {
        pse.rateOverTimeMultiplier =  pc.forwardVelocity*10;
    }
}

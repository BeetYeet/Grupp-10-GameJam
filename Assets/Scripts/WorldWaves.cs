using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldWaves : MonoBehaviour
{

    private ParticleSystem ps;
    public Transform player;

    // Start is called before the first frame update
    void Start()
    {
        ps = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        ParticleSystem.ShapeModule _editableShape = ps.shape;
        _editableShape.position = player.position;

    }
}

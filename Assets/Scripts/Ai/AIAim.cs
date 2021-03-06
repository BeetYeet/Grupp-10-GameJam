﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIAim: MonoBehaviour
{
	public List<Aimable> cannons;
	public GameObject cannonShellPrefab;
	public float cannonCooldown = 10f;
	public Transform target;
	public float distance = 10;

    private void Awake()
    {
        if (target == null)
        {
            target = GameObject.FindGameObjectWithTag("Player").transform;
        }
    }

    void Update()
	{
		float dist = Vector3.Distance( target.position, transform.position );

		cannons.ForEach(
		( x ) =>
		{
			bool couldAim = x.TryAim( ( target.position - x.transform.position ).normalized );
			if ( dist < distance && couldAim && x.canFire )
			{
				Instantiate( cannonShellPrefab, x.transform.position, x.transform.rotation );
				x.currentCooldown = cannonCooldown - Random.Range( 0, cannonCooldown / 10 );
			}
		}
		);
	}
}

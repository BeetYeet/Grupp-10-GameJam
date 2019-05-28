using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake: MonoBehaviour
{

	public int cycles = 2;
	public float baseFreq = 2f;
	public float baseMagnitude = 1f;
	public float cycleFreqMultiplier = 2.8935f;
	public float cycleMagnitudeMultiplier = .3648f;
	public float currentShake = 0f;
	public float decayFactor = .95f;

	public void Shake( float amount )
	{
		currentShake += amount;
	}

	private void FixedUpdate()
	{
		currentShake *= decayFactor;
	}

	private void Update()
	{
		if ( Input.GetKeyDown( KeyCode.Space ) )
		{
			Shake( 3f );
		}
		if ( Input.GetKeyDown( KeyCode.KeypadEnter ) )
		{
			Shake( 1f );
		}
	}

	public float GetCurrentShake( float offset ) // offset is so you can get both x and y
	{
		float val = 0f;
		for ( int n = 0; n < cycles; n++ )
		{
			val += Mathf.Sin( baseFreq * Time.time * Mathf.Pow( cycleFreqMultiplier, n ) + offset ) * Mathf.Pow( cycleMagnitudeMultiplier, n );
		}
		return val * baseMagnitude * currentShake;
	}
}

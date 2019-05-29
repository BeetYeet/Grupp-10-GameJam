using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aimable: MonoBehaviour
{
	public Vector2 minangle, maxangle;
	public float currentCooldown;
	public bool canFire
	{
		get
		{
			return currentCooldown <= 0f;
		}
	}
	public Transform hull;
	Quaternion targetRotation = Quaternion.identity;

	//float cannonVelocity = 0f;
	public float rotationSpeed = 5;

	public float acceptableOffset = 15f;

	void Start()
	{
		minangle.Normalize();
		maxangle.Normalize();
		targetRotation = Quaternion.LookRotation( Vector3.forward, hull.TransformVector( Vector2.Lerp( minangle, maxangle, 0.5f ) ) );
		transform.rotation = targetRotation;
	}

	void Update()
	{
		if ( !canFire )
		{
			currentCooldown -= Time.deltaTime;
			if ( currentCooldown < 0f )
				currentCooldown = 0f;
		}
		transform.rotation = Quaternion.RotateTowards( transform.rotation, targetRotation, rotationSpeed * Time.deltaTime );

		float toTarget = Quaternion.Angle( transform.rotation, targetRotation );
	}

	public bool TryAim( Vector2 direction ) //returns true if it is aiming close enough
	{
		direction.Normalize();
		float toMin = Vector2.SignedAngle( direction, hull.TransformVector( minangle ) );
		float toMax = Vector2.SignedAngle( direction, hull.TransformVector( maxangle ) );


		Vector2 use = Vector2.zero;
		if ( toMin < 0 || toMax > 0 )
		{
			//can't aim there, aim as close as possible
			if ( Mathf.Abs( toMin ) < Mathf.Abs( toMax ) )
			{
				use = hull.TransformVector( minangle );
			}
			else
			{
				use = hull.TransformVector( maxangle );
			}
		}
		else
		{
			//can aim there
			use = direction;
		}


		targetRotation = Quaternion.LookRotation( Vector3.forward, use );
		
		Debug.DrawLine( transform.position, transform.position + transform.up, Color.blue );
		Debug.DrawLine( transform.position, transform.position + (Vector3) direction.normalized, Color.cyan );

		if ( Quaternion.Angle( transform.rotation, Quaternion.LookRotation( Vector3.forward, direction ) ) < acceptableOffset )
		{
			return true;
		}
		else
		{
			return false;
		}
	}



	private void OnDrawGizmosSelected()
	{
		{
			Gizmos.color = Color.green;
			Gizmos.DrawLine( transform.position, transform.position + hull.TransformVector( minangle ).normalized );
		}
		{
			Gizmos.color = Color.red;
			Gizmos.DrawLine( transform.position, transform.position + hull.TransformVector( maxangle ).normalized );
		}
	}


}

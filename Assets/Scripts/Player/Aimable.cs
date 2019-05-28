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

	float cannonVelocity = 0f;
	public float rotationSpeed = 5;


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
	}

	public bool TryAim( Vector2 direction )//returns true if it could aim there
	{
		direction.Normalize();
		float toMin = Vector2.SignedAngle( direction, hull.TransformVector( minangle ) );
		float toMax = Vector2.SignedAngle( direction, hull.TransformVector( maxangle ) );


		Vector2 use = Vector2.zero;
		if ( toMin < 0 || toMax > 0 )
		{
			//cant aim there
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

		if ( use == direction )
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

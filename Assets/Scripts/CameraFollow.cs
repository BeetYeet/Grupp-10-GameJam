using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow: MonoBehaviour
{
	public Transform target;

	private Vector3 velocityOffset = Vector3.zero;
	private Vector3 velocityOffsetTarget = Vector3.zero;
	public float velocityWeight = 1f;
	public float velocitySmoothTime = 2f;
	private Vector3 velVel = Vector3.zero;

	private Vector3 forwardOffset = Vector3.zero;
	private Vector3 forwardOffsetTarget = Vector3.zero;
	public float forwardWeight = 1f;
	public float forwardSmoothTime = 2f;
	private Vector3 forwardVel = Vector3.zero;

	private Vector3 aimOffset = Vector3.zero;
	private Vector3 aimOffsetTarget = Vector3.zero;
	public float aimWeight = 1f;
	public float aimSmoothTime = .5f;
	private Vector3 aimVel = Vector3.zero;

	void Start()
	{

	}

	void LateUpdate()
	{
		{
			velocityOffset = Vector3.SmoothDamp( velocityOffset, velocityOffsetTarget * velocityWeight, ref velVel, velocitySmoothTime );
			forwardOffset = Vector3.SmoothDamp( forwardOffset, forwardOffsetTarget * forwardWeight, ref forwardVel, forwardSmoothTime );
			aimOffset = Vector3.SmoothDamp( aimOffset, aimOffsetTarget * aimWeight, ref aimVel, aimSmoothTime );

			Vector3 pos = velocityOffset + forwardOffset + aimOffset + target.position;
			pos.z = -20f;
			transform.localPosition = pos;
		}
	}

	public void UpdateVelocitiyOffset( Vector3 offset )
	{
		velocityOffsetTarget = offset;
	}
	public void UpdateForwardOffset( Vector3 offset )
	{
		forwardOffsetTarget = offset;
	}
	public void UpdateAimPos( Vector3 pos )
	{
		aimOffsetTarget = pos - transform.position;
	}
}
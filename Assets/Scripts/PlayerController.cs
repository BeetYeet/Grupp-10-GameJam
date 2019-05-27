using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController: MonoBehaviour
{
	public float movementSpeed = 1f;
	public float turnSpeed = 10f;
	public float speedChangeTime = 1f;
	public float turnChangeTime = 1f;
	public float turnMinimumPart = 0.1f;

	private float forwardVelocity = 0f;
	private float forwardAcceleration = 0f;
	private float rotationVelocity = 0f;
	private float rotationAcceleration = 0f;
	
	void Update()
	{
		{
			Vector3 _ = transform.localEulerAngles;
			rotationVelocity = Mathf.SmoothDamp( rotationVelocity, Input.GetAxis( "Horizontal" ), ref rotationAcceleration, turnChangeTime );
			float factor = turnMinimumPart + ( forwardVelocity / movementSpeed ) * ( 1f - turnMinimumPart );
			_.z -= rotationVelocity * Time.deltaTime * turnSpeed * factor;
			transform.localEulerAngles = _;
		}
		forwardVelocity = Mathf.SmoothDamp( forwardVelocity, movementSpeed * Input.GetAxis( "Vertical" ), ref forwardAcceleration, speedChangeTime );
		transform.position += transform.up * forwardVelocity * Time.deltaTime;
	}
}

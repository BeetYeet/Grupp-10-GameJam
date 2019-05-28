using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController: MonoBehaviour
{
	public float movementSpeed = 1f;
	public float turnSpeed = 10f;
	public float speedChangeTime = 1f;
	public float turnChangeTime = 1f;
	public float turnAnimationChangeTime = .1f;
	public float turnMinimumPart = 0.1f;
	public float turnAnimMultiplier = 1f;
	public Transform hull;

	private float forwardVelocity = 0f;
	private float forwardAcceleration = 0f;

	private float rotationVelocity = 0f;
	private float rotationAcceleration = 0f;

	private float turnAnim = 0f;
	private float rotationAnimationVelocity = 0f;

	private float rot = 0f;

	void Update()
	{
		{
			rotationVelocity = Mathf.SmoothDamp( rotationVelocity, Input.GetAxis( "Horizontal" ), ref rotationAcceleration, turnChangeTime );
			float factor = turnMinimumPart + ( forwardVelocity / movementSpeed ) * ( 1f - turnMinimumPart );
			rot -= rotationVelocity * Time.deltaTime * turnSpeed * factor;

			turnAnim = Mathf.SmoothDamp( turnAnim, turnAnimMultiplier * ( forwardVelocity / movementSpeed ) * rotationVelocity, ref rotationAnimationVelocity, turnAnimationChangeTime );

			transform.localEulerAngles = new Vector3( 0f, 0f, rot );
			hull.localEulerAngles = new Vector3( 0f, 0f, -turnAnim );
		}
		forwardVelocity = Mathf.SmoothDamp( forwardVelocity, Input.GetAxis( "Vertical" ) < 0f ? movementSpeed * Input.GetAxis( "Vertical" ) * 0.02f : movementSpeed * Input.GetAxis( "Vertical" ), ref forwardAcceleration, speedChangeTime );
		transform.position += transform.up * forwardVelocity * Time.deltaTime;

		{
			CameraFollow _ = Camera.main.GetComponent<CameraFollow>();
			_.UpdateVelocitiyOffset( transform.up * forwardVelocity );
			_.UpdateForwardOffset( transform.up );
			Vector3 pos = Input.mousePosition;
			pos.z = 0f;
			pos = Camera.main.ScreenToWorldPoint( pos );
			_.UpdateAimPos(pos);
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAim: MonoBehaviour
{
	public List<Aimable> cannons;
	public GameObject cannonShellPrefab;
	public float cannonCooldown = 10f;

	void Update()
	{
		Vector3 pos = Input.mousePosition;
		pos.z = 0f;
		pos = Camera.main.ScreenToWorldPoint( pos );
		pos -= Camera.main.transform.position;

		cannons.ForEach(
		( x ) =>
		{
			bool couldAim = x.TryAim( new Vector2( pos.x, pos.y ) );
			if ( Input.GetMouseButton( 0 ) && couldAim && x.canFire )
			{
				Instantiate( cannonShellPrefab, x.transform.position, x.transform.rotation );
				x.currentCooldown = cannonCooldown - Random.Range( 0, cannonCooldown / 10 );
			}
		}
		);
	}
}

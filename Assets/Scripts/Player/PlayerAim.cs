using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAim: MonoBehaviour
{
	public List<Aimable> cannons;
	public GameObject cannonShellPrefab;
	public float cannonCooldown = 10f;
    public float range = 4;

	void Update()
	{
		Vector3 pos = Input.mousePosition;
		pos.z = 0f;
		pos = Camera.main.ScreenToWorldPoint( pos );

		cannons.ForEach(
		( x ) =>
		{
			bool aimingThere = x.TryAim( pos-x.transform.position );
			if ( Input.GetMouseButton( 0 ) && aimingThere && x.canFire )
			{
				GameObject go = Instantiate( cannonShellPrefab, x.transform.position, x.transform.rotation );
                go.GetComponent<Projectile>().range = range;
                x.currentCooldown = cannonCooldown - Random.Range( 0, cannonCooldown / 10 );
			}
		}
		);
	}
}

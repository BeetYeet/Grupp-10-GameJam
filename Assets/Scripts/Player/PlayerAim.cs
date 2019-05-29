using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PlayerAim: MonoBehaviour
{
	public List<Aimable> cannons;
	public GameObject cannonShellPrefab;
	public float cannonCooldown = 10f;
	public float range = 4;
	List<CanonUIItem> cannonIcons;
	public GameObject cannonIconParent;

    List<SpriteRenderer> images = new List<SpriteRenderer>();

    private void Start()
	{
		cannonIcons = cannonIconParent.GetComponentsInChildren<CanonUIItem>().ToList();
        for (int c = 0; c < cannonIcons.Count; c++)
        {
            images.Add(cannonIcons[c].gameObject.GetComponent<SpriteRenderer>());
        }

    }

	void Update()
	{
		Vector3 pos = Input.mousePosition;
		pos.z = 0f;
		pos = Camera.main.ScreenToWorldPoint( pos );

		for ( int c = 0; c < cannons.Count; c++ )
		{
            if (!cannons[c].gameObject.activeSelf)
            {
                images[c].enabled = false;
                continue;
            }
            images[c].enabled = true;
            Aimable x = cannons[c];
			bool aimingThere = x.TryAim( pos - x.transform.position );
			cannonIcons[c].EnableCanon( ( aimingThere ? ( x.canFire ? 1 : 2 ) : 0 ) );

			if ( Input.GetMouseButton( 0 ) && aimingThere && x.canFire )
			{
				GameObject go = Instantiate( cannonShellPrefab, x.transform.position, x.transform.rotation );
				go.GetComponent<Projectile>().range = range;
				x.currentCooldown = cannonCooldown - Random.Range( 0, cannonCooldown / 10 );
				Camera.main.transform.parent.GetComponent<CameraShake>().Shake( 1f );
				GameController.scoreTracker.stats.shotsFired++;
			}

		}

	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonUIItem: MonoBehaviour
{
	new SpriteRenderer renderer;

	private void Start()
	{
		renderer = GetComponent<SpriteRenderer>();
	}
	public void EnableCanon( int state )
	{
		switch ( state )
		{
			default:
				renderer.color = Color.black;
				break;
			case 1:
				renderer.color = Color.white;
				break;
			case 2:
				renderer.color = Color.red;
				break;
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class canon5 : MonoBehaviour
{
	public void EnableCanon(bool enabled)
	{
		if (enabled)
			gameObject.GetComponent<SpriteRenderer>().color = Color.white;
		else
			gameObject.GetComponent<SpriteRenderer>().color = Color.black;

	}
}

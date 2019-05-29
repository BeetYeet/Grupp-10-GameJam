using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillWater: MonoBehaviour
{
	private void OnTriggerExit2D( Collider2D collision )
	{
		if ( collision.tag != "Player" )
			return;
		//Lose Game
		Debug.Log( "Die" );
	}
}

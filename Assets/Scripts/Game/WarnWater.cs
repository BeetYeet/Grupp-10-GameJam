using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarnWater: MonoBehaviour
{
	private void OnTriggerExit2D( Collider2D collision )
	{
		if ( collision.tag != "Player" )
			return;
		//start warn
		Debug.Log( "Start Warn" );
	}
	private void OnTriggerEnter2D( Collider2D collision )
	{
		if ( collision.tag != "Player" )
			return;
		//end warn
		Debug.Log( "End Warn" );
	}
}

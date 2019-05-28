using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController: MonoBehaviour
{
	public static GameController current
	{
		get;
		private set;
	}
	public static ScoreTracker scoreTracker;

	void Awake()
	{
		if ( current != null )
		{
			Debug.LogWarning( "Multiple GameControllers in scene, please remove one" );
			enabled = false;
		}
	}

	void Update()
	{
		
	}
}

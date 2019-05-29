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
	public float spawnChance = 0.1f;

	public List<GameObject> enemies;
	public float spawnWidth = 150f, spawnHeight = 150f;


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
		TrySpawnEnemy();
	}

	public bool RandomBool( float chanceTrue )
	{
		return Random.value < chanceTrue;
	}

	void TrySpawnEnemy()
	{
		if ( RandomBool( spawnChance * Time.deltaTime ) )
		{
			SpawnEnemy();
		}
	}

	void SpawnEnemy()
	{
		Vector2 pos = new Vector2(), dir = new Vector2();
		if ( RandomBool( .5f ) )
		{
			//left/right
			if ( RandomBool( .5f ) )
			{
				//left
				pos.x = -spawnWidth / 2;
				dir = new Vector2( Random.value + 0.0001f, Random.value * 2 - 1 );
			}
			else
			{
				//right
				pos.x = spawnWidth / 2;
				dir = new Vector2( -Random.value - 0.0001f, Random.value * 2 - 1 );
			}
			pos.y = ( Random.value * 2 - 1 ) * spawnHeight;
		}
		else
		{
			//top/bot
			if ( RandomBool( .5f ) )
			{
				//top
				pos.y = spawnHeight / 2;
				dir = new Vector2( Random.value * 2 - 1, -Random.value - 0.0001f );
			}
			else
			{
				//bot
				pos.y = -spawnHeight / 2;
				dir = new Vector2( Random.value * 2 - 1, Random.value + 0.0001f );
			}
			pos.x = ( Random.value * 2 - 1 ) * spawnWidth;
		}
		dir.Normalize();
		Debug.Log( dir );
		Quaternion rot = Quaternion.LookRotation( Vector3.forward, dir );
		GameObject go = Instantiate( GetEnemy(), pos, rot );
		Debug.Log( go.transform.rotation.ToEuler() );
	}
	GameObject GetEnemy()
	{
		/*
			foreach ( GameObject go in enemies )
			{
				float difficulty = go.GetComponent<EnemyHealth>().scriptebleHealth;
			}
			*/
		return enemies[1];
	}
}

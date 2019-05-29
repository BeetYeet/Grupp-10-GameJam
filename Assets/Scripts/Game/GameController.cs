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
		//  Debug.Log( dir );
		Quaternion rot = Quaternion.LookRotation( Vector3.forward, dir );
		GameObject go = Instantiate( GetEnemy(), pos, rot );
	}
	GameObject GetEnemy()
	{
        /*
		List<yoted> probableEnemies = new List<yoted>();
		foreach ( GameObject go in enemies )
		{
			float difficulty = go.GetComponent<EnemyHealth>().scriptebleHealth.difficulty;
			switch ( MainMenuHandler.difficulty )
			{
				case MainMenuHandler.Difficulty.easy:
					difficulty = 1f / Mathf.Pow( difficulty, 1 );
					break;
				case MainMenuHandler.Difficulty.medium:
					difficulty = 1f / Mathf.Pow( difficulty, 1.2f );
					break;
				case MainMenuHandler.Difficulty.hard:
					difficulty = 1f / Mathf.Pow( difficulty, 1.5f );
					break;
				case MainMenuHandler.Difficulty.impossible:
					difficulty = 1f / Mathf.Pow( difficulty, 2 );
					break;
			}
			probableEnemies.Add( new yoted( difficulty, go ) );
		}
		float total = 0f;
		foreach ( yoted _ in probableEnemies )
		{
			total += _.difficluty;
		}
		GameObject enemy = probableEnemies[probableEnemies.Count - 1].obj;
		foreach ( yoted _ in probableEnemies )
		{
			if ( RandomBool( _.difficluty / total ) )
			{
				enemy = _.obj;
				break;
			}
		}
        */
		return enemies[Random.Range(0,Random.Range(1+(int)(Repp.Rep/ Repp.MaxRep *2f), enemies.Count+1))];
	}
}
class yoted
{
	public float difficluty;
	public GameObject obj;

	public yoted( float difficluty, GameObject obj )
	{
		this.difficluty = difficluty;
		this.obj = obj;
	}
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreTracker: MonoBehaviour
{
	[SerializeField]
	public uint score //scoren senaste framen
	{
		get;
		private set;
	}
	public StatBlock stats;
	public TextMeshProUGUI scoreText;
	public GameObject upgradeMenu;
	public float nextUpgradeScoreMultiplire = 1.5f;
	public uint scoreForNextUpgrade = 350;

	private void Start()
	{
		GameController.scoreTracker = this;
	}
	private void Update()
	{
		score = stats.GetScore();
		DisplayScore();
		stats.lifeTime = Time.time;
		if ( score >= scoreForNextUpgrade )
		{
			scoreForNextUpgrade = (uint) ( scoreForNextUpgrade * nextUpgradeScoreMultiplire );
			upgradeMenu.SetActive( true );
		}

		if ( Input.GetKey( KeyCode.O ) && Input.GetKey( KeyCode.P ) && !upgradeMenu.activeSelf )
		{
			StatBlock.cheets += scoreForNextUpgrade - score;
		}
	}


	private void DisplayScore()
	{
		scoreText.text = "Score: " + score.ToString( "D8" );
	}
}
[System.Serializable]
public class StatBlock
{
	public uint bonusScore;
	#region kills
	public uint enemiesKilled
	{
		get
		{
			return piratesKilled + merchantsKilled + navyKilled;
		}
	}
	public uint piratesKilled;
	public uint merchantsKilled;
	public uint navyKilled;
	#endregion

	#region resources
	public uint woodGathered;
	#endregion

	#region misc
	public float lifeTime;
	public float distanceTravelled;
	public float averageVelocity
	{
		get
		{
			if ( lifeTime == 0 )
			{
				return 0f;
			}
			return distanceTravelled / lifeTime;
		}
	}
	#endregion

	#region shooting
	public uint shotsFired;
	public uint shotsHit;
	public uint criticalHits;
	public float totalShotDistance;
	public float maxShotDistance;
	public float averageShotDistance;
	#endregion

	public uint GetScore()
	{
		return GetEquivelentScore( this );
	}

	public static uint cheets = 0;

	public static uint GetEquivelentScore( StatBlock stats )
	{
		uint _ = 0;
		_ += stats.woodGathered * 5;
		_ += stats.merchantsKilled * 300;
		_ += stats.navyKilled * 600;
		_ += stats.piratesKilled * 200;
		_ += (uint) Mathf.FloorToInt( stats.distanceTravelled / 20f );
		_ += stats.shotsHit * 10;
		_ += stats.criticalHits * 50;
		_ += (uint) Mathf.RoundToInt( stats.totalShotDistance * 10 );
		_ += (uint) Mathf.RoundToInt( stats.maxShotDistance * 300 );
		_ += (uint) Mathf.RoundToInt( stats.averageShotDistance * 100 );
		_ += cheets;
		_ += stats.bonusScore;

		return _;
	}
}
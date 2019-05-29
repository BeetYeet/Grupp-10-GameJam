using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.Audio;

public class UIHandler : MonoBehaviour
{
	public static UIHandler i
	{
		get; private set;
	}
	public GameObject Deathscreen;
	public GameObject PauseScreen;
	public TextMeshProUGUI hptext;
	public TextStuff textStuff;
	public AudioMixer mixer;
	bool activated;
	bool pauseActive;
	bool canPause = true;
	// Start is called before the first frame update
	void Start()
	{
		i = this;
	}

	// Update is called once per frame
	void Update()
	{
		hptext.text = "health: " + PlayerController.curr.PlayerLootBase.totalWood.ToString();
		if (Input.GetKeyDown(KeyCode.Escape))
			PauseGame(pauseActive = !pauseActive);
	}


	public void die(bool activate)
	{

		Deathscreen.SetActive(activate);
		if (!activate)
		{
			Time.timeScale = 1;

		}

		else
		{
			
			Time.timeScale = 0;
			textStuff.Totalscore.text = GameController.scoreTracker.stats.GetScore().ToString("D8");
			textStuff.merchantscore.text = GameController.scoreTracker.stats.merchantsKilled.ToString("D4");
			textStuff.piratescore.text = GameController.scoreTracker.stats.piratesKilled.ToString("D4");
			textStuff.navyscore.text = GameController.scoreTracker.stats.navyKilled.ToString("D4");
			textStuff.distancescore.text = string.Format("{0:000000.0}", GameController.scoreTracker.stats.distanceTravelled);
			textStuff.timescore.text = string.Format("{0:000000.0}", GameController.scoreTracker.stats.lifeTime);
			textStuff.shotsscore.text = GameController.scoreTracker.stats.shotsFired.ToString();
			textStuff.Criticalscore.text = GameController.scoreTracker.stats.criticalHits.ToString();
			textStuff.hitsscore.text = GameController.scoreTracker.stats.shotsHit.ToString();
		}
	}

	public void returnToMain()
	{
		Time.timeScale = 1;
		SceneManager.LoadScene(0);
	}
	public void PauseGame(bool active)
	{


		PauseScreen.SetActive(active);
		Time.timeScale = 0;
		if (!pauseActive)
		{
			Time.timeScale = 1;

		}

		else
		{
			Time.timeScale = 0;

		}

	}

	public void quitGame()
	{
		Application.Quit();
	}
}
[System.Serializable]
public class TextStuff
{
	public TextMeshProUGUI Totalscore;
	public TextMeshProUGUI merchantscore;
	public TextMeshProUGUI piratescore;
	public TextMeshProUGUI navyscore;
	public TextMeshProUGUI timescore;
	public TextMeshProUGUI distancescore;
	public TextMeshProUGUI shotsscore;
	public TextMeshProUGUI hitsscore;
	public TextMeshProUGUI Criticalscore;
}

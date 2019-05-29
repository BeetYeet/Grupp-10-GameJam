using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;   

public class MainMenuHandler : MonoBehaviour
{
	public static Difficulty difficulty;
	public List<AudioClip> audioClips;
	public TextMeshProUGUI DifficultyText;
	public GameObject MainMenuPanel, DifficultyPanel, CredditsPannel;

	bool IsAudioMute = false;

	private void Start()
	{
		CredditsPannel.SetActive(false);
		MainMenuPanel.SetActive(true);
		DifficultyPanel.SetActive(false);
	}

	void Update()
	{
		switch (difficulty)
		{
			case Difficulty.easy:
				DifficultyText.text = "the Pacific Ocean";
				break;
			case Difficulty.medium:
				DifficultyText.text = "the Atlantic Ocean";
				break;
			case Difficulty.hard:
				DifficultyText.text = "the Antarctic Ocean";
				break;
			case Difficulty.impossible:
				DifficultyText.text = "the Bermuda Triangle";
				break;
		}
		if (Input.anyKeyDown && !Input.GetMouseButtonDown(0))
		{
			
			StartGame();
		}
	}

	#region button functions
	public void StartGame()
	{
		Debug.Log("started game!");
		int i = Random.Range(0, audioClips.Count);
		Playsound.i.SFXcSource.PlayOneShot(audioClips[i]);
		SceneManager.LoadScene(1);
	}

	public void MuteAudio()
	{
		IsAudioMute = !IsAudioMute;
	}

	public void WhatDifficulty()
	{
		MainMenuPanel.SetActive(false);
		DifficultyPanel.SetActive(true);
		int i = Random.Range(0, audioClips.Count);
		Playsound.i.SFXcSource.PlayOneShot(audioClips[i]);
	}
	public void Creddits()
	{
		CredditsPannel.SetActive(true);
		MainMenuPanel.SetActive(false);
		DifficultyPanel.SetActive(false);
	}
	public void mainmenU()
	{
		CredditsPannel.SetActive(false);
		MainMenuPanel.SetActive(true);
		DifficultyPanel.SetActive(false);
	}

	public void DifficultyEasy()
	{
		difficulty = Difficulty.easy;
		MainMenuPanel.SetActive(true);
		DifficultyPanel.SetActive(false);
		int i = Random.Range(0, audioClips.Count);
		Playsound.i.SFXcSource.PlayOneShot(audioClips[i]);
	}
	public void DifficultyMedium()
	{
		difficulty = Difficulty.medium;
		MainMenuPanel.SetActive(true);
		DifficultyPanel.SetActive(false);
		int i = Random.Range(0, audioClips.Count);
		Playsound.i.SFXcSource.PlayOneShot(audioClips[i]);
	}
	public void DifficultyHard()
	{
		difficulty = Difficulty.hard;
		MainMenuPanel.SetActive(true);
		DifficultyPanel.SetActive(false);
		int i = Random.Range(0, audioClips.Count);
		Playsound.i.SFXcSource.PlayOneShot(audioClips[i]);
	}
	public void DifficultyImpossible()
	{
		difficulty = Difficulty.impossible;
		MainMenuPanel.SetActive(true);
		DifficultyPanel.SetActive(false);
		int i = Random.Range(0, audioClips.Count);
		Playsound.i.SFXcSource.PlayOneShot(audioClips[i]);
	}
	#endregion

	public enum Difficulty
	{
		easy,
		medium,
		hard,
		impossible
	}
}
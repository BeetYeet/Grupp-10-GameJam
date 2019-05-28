using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuHandler : MonoBehaviour
{
	bool IsAudioMute = false;


    public void StartGame()
	{
		Debug.Log("started game!");
	}
	public void MuteAudio()
	{
		IsAudioMute = !IsAudioMute;
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playsound : MonoBehaviour
{
	public List<AudioClip> audioClips;

	public AudioSource musicSource;
	public AudioSource SFXcSource;
    // Start is called before the first frame update
    void Start()
    {
		
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	void playMusic(AudioClip audioClip)
	{
		musicSource.PlayOneShot(audioClip);
	}

	void playSound(AudioClip audioClip)
	{
		SFXcSource.PlayOneShot(audioClip);
	}
}

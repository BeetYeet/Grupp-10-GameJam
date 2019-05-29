using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIHandler : MonoBehaviour
{
	public GameObject Deathscreen;
	public TMPro.TextMeshProUGUI[] texts;
	bool activated;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		if (Input.GetKeyDown(KeyCode.M))
			die(activated = !activated);

    }


	public void die(bool activate)
	{
		Deathscreen.SetActive(activate);
		if (!activate)
			Time.timeScale = 1;
		else
			Time.timeScale = 0;
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    private void Update()
    {

        if (Input.anyKeyDown)
        {
        StatBlock.cheets = 0;
        StatBlock.merchantsKilled = 0;
        StatBlock.navyKilled = 0;
        StatBlock.piratesKilled = 0;
        StatBlock.shotsHit = 0;
        SceneManager.LoadScene(0);

        }

    }
}

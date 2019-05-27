using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class HeavyBulletText : MonoBehaviour
{
    private TextMeshProUGUI text;
    private GameObject player;
    private void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
        player = GameObject.FindGameObjectWithTag("Player");
    }
    private void Update()
    {
        text.text = player.GetComponent<PlayerLootBase>().heavyBullets.ToString();
    }
}

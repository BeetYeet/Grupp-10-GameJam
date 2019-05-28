using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class WoodText : MonoBehaviour
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
        text.text = player.GetComponent<PlayerLootBase>().totalWood.ToString();
    }
}

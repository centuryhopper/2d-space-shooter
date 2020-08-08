using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayHealth : MonoBehaviour
{
    TextMeshProUGUI healthText;
    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        healthText = GetComponent<TextMeshProUGUI>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        // displays on the screen what gameSession object information
        if (player != null)
        {
            healthText.text = player.GetComponent<PlayerHealth>().health.ToString();
        }
        else
        {
            healthText.text = "0";
        }
        
    }
}

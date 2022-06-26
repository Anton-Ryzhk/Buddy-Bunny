using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerText : MonoBehaviour
{
    private PlayerScript player;
    private TMP_Text txt;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>();
        txt = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        txt.text = "Здоровье:" + player.health;
    }
}

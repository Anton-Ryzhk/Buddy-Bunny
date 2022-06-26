using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinsText : MonoBehaviour
{
    private PlayerScript player;
    private TMP_Text txt;
    public LevelManagerScript need;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>();
        txt = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        txt.text = "Exp: " + player.coins + '/' + need.expNeed;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemChoose : MonoBehaviour
{
    private PlayerScript player;

    public GameObject ChooseUi;
    public LevelManagerScript lvlManager;

    public Button but1;
    public Image img1;
    public Button but2;
    public Image img2;
    public Button but3;
    public Image img3;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if(player.coins >= lvlManager.expNeed && lvlManager.numOfLvl < lvlManager.maxLevel)
        {
            player.coins -= (int)lvlManager.expNeed;
            lvlManager.numOfLvl = lvlManager.numOfLvlHandCannons + lvlManager.numOfLvlCircles + lvlManager.numOfLvlBombs;
            lvlManager.expNeed = lvlManager.numOfLvl * 5;
            ChooseUi.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    public void Choose()
    {
        ChooseUi.SetActive(true);
        Time.timeScale = 0f;
    }
}

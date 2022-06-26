using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManagerScript : MonoBehaviour
{
    [SerializeField]private GameObject[] hndCn;
    [SerializeField]private GameObject[] circls;
    [SerializeField]private BombThrowerScript bombThrower;
    public PassiveItemScript sunCrown;
    public PassiveItemScript moonCrown;

    [SerializeField]private GameObject bullet;

    private PlayerScript player;

    public float expNeed;

    public float timer = 0;
    public int numOfLvlHandCannons = 0;
    public int maxNumOfLvlHandCannons = 8;

    public int numOfLvlCircles = 0;
    public int maxNumOfLvlCircles = 3;

    public int numOfLvlBombs = 0;
    private int cloneNumOfLvlBomb = 0;
    public int maxNumOfLvlBombs = 3;

    public int numOfLvlSunCrown = 0;
    private int cloneNumOfLvlSunCrown = 0;
    public int maxNumOfLvlSunCrown = 3;

    public int numOfLvlMoonCrown = 0;
    private int cloneNumOfLvlMoonCrown = 0;
    public int maxNumOfLvlMoonCrown = 3;

    public int numOfLvl;

    public int maxLevel;
    public GameObject ChooseUi;

    public GameObject[] buttons;

    public AudioSource lvlupSound;
    public Image night;

    public bool isDay = true;
    public bool isNight = false;

    private int count = 1;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>();
        expNeed = 5;
        maxLevel = maxNumOfLvlHandCannons + maxNumOfLvlCircles + maxNumOfLvlBombs + maxNumOfLvlSunCrown;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(player.coins >= expNeed)
        {
            player.coins -= (int)expNeed;
            numOfLvl = numOfLvlHandCannons + numOfLvlCircles + numOfLvlBombs + numOfLvlSunCrown + numOfLvlMoonCrown;
            expNeed = numOfLvl * 5;
            if( numOfLvl < maxLevel)
            {
                lvlupSound.Play();
                ChooseUi.SetActive(true);
                Time.timeScale = 0f;
            }
        }

        if(timer >= count * 10f)
        {
            DayFlip();
            count++;
        }
    }

    private void DayFlip()
    {
        if(isDay)
        {
            night.gameObject.SetActive(true);
            isDay = false;
            isNight = true;
        }
        else
        {
            night.gameObject.SetActive(false);
            isDay = true;
            isNight = false;
        }
    }
    public void LvlUp(string name)
    {
        cloneNumOfLvlSunCrown = numOfLvlSunCrown;
        cloneNumOfLvlBomb = numOfLvlBombs;
        
        if(name == "Revolver")
        {
            if(numOfLvlHandCannons < maxNumOfLvlHandCannons)
            {
                numOfLvlHandCannons += 1;
                if(numOfLvlHandCannons == maxNumOfLvlHandCannons)
                {
                    buttons[0].SetActive(false);
                } 
            }
        }
            
        if(name == "Circle")
        {
            if(numOfLvlCircles < maxNumOfLvlCircles)
            {
                numOfLvlCircles += 1;
                if(numOfLvlCircles == maxNumOfLvlCircles)
                {
                    buttons[1].SetActive(false);
                }
            }

        }

        if(name == "Bomb")
        {
            if(numOfLvlBombs < maxNumOfLvlBombs)
            {
                numOfLvlBombs += 1;
                if(numOfLvlBombs == maxNumOfLvlBombs)
                {
                    buttons[2].SetActive(false);
                }
            }
        }

        if(name == "SunCrown")
        {
            if(numOfLvlSunCrown < maxNumOfLvlSunCrown)
            {
                numOfLvlSunCrown += 1;
                if(numOfLvlSunCrown == maxNumOfLvlSunCrown)
                {
                    buttons[3].SetActive(false);
                }
            }
        }

        if(name == "MoonCrown")
        {
            if(numOfLvlMoonCrown < maxNumOfLvlMoonCrown)
            {
                numOfLvlMoonCrown += 1;
                if(numOfLvlMoonCrown == maxNumOfLvlMoonCrown)
                {
                    buttons[4].SetActive(false);
                }
            }
        }
            
        

        switch(numOfLvlHandCannons)
        {
            case 1:
                hndCn[0].SetActive(true);
                break;
            case 2:
                hndCn[1].SetActive(true);
                break;
            case 3:
                hndCn[2].SetActive(true);
                break;
            case 4:
                hndCn[3].SetActive(true);
                break;
            case 5:
                hndCn[4].SetActive(true);
                break;
            case 6:
                hndCn[5].SetActive(true);
                break;
            case 7:
                hndCn[6].SetActive(true);
                break;
            case 8:
                hndCn[7].SetActive(true);
                break;
        }

        switch(numOfLvlCircles)
        {
            case 1:
                circls[0].SetActive(true);
                break;
            case 2:
                circls[1].SetActive(true);
                break;
            case 3:
                circls[2].SetActive(true);
                break;
        }
        
        if(cloneNumOfLvlBomb != numOfLvlBombs)
        {
            switch(numOfLvlBombs)
            {
                case 1:
                    bombThrower.startReloadTime -= 0.25f;
                    break;
                case 2:
                    bombThrower.startReloadTime -= 0.25f;
                    break;
                case 3:
                    bombThrower.startReloadTime -= 0.5f;
                    break;
            }
        }

        if(cloneNumOfLvlSunCrown != numOfLvlSunCrown)
        {
            switch(numOfLvlSunCrown)
            {
                case 1:
                    sunCrown.gameObject.SetActive(true);
                    break;
                case 2:
                    sunCrown.gameObject.SetActive(false);
                    sunCrown.shotSpeedUp += 0.2f;
                    sunCrown.FirespeedUp += 0.2f;
                    sunCrown.gameObject.SetActive(true);
                    break;
                case 3:
                    sunCrown.gameObject.SetActive(false);
                    sunCrown.shotSpeedUp += 0.2f;
                    sunCrown.FirespeedUp += 0.2f;
                    sunCrown.gameObject.SetActive(true);
                    break;
            }
        }

        if(cloneNumOfLvlMoonCrown != numOfLvlMoonCrown)
        {
            switch(numOfLvlMoonCrown)
            {
                case 1:
                    moonCrown.gameObject.SetActive(true);
                    break;
                case 2:
                    moonCrown.gameObject.SetActive(false);
                    moonCrown.moveSpeedUp += 1f;
                    moonCrown.regenUp += 0.1f;
                    moonCrown.gameObject.SetActive(true);
                    break;
                case 3:
                    moonCrown.gameObject.SetActive(false);
                    moonCrown.moveSpeedUp += 1f;
                    moonCrown.regenUp += 0.2f;
                    moonCrown.gameObject.SetActive(true);
                    break;
            }
        }
        ChooseUi.SetActive(false);
        Time.timeScale = 1f;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrownsEnablerScript : MonoBehaviour
{
    public GameObject crown;
    public LevelManagerScript levelManager;

    public GameObject universeCrown;

    public bool isItSunCrown;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(universeCrown.activeInHierarchy == false)
        {
            if((levelManager.isDay && isItSunCrown) || (levelManager.isNight && !isItSunCrown))
            {
                if((levelManager.numOfLvlSunCrown >= 1 && isItSunCrown) || (levelManager.numOfLvlMoonCrown >= 1 && !isItSunCrown))
                {
                    crown.SetActive(true);
                }
            }
            else
            {
                crown.SetActive(false);
            }
        }
        else
        {
            crown.SetActive(false);
        }
        
    }
}

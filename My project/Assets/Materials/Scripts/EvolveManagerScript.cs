using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvolveManagerScript : MonoBehaviour
{
    public GameObject[,] evolvePairs = new GameObject[1,2];
    public GameObject[] evolves;
    private int[,] levels = new int[1,4];

    private LevelManagerScript levelManager;
    // Start is called before the first frame update
    void Start()
    {
        levelManager = GetComponent<LevelManagerScript>();
        evolvePairs[0,0] = levelManager.sunCrown.gameObject;
        evolvePairs[0,1] = levelManager.moonCrown.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        levels[0,0] = levelManager.numOfLvlSunCrown;
        levels[0,1] = levelManager.maxNumOfLvlSunCrown;
        levels[0,2] = levelManager.numOfLvlMoonCrown;
        levels[0,3] = levelManager.maxNumOfLvlMoonCrown;
        for (int i = 0; i < 1; i++)
        {
            if (levels[i,0] == levels[i,1] && levels[i,2] == levels[i,3])
            {
                evolvePairs[i,0].SetActive(false);
                evolvePairs[i,1].SetActive(false);
                evolves[i].SetActive(true);
            }
        }
    }
}

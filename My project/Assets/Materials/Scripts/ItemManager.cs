using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemManager : MonoBehaviour
{
    public Image[] barImg;
    public GameObject[] weapons;

    private int count = 0;
    private int weaponCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


        for(int i = 0; i < weapons.Length; i++)
        {
            if(weapons[weaponCount] != null && weapons[weaponCount].activeInHierarchy)
            {
                barImg[count].sprite = weapons[weaponCount].GetComponent<SpriteRenderer>().sprite;
                weapons[weaponCount] = null;
                count++;
                weaponCount++;
            }
            else
            {
                weaponCount++;
            }
        }
        weaponCount = 0;
    }
}

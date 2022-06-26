using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombThrowerScript : MonoBehaviour
{
    [SerializeField]private GameObject bomb;
    public float reloadTime;
    public float startReloadTime;
    public float fireSpeedCoef;
    // Start is called before the first frame update
    void Start()
    {
        reloadTime = startReloadTime;
    }

    // Update is called once per frame
    void Update()
    {
        if(reloadTime <= 0)
        {
            Instantiate(bomb,transform.position,transform.rotation);
            reloadTime = (startReloadTime + 0.1f) * (fireSpeedCoef * 2 );
        }
        else
        {
            reloadTime -= Time.deltaTime;
        }
    }
}

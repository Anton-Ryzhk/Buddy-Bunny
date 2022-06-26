using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunRotate : MonoBehaviour
{
    public float speed;
    public float waitTime;
    public float startWaitTime;
    public float fireSpeedCoef;
    [SerializeField] GunScript[] guns;
    public AudioSource fireSound;

    [SerializeField]private GameObject exempaleBullet;
    // Start is called before the first frame update
    void Start()
    {
        waitTime = startWaitTime;
    }

    // Update is called once per frame
    void Update()
    {
        waitTime -= Time.deltaTime;
        if((guns[0].wasShot && guns[1].wasShot) || (guns[0].wasShot || guns[1].wasShot))
        {
            fireSound.Play();
            waitTime = startWaitTime * fireSpeedCoef;
            guns[0].wasShot = false;
            guns[1].wasShot = false;
        }
        Vector3 dir = new Vector3(0,0,1);
        transform.Rotate(dir * speed * Time.deltaTime);
    }

    void FixedUpdate()
    {

    }
}

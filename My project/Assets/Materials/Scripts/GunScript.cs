using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour
{
    [SerializeField]public GameObject bullet;
    [SerializeField]private Transform point;
    private GunRotate gunRotate;
    public bool wasShot = false;
    // Start is called before the first frame update
    void Start()
    {
        gunRotate = GetComponentInParent<GunRotate>();
    }

    // Update is called once per frame
    void Update()
    {
        if(gunRotate.waitTime <= 0)
        {
            Instantiate(bullet, point.position, transform.rotation);
            wasShot = true;
        }
    }
}

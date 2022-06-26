using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassiveItemScript : MonoBehaviour
{
    private PlayerScript player;
    public float moveSpeedUp;
    public float shotSpeedUp;
    public float FirespeedUp;
    public float regenUp;
    public GunRotate guns;
    public BombThrowerScript bombThr;
    public BombScript bomb;

    public BulletScript bullet;

    // Start is called before the first frame update
    void Awake()
    {
        player = GetComponentInParent<PlayerScript>();
    }

    void OnEnable()
    {
        //Усиляем героя
        player.speed += moveSpeedUp;
        player.regeneration += regenUp;
        guns.fireSpeedCoef -= FirespeedUp;
        bombThr.fireSpeedCoef -= FirespeedUp;
        bullet.shotSpeedCoef += shotSpeedUp;
    }

    void OnDisable()
    {
        //Возращаем на исходное значение
        player.speed -= moveSpeedUp;
        player.regeneration -= regenUp;
        guns.fireSpeedCoef += FirespeedUp;
        bombThr.fireSpeedCoef += FirespeedUp;
        bullet.shotSpeedCoef -= shotSpeedUp;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

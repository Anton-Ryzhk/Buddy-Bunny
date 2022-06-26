using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAOEDamage : MonoBehaviour
{
    private EnemyScript enemy;
    private OrangeCircleScript orangeCircle;
    // Start is called before the first frame update
    void Start()
    {
        enemy = GetComponentInParent<EnemyScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Explosion"))
        {
            ExplosionScript exp = other.GetComponent<ExplosionScript>();
            enemy.health -= exp.damage;
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if(other.CompareTag("OrangeCircle"))
        {
            orangeCircle = other.GetComponent<OrangeCircleScript>();
            if(orangeCircle.waitTime <= 0)
            {
                enemy.health -= orangeCircle.damage;
                orangeCircle.waitTime = orangeCircle.startWaitTime;
            }
        }
    }
}

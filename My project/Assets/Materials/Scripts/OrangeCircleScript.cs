using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrangeCircleScript : MonoBehaviour
{
    public int damage;

    public float startWaitTime;
    public float waitTime;

    private EnemyScript enemy;
    // Start is called before the first frame update
    void Start()
    {
        waitTime = startWaitTime;
    }

    // Update is called once per frame
    void Update()
    {
        waitTime -= Time.deltaTime;
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerScript : MonoBehaviour
{
    public GameObject enemy;
    [SerializeField]private float xMax;
    [SerializeField]private float yMax;

    private float waitTime;
    [SerializeField]private float startWaitTime;

    private Vector3 rndPos;
    // Start is called before the first frame update
    void Start()
    {
        waitTime = startWaitTime;
    }

    // Update is called once per frame
    void Update()
    {
        float rndX = Random.Range(xMax * -1,xMax);
        float rndY = Random.Range(yMax * -1,yMax);
        rndPos = new Vector3(rndX,rndY,0);

        if(waitTime <= 0)
        {
            Instantiate(enemy, transform.position + rndPos, new Quaternion(0,0,0,0));
            waitTime = startWaitTime;
        }
        else
        {
            waitTime -= Time.deltaTime;
        }
    }
}

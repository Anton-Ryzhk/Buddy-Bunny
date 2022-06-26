using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionScript : MonoBehaviour
{
    public int damage;

    public float lifeTime;

    private float randomZ;

    public AudioSource explSound;
    // Start is called before the first frame update
    void Start()
    {
        randomZ = Random.Range(-180f,180f);
        transform.rotation = new Quaternion(0f,0f,randomZ,0f);
        explSound.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if(lifeTime <= 0)
        {
            Destroy(gameObject);
        }
        else
        {
            lifeTime -= Time.deltaTime;
        }
    }
}

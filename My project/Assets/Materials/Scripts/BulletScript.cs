using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public int damage;
    public float speed;
    public float lifeTime;

    public float shotSpeedCoef;

    private EnemyScript enemy;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(lifeTime <= 0f)
        {
            Destroy(gameObject);
        }
        else
        {
            lifeTime -= Time.deltaTime;
        }
    }

    void FixedUpdate()
    {
        Vector2 dir = new Vector2(1,0);
        transform.Translate( (dir*speed + new Vector2(shotSpeedCoef,0f)) * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("+"); 
        if(other.CompareTag("Enemy"))
        {
            Debug.Log("Wooooow");
            enemy = other.GetComponent<EnemyScript>();
            enemy.TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}

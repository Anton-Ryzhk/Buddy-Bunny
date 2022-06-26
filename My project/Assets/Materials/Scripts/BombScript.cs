using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombScript : MonoBehaviour
{

    [SerializeField]private float lifeTime;
    [SerializeField]private float moveTime;
    [SerializeField]private GameObject explosion;
    private float randomX;
    private float randomY;
    public float impulse;

    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        randomX = Random.Range(-1f,1f);
        randomY = Random.Range(-1f,1f);
        Vector2 dir = new Vector2(randomX,randomY);
        rb = GetComponent<Rigidbody2D>();// Получаем физ тело
        rb.AddForce(dir * impulse);
    }

    // Update is called once per frame
    void Update()
    {
        if(lifeTime <= 0f)
        {
            Instantiate(explosion, transform.position, transform.rotation);
            Destroy(gameObject);
        }
        else
        {
            lifeTime -= Time.deltaTime;
        }

        if(moveTime <= 0f)
        {
            rb.velocity = new Vector2(0f,0f);
            rb.gravityScale = 0f;
        }
        else
        {
            moveTime -= Time.deltaTime;
        }
    }
}

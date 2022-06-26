using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public int damage;
    public int health;
    public float speed;
    private PlayerScript player;
    private Transform playerTransform;

    private LevelManagerScript lvlManager;

    private SpriteRenderer sprite;

    [SerializeField]private Sprite[] variants;

    [SerializeField]private float startWaitTime;
    [SerializeField]private float waitTime;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        sprite = GetComponent<SpriteRenderer>();
        sprite.sprite = variants[Random.Range(0,variants.Length)];
        lvlManager = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<LevelManagerScript>();
        
        if(lvlManager.timer >= 60f)
        {
            health += 5;
        }
        else if(lvlManager.timer >= 60f * 2)
        {
            health += 5;
        }
        else if(lvlManager.timer >= 60f * 3)
        {
            health += 10;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(playerTransform.position.x < transform.position.x )
        {
            sprite.flipX = true;
        }
        else if(playerTransform.position.x > transform.position.x )
        {
            sprite.flipX = false;
        }

        if(health <= 0)
        {
            Death();
        }
        Vector2 target = new Vector2(playerTransform.position.x,playerTransform.position.y);
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);

        waitTime -= Time.deltaTime;
    }

    void FixedUpate()
    {
        
    }

    void OnCollisionStay2D(Collision2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            if(waitTime <=0)
            {
                player.TakeDamage(damage);
                waitTime = startWaitTime;
            }
        }
    }

    void Death()
    {
        player.coins +=1;
        GameObject.Destroy(gameObject);
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
    }
}

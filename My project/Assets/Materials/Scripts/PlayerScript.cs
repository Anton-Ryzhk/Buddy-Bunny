using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{

    public float speed;
    public int coins = 0;
    public float health;

    public float regeneration;
    public float winTime;
    private float hor;
    private float vert;

    public AudioSource lossSound;
    public GameObject LooseUI;
    public GameObject WinUI;

    public LevelChoseScript levelChose;
    public LevelManagerScript levelManager;

    private SpriteRenderer sprite;
    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        hor = Input.GetAxis("Horizontal");
        vert = Input.GetAxis("Vertical");
        
        if(hor < 0 )
        {
            sprite.flipX = true;
        }
        else if(hor > 0 )
        {
            sprite.flipX = false;
        }
        
        if(health <= 0.9f)
        {
            lossSound.Play();
            LooseUI.SetActive(true);
            levelChose.canPause = false;
            gameObject.SetActive(false);
        }

        if(levelManager.timer >= winTime)
        {
            lossSound.Play();
            WinUI.SetActive(true);
            levelChose.canPause = false;
            gameObject.SetActive(false);
        }
    }

    void FixedUpdate()
    {
        Vector2 dir = new Vector2(hor, vert);
        var step = speed * Time.fixedDeltaTime;
        transform.Translate(dir*step);
        health += regeneration / 50f;
    }

    public void GetCoin(int amount)
    {
        coins += amount;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
    }
}

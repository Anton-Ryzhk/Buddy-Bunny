using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerTextScript : MonoBehaviour
{
    // Start is called before the first frame update
    private LevelManagerScript lvlManager;

    private TMP_Text txt;
    void Start()
    {
        lvlManager = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<LevelManagerScript>();
        txt = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        txt.text = lvlManager.timer.ToString();
    }
}

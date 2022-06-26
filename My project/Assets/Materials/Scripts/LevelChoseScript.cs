using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class LevelChoseScript : MonoBehaviour
{
    private bool isGamePaused = false;
    public bool canPause = true;

    public GameObject pauseMenuUI;

    public AudioMixerGroup Mixer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(isGamePaused)
            {
                Resume();
            }
            else
            {
                if(canPause)
                {
                    Pause();
                }
            }
        }
    }

    public void StartLevel(int index)
    {
        Time.timeScale = 1f;
        isGamePaused = false;
        canPause = true;
        SceneManager.LoadScene(index);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isGamePaused = true;
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isGamePaused = false;
    }


    public void SoundToggle(bool isEnabled)
    {

    }

    public void ChangeVolume(float volume)
    {
        Mixer.audioMixer.SetFloat("Volume",Mathf.Lerp(-80,0,volume));
    }
}

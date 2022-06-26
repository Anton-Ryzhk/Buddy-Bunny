using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeChange : MonoBehaviour
{
    static float volume = 0.5f;
    [SerializeField] private Slider slider;
    void Start()
    {
        slider.value = volume;
    }

    // Update is called once per frame
    void Update()
    {
        AudioListener.volume = slider.value;
        volume = slider.value;
    }
}

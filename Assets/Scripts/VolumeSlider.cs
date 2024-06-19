using System.Collections;
using System.Collections.Generic;
// VolumeSlider.cs
using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    public VolumeManager volumeManager;
    private Slider slider;

    private void Awake()
    {
        slider = GetComponent<Slider>();
        slider.onValueChanged.AddListener(OnVolumeChanged);
    }

    private void Start()
    {
       // slider = GetComponent<Slider>();
       // slider.onValueChanged.AddListener(OnVolumeChanged);
        slider.value = volumeManager.volume;
    }



    public void OnVolumeChanged(float newVolume)
    {
        volumeManager.SetVolume(newVolume);
    }
}


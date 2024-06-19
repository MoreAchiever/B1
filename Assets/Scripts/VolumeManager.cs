using System.Collections;
using System.Collections.Generic;
// VolumeManager.cs
using UnityEngine;

public class VolumeManager : MonoBehaviour
{
    public float volume;

    private void Start()
    {
        volume = PlayerPrefs.GetFloat("Volume", 0.27f);
        ApplyVolume();
    }

    public void SetVolume(float newVolume)
    {
        volume = newVolume;
        PlayerPrefs.SetFloat("Volume", volume);
        ApplyVolume();
    }

    private void ApplyVolume()
    {
        AudioSource[] audioSources = FindObjectsOfType<AudioSource>();
        foreach (AudioSource audioSource in audioSources)
        {
            audioSource.volume = volume;
        }
    }
}


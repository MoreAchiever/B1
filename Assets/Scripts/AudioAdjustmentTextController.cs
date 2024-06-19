using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using TMPro;

public class AudioAdjustmentTextController : MonoBehaviour
{
    private TextMeshProUGUI volumeText; // Reference to the UI Text component
    public Slider volumeSlider;

    void Awake()
    {
        volumeSlider.onValueChanged.AddListener(UpdateVolumeText);
        volumeText = GetComponent<TextMeshProUGUI>();
    }

    public void UpdateVolumeText(float volume)
    {
        int volumePercentage = Mathf.RoundToInt(volume * 100);
        volumeText.text = volumePercentage.ToString() + "%";
    }

    public void Update()
    {

    }

    /*
    public void DisplayAudio(float Volume)
    {
        yourMixer.SetFloat("myParam", Mathf.Log(Volume)*20);
        volumeText.text = Mathf.FloorToInt(Volume * 100) + "%";
    }

    /*
    public void UpdateVolumeText(float volume)
    {
        int volumePercentage = Mathf.RoundToInt(volume * 100);
        volumeText.text = "Volume: " + volumePercentage.ToString() + "%";
    }*/

}

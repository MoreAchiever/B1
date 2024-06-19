using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Aa : MonoBehaviour
{



    public CanvasGroup[] canvasGroups;
    private int currentStateIndex;
    public int initialStateIndex = 0;




    private void Start()
    {
        // Disable all Canvas groups except the initial state
        for (int i = 0; i < canvasGroups.Length; i++)
        {
            canvasGroups[i].gameObject.SetActive(i == initialStateIndex);
        }

        currentStateIndex = initialStateIndex;
    }

    private void SwitchState(int newStateIndex)
    {
        // Disable the current state
        canvasGroups[currentStateIndex].gameObject.SetActive(false);

        // Enable the new state
        canvasGroups[newStateIndex].gameObject.SetActive(true);

        currentStateIndex = newStateIndex;
    }


    public void MainToAudio()
    {

        SwitchState(2);

    }
    public void AudioToMain()
    {
        SwitchState(0);

    }
    
}

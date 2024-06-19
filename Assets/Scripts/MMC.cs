using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MMC : MonoBehaviour
{



    public CanvasGroup[] canvasGroups;
    private int currentStateIndex;
    public int initialStateIndex = 0;
    private bool Walkthrough_on = false;




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


    // Start is called before the first frame update
    public void MainMenu()
    {
        SwitchState(1);
    }

    public void CloseMainMenu()
    {
        SwitchState(0);
        Walkthrough_on = false;
    }

    public void Walkthrough()
    {
        if (Walkthrough_on == false)
        {
            SwitchState(2);
            Walkthrough_on = true;
        }
        else
        {
         SwitchState(1);
         Walkthrough_on = false;
        }
    }
}

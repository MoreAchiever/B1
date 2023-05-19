using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public CanvasGroup OptionPanel;
    public CanvasGroup OptionPanel2;


    public void PlayGame()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); 

    }

    public void Option()
    {
        OptionPanel.alpha = 1;
        OptionPanel.blocksRaycasts = true;
    }

    public void back()
    {
        OptionPanel.alpha = 0;
        OptionPanel2.alpha = 0;
        OptionPanel2.blocksRaycasts = false;
        OptionPanel.blocksRaycasts = false;
    }

    public void QuitGame()
    {
        OptionPanel2.alpha = 2;
        OptionPanel2.blocksRaycasts = true;
    }
}

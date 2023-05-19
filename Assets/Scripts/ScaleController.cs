using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScaleController : MonoBehaviour
{
    private CanvasGroup[] canvasGroups;

    private void Start()
    {
        // Get all CanvasGroups in the scene
        canvasGroups = FindObjectsOfType<CanvasGroup>();
        
        // Match the scale of each CanvasGroup to the screen scale
        foreach (CanvasGroup canvasGroup in canvasGroups)
        {
            RectTransform rectTransform = canvasGroup.GetComponent<RectTransform>();
            rectTransform.localScale = new Vector3(Screen.width, Screen.height, 1f);
        }
    }
}

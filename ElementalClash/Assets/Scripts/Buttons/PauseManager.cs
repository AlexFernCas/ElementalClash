using UnityEngine;
using TMPro;
using Microsoft.Unity.VisualStudio.Editor;

public class PauseManager : MonoBehaviour
{
    private bool isPaused = false;
    public TMP_Text tMP_Text;

    void Start()
    {
        tMP_Text.text = "PAUSE";
    }
    public void PauseGame()
    {
        isPaused = !isPaused; 
        if (isPaused)
        {
            Time.timeScale = 0f;
            tMP_Text.text = "RESUME";
        }
        else 
        {
            Time.timeScale = 1f;
            tMP_Text.text = "PAUSE";
        }
    }
}
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    private bool isPaused = false;

    public void PauseGame()
    {
        isPaused = !isPaused; 
        if (isPaused)
        {
            Time.timeScale = 0f;
        }
        else 
        {
            Time.timeScale = 1f;
        }
    }
}
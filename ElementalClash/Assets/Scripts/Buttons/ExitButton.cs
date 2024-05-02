using UnityEngine;

public class ExitButton : MonoBehaviour
{
    public void ExitGame()
    {
        // Salir del juego
        Application.Quit();
        Debug.Log("Exit");        
    }
}
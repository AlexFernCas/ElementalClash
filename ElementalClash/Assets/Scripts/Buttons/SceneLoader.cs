using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void ShowBoard()
    {
        SceneManager.LoadScene("GameBoard");
    }

    public void ShowTutorial()
    {
        SceneManager.LoadScene("Tutorial");
    }

    public void ShowMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}

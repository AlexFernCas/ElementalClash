using UnityEngine;

public class MenuAudio : MonoBehaviour
{
    private static MenuAudio instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy();
        }
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }
}
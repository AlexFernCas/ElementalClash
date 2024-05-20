using UnityEngine;
using TMPro;
using Unity.Android.Gradle;

public class Message : MonoBehaviour
{
    public TMP_Text text;
    private float countdownTime = 5f;
    public Player user;

    void Start()
    {
        InvokeRepeating("UpdateCountdown", 0f, 1f);
    }

    void Update()
    {

    }
    void UpdateCountdown()
    {
        countdownTime -= 1f;
        if (countdownTime <= 0)
        {
            text.text = "¡Comienza la partida!";
            CancelInvoke("UpdateCountdown"); 
            Invoke("NoElement", 2f);
        }
        else
        {
            text.text = "Tiempo restante: " + countdownTime.ToString("F0");
        }
    }

    public void PlayerScores()
    {
        text.enabled = true;
        text.text = "¡Has anotado un punto!";
        countdownTime = 5f;
        InvokeRepeating("UpdateCountdown", 2f, 1f);
    }

    public void MlAgentScores()
    {
        text.enabled = true;
        text.text = "¡El rival ha anotado un punto!";
        countdownTime = 5f;
        InvokeRepeating("UpdateCountdown", 2f, 1f);
    }

    public void PlayerWins ()
    {
        text.enabled = true;
        text.text = "¡Enhorabuena! Has ganado";
    }

    public void MlAgentWins ()
    {
        text.enabled = true;
        text.text = "¡Lástima! Has perdido";
    }

    public void NoElement ()
    {
        if (user.HasElement())
        {
            text.enabled = true;
            text.text = "¡Elige un elemento!";
            Invoke("HideMessage", 2f);
        }
        else{
            HideMessage();
        }
    }

    void HideMessage()
    {
        text.enabled = false; 
    }
}
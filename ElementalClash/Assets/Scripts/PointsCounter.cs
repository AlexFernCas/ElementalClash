using UnityEngine;
using TMPro;

public class PointsCounter : MonoBehaviour
{
    private int playerScore;
    public TMP_Text playerScoreText;
    private int mlAgentScore;
    public TMP_Text mlAgentScoreText;
    public Message message;

    void Start()
    {
        playerScore = 0;
        playerScoreText.text = "0";
        mlAgentScore = 0;
        mlAgentScoreText.text = "0";
        
    }

    public void playerScores()
    {
        playerScore += 1;
        playerScoreText.text = playerScore.ToString();
        if (playerScore == 3) 
        {
            message.PlayerWins();
        } else {
            message.PlayerScores();
        }

    }
  
    public void mlAgentScores()
    {
        mlAgentScore += 1;
        mlAgentScoreText.text = mlAgentScore.ToString();
        if (mlAgentScore == 3) 
        {
            message.MlAgentWins();
        } else {
            message.MlAgentScores();
        }
        
    }

    public int GetPlayerScore()
    {
        return playerScore;
    }

    public int GetMLAgentScore()
    {
        return mlAgentScore;
    }
}

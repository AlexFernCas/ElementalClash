using UnityEngine;

public class PointsCounter : MonoBehaviour
{
    private int playerScore;
    private int mlAgentScore;
    public Message message;
    public GameObject zeroUser;
    public GameObject oneUser;
    public GameObject twoUser;
    public GameObject threeUser;
    public GameObject zeroMlAgent;
    public GameObject oneMlAgent;
    public GameObject twoMlAgent;
    public GameObject threeMlAgent;


    void Start()
    {
        playerScore = 0;
        mlAgentScore = 0;

        zeroUser.SetActive(true);
        oneUser.SetActive(false);
        twoUser.SetActive(false);
        threeUser.SetActive(false);

        zeroMlAgent.SetActive(true);
        oneMlAgent.SetActive(false);
        twoMlAgent.SetActive(false);
        threeMlAgent.SetActive(false);
    }

    public void playerScores()
    {
        playerScore += 1;

        if (playerScore == 3) 
        {
            twoUser.SetActive(false);
            threeUser.SetActive(true);
            message.PlayerWins();
            return;
        }
        else if (playerScore == 1) 
        {
            zeroUser.SetActive(false);
            oneUser.SetActive(true);

        }
        else if (playerScore == 2)
        {
            oneUser.SetActive(false);
            twoUser.SetActive(true);
        }
        message.PlayerScores();
    }
  
    public void mlAgentScores()
    {
        mlAgentScore += 1;

        if (mlAgentScore == 3) 
        {
            twoMlAgent.SetActive(false);
            threeMlAgent.SetActive(true);
            message.MlAgentWins();
            return;
        }
        else if (mlAgentScore == 1) 
        {
            zeroMlAgent.SetActive(false);
            oneMlAgent.SetActive(true);

        }
        else if (mlAgentScore == 2)
        {
            oneMlAgent.SetActive(false);
            twoMlAgent.SetActive(true);
        }

        message.MlAgentScores();
        
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

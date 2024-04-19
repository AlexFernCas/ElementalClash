using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Sensors;
using Unity.MLAgents.Actuators;

public class MLAgent : Agent
{
    private WaveSpawner spawner;
    private PlayerUnit [] playerUnits;
    private MLAgentUnit [] mlAgentUnits;
    public Directioner rightDirectioner;
    public Directioner rightTopDirectioner;
    public Directioner rightBottomDirectioner;
    public Directioner leftCenterDirectioner;

    public int lastPlayerScore;
    public int lastMLAgentscore;

    void Start()
    {
        spawner = gameObject.GetComponent<WaveSpawner>();
        lastMLAgentscore = 0;
        lastPlayerScore = 0;
    }
    
    void Update()
    {
        AddReward(0.001f);
        CheckReward();
    }

    public override void CollectObservations(VectorSensor sensor)
    {
        bool leftDirectioner = GameMaster.Instance.GetLeftDirectioner();
        bool leftBottomDirectioner = GameMaster.Instance.GetLeftBottomDirectioner();
        bool leftTopDirectioner = GameMaster.Instance.GetLeftTopDirectioner();
        bool leftCenterDirectioner = GameMaster.Instance.GetLeftCenterDirectioner();
        bool rightDirectioner = GameMaster.Instance.GetRightDirectioner();
        bool rightBottomDirectioner = GameMaster.Instance.GetRightBottomDirectioner();
        bool rightTopDirectioner = GameMaster.Instance.GetRightTopDirectioner();
        bool rightCenterDirectioner = GameMaster.Instance.GetRightCenterDirectioner();

        sensor.AddObservation(leftDirectioner);
        sensor.AddObservation(leftBottomDirectioner);
        sensor.AddObservation(leftTopDirectioner);
        sensor.AddObservation(leftCenterDirectioner);
        sensor.AddObservation(rightDirectioner);
        sensor.AddObservation(rightBottomDirectioner);
        sensor.AddObservation(rightTopDirectioner);
        sensor.AddObservation(rightCenterDirectioner);
        /*
        playerUnits = FindObjectsOfType<PlayerUnit>();
        mlAgentUnits = FindObjectsOfType<MLAgentUnit>();
        foreach (PlayerUnit playerUnit in playerUnits)
        {
            sensor.AddObservation(playerUnit.position);
            sensor.AddObservation(playerUnit.rotation);
        }

        foreach (MLAgentUnit mLAgentUnit in mlAgentUnits)
        {
            sensor.AddObservation(mLAgentUnit.position);
            sensor.AddObservation(mLAgentUnit.rotation);
        }*/
    }

    public override void OnActionReceived(ActionBuffers actions)
    {
        int actionSelected = actions.DiscreteActions[0];
        switch (actionSelected)
        {
            case 0:
                ChangeRightDirectioner();
                Debug.Log("1");
                break;

            case 1:
                ChangeRightBottomDirectioner();
                Debug.Log("2");
                break;

            case 2:
                ChangeRightTopDirectioner();
                Debug.Log("3");
                break;
            
            case 3:
                ChangeLeftCenterDirectioner();
                Debug.Log("4");
                break;
        }
    }

    public void CheckReward(){
        if (GameMaster.Instance.GetPlayerScore() != lastPlayerScore)
        {
            lastPlayerScore++;
            AddReward(-5f);
            EndEpisode();
        }
        else if(GameMaster.Instance.GetMLAgentScore() != lastMLAgentscore)
        {
            lastMLAgentscore++;
            AddReward(10f);
            EndEpisode();
        }
    }

    public void ChangeRightDirectioner()
    {
        rightDirectioner.OnClickDirectioner();
        GameMaster.Instance.ChangeRightDirectioner();
    }

    public void ChangeRightTopDirectioner()
    {
        rightTopDirectioner.OnClickDirectioner();
        GameMaster.Instance.ChangeRightTopDirectioner();
    }

    public void ChangeRightBottomDirectioner()
    {
        rightBottomDirectioner.OnClickDirectioner();
        GameMaster.Instance.ChangeRightBottomDirectioner();
    }

    public void ChangeLeftCenterDirectioner()
    {
        leftCenterDirectioner.OnClickDirectioner();
        GameMaster.Instance.ChangeLeftTopDirectioner();
    }
}

using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Sensors;
using Unity.MLAgents.Actuators;

public class MLAgent : Agent
{
    public GameObject gMaster;
    public Player mlAgent;
    private BonusManager bonusManager;
    private GameMaster gameMaster;
    private PlayerUnit [] playerUnits;
    private MLAgentUnit [] mlAgentUnits;
    public Directioner rightDirectioner;
    public Directioner rightTopDirectioner;
    public Directioner rightBottomDirectioner;
    public Directioner leftCenterDirectioner;
    public int lastPlayerScore;
    public int lastMLAgentscore;

    private bool hasThreeSegBonus;
    private bool hasWallBonus;
    private bool hasDuplicateBonus;

    void Start()
    {
        lastMLAgentscore = 0;
        lastPlayerScore = 0;
        bonusManager = gMaster.GetComponent<BonusManager>();
        gameMaster = gMaster.GetComponent<GameMaster>();
    }
    
    void Update()
    {
        AddReward(0.001f);
        CheckReward();
    }

    public override void CollectObservations(VectorSensor sensor)
    {
        bool leftDirectioner = gameMaster.GetLeftDirectioner();
        bool leftBottomDirectioner = gameMaster.GetLeftBottomDirectioner();
        bool leftTopDirectioner = gameMaster.GetLeftTopDirectioner();
        bool leftCenterDirectioner = gameMaster.GetLeftCenterDirectioner();
        bool rightDirectioner = gameMaster.GetRightDirectioner();
        bool rightBottomDirectioner = gameMaster.GetRightBottomDirectioner();
        bool rightTopDirectioner = gameMaster.GetRightTopDirectioner();
        bool rightCenterDirectioner = gameMaster.GetRightCenterDirectioner();

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
/*
    public override void OnActionReceived(ActionBuffers actions)
    {
        int actionSelected = actions.DiscreteActions[0];
        switch (actionSelected)
        {
            case 0:
                ChangeRightDirectioner();
                break;

            case 1:
                ChangeRightBottomDirectioner();
                break;

            case 2:
                ChangeRightTopDirectioner();
                break;
            
            case 3:
                ChangeLeftCenterDirectioner();
                break;
            
            case 4:
                UseWallBonus();
                break;

            case 5:
                UseDuplicateBonus();
                break;

            case 6:
                UseThreeSegBonus();
                break;

            case 7:
                mlAgent.SetFireElement();
                break;
            
            case 8:
                mlAgent.SetWaterElement();
                break;
            
            case 9: 
                mlAgent.SetWindElement();
                break;

            case 10:
                mlAgent.SetEarthElement();
                break;
        }
    }
*/
    public void CheckReward(){
        if (gameMaster.pointsCounter.GetPlayerScore() != lastPlayerScore)
        {
            lastPlayerScore++;
            AddReward(-5f);
            EndEpisode();
        }
        else if(gameMaster.pointsCounter.GetMLAgentScore() != lastMLAgentscore)
        {
            lastMLAgentscore++;
            AddReward(10f);
            EndEpisode();
        }
    }

    public void ChangeRightDirectioner()
    {
        rightDirectioner.OnClickDirectioner();
        gameMaster.ChangeRightDirectioner();
    }

    public void ChangeRightTopDirectioner()
    {
        rightTopDirectioner.OnClickDirectioner();
        gameMaster.ChangeRightTopDirectioner();
    }

    public void ChangeRightBottomDirectioner()
    {
        rightBottomDirectioner.OnClickDirectioner();
        gameMaster.ChangeRightBottomDirectioner();
    }

    public void ChangeLeftCenterDirectioner()
    {
        leftCenterDirectioner.OnClickDirectioner();
        gameMaster.ChangeLeftTopDirectioner();
    }

    public void UseWallBonus()
    {
        if (hasWallBonus)
        {
            HasWallBonus();
            bonusManager.MlAgentWallBonus();
            AddReward(5f);
        }
    }

    public void UseThreeSegBonus(){
        if (hasThreeSegBonus)
        {
            HasThreeSegBonus();
            bonusManager.MlAgentUseThreeSegBonus();
            AddReward(5);
        }
    }

    public void UseDuplicateBonus(){
        if (hasDuplicateBonus)
        {
            HasDuplicateBonus();
            bonusManager.MlAgentDuplicateBonus();
            AddReward(5);
        }
    }
    public void HasThreeSegBonus(){
        hasThreeSegBonus = !hasThreeSegBonus;
    }

    public void HasWallBonus(){
        hasWallBonus = !hasWallBonus;
    }

    public void HasDuplicateBonus(){
        hasDuplicateBonus = !hasDuplicateBonus;
    }

    public void SimulateAction (int number)
    {
        switch (number)
        {
            case 0:
                ChangeRightDirectioner();
                break;

            case 1:
                ChangeRightBottomDirectioner();
                break;

            case 2:
                ChangeRightTopDirectioner();
                break;
            
            case 3:
                ChangeLeftCenterDirectioner();
                break;
        }
    }
}

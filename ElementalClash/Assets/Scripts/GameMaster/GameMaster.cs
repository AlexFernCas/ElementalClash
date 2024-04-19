using System.Collections;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
        public static GameMaster Instance;
        public GameObject[] bonusPrefab;
        private WaveSpawner mlAgent;
        public enum Element{
            Fire, 
            Water,
            Wind,
            Earth
        }
        public Elemental[] elements;
        public bool thereIsBonus;
        public Transform leftBonusSpawnPoint;
        public Transform rightBonusSpawnPoint;
        public static bool leftDirectioner;
        public static bool leftBottomDirectioner;
        public static bool leftTopDirectioner;
        public static bool leftCenterDirectioner;
        public static bool rightTopDirectioner;
        public static bool rightBottomDirectioner;
        public static bool rightCenterDirectioner;
        public static bool rightDirectioner;
        private int bonusTimer;
        private int [] bonus;
        private int bonusIndex;
        private int firstBonusTimer;
        private int takedBonus;
        private int playerScore;
        private int mlAgentScore;

    void Start()
    {
        if (Instance != this)
        {
            Destroy(Instance); 
            Instance = this;
        }
        mlAgent = FindObjectOfType<WaveSpawner>();
        bonus = new int [] {0, 1, 2};
        Shuffle(bonus);
        leftDirectioner = false;
        leftBottomDirectioner = false;
        leftTopDirectioner = false;
        leftCenterDirectioner = false;
        rightTopDirectioner = false;
        rightBottomDirectioner = false;
        rightCenterDirectioner = false;
        rightDirectioner = false;
        thereIsBonus = false;
        firstBonusTimer = 5;
        bonusTimer = 5;
        bonusIndex = 0;
        playerScore = 0;
        mlAgentScore = 0;
        takedBonus = 0;
        StartCoroutine(BonusPrefab());
    }

    IEnumerator BonusPrefab()
    {
        yield return new WaitForSeconds(firstBonusTimer);
        while(true)
        {
            yield return new WaitForSeconds(bonusTimer);
            if (!thereIsBonus)
            {
                thereIsBonus = true;
                Instantiate(bonusPrefab[bonus[bonusIndex]], leftBonusSpawnPoint.position, leftBonusSpawnPoint.rotation);
                Instantiate(bonusPrefab[bonus[bonusIndex]], rightBonusSpawnPoint.position, rightBonusSpawnPoint.rotation);
                BonusIndex();
            }
            yield return null;
        }
    }

    public void TakedBonus(){
        takedBonus++;
        if (takedBonus >= 2)
        {
            thereIsBonus = false;
            takedBonus = 0;
        }
    }

    private void BonusIndex()
    {
        bonusIndex++;
        if (bonusIndex >= bonus.Length) bonusIndex = 0;
    }

    void Shuffle<T>(T[] array)
    {
        int n = array.Length;
        while (n > 1)
        {
            int k = Random.Range(0, n--);
            T temp = array[n];
            array[n] = array[k];
            array[k] = temp;
        }
    }

    public void PlayerScores ()
    {
        playerScore++;
        StopUnitSpawning();
        DestroyAllElementals();
        if (EndGame()) return;
        ResumeUnitSpawning();       
    }

    public int GetPlayerScore(){
        return playerScore;
    }

    public void MLAgentScores()
    {
        mlAgentScore++;
        StopUnitSpawning();
        DestroyAllElementals();
        if (EndGame()) return;
        ResumeUnitSpawning();
    }

    public int GetMLAgentScore(){
        return mlAgentScore;
    }

    public bool EndGame()
    {
        return playerScore >= 3 || mlAgentScore >= 3;
    }
    public void DestroyAllElementals()
    {
        elements = FindObjectsOfType<Elemental>();
        if (elements != null)
        {
            foreach (Elemental element in elements)
            {
            Destroy(element.gameObject);
            }
        }    
    }

    public void StopUnitSpawning()
    {
        Player.Instance.StopAllCoroutines();
        Player.Instance.Scored();
        mlAgent.StopAllCoroutines();
        mlAgent.Scored();
    }

    public void ResumeUnitSpawning()
    {
        Player.Instance.StartCoroutine(Player.Instance.Spawn());
        Player.Instance.StartCoroutine(Player.Instance.AddAllPowers());
        Player.Instance.RestartPower();
        mlAgent.StartCoroutine(mlAgent.Spawn());
        mlAgent.StartCoroutine(mlAgent.AddAllPowers());
        mlAgent.RestartPower();
    }

    public void ChangeRightDirectioner ()
    {
        rightDirectioner = !rightDirectioner;
    }

    public void ChangeRightTopDirectioner()
    {
        rightTopDirectioner = !rightTopDirectioner;
    }

    public void ChangeRightBottomDirectioner()
    {
        rightBottomDirectioner = !rightBottomDirectioner;
    }

    public void ChangeRightCenterDirectioner()
    {
        rightCenterDirectioner = !rightCenterDirectioner;
    }

    public void ChangeLeftDirectioner()
    {
        leftDirectioner = !leftDirectioner;
    }
    public void ChangeLeftTopDirectioner()
    {
        leftTopDirectioner = !leftTopDirectioner;
    }

    public void ChangeLeftBottomDirectioner()
    {
        leftBottomDirectioner = !leftBottomDirectioner;
    }

    public void ChangeLeftCenterDirectioner()
    {
        leftCenterDirectioner = !leftCenterDirectioner;
    }

    public bool GetLeftDirectioner()
    {
        return leftDirectioner;
    }

    public bool GetLeftTopDirectioner()
    {
        return leftTopDirectioner;
    }

    public bool GetLeftBottomDirectioner()
    {
        return leftBottomDirectioner;
    }

    public bool GetLeftCenterDirectioner()
    {
        return leftCenterDirectioner;
    }

    public bool GetRightDirectioner()
    {
        return rightDirectioner;
    }
    public bool GetRightTopDirectioner()
    {
        return rightTopDirectioner;
    }

    public bool GetRightBottomDirectioner()
    {
        return rightBottomDirectioner;
    }
    public bool GetRightCenterDirectioner()
    {
        return rightCenterDirectioner;
    }
  
}

using System.Collections;
using UnityEngine;

public class BonusManager : MonoBehaviour
{

    public GameObject[] bonusPrefab;
    public Player user;
    public Player mlAgent;
    public BonusButton threeSegBonusButton;
    public BonusButton wallBonusButton;
    public BonusButton duplicateBonusButton;
    public Wall userWall;
    public Wall mlAgentWall;
    public Duplicate userDuplicate;
    public Duplicate mlAgentDuplicate;
    public Transform leftBonusSpawnPoint;
    public Transform rightBonusSpawnPoint;
    private int bonusTimer;
    private int [] bonus;
    private int bonusIndex;
    private int firstBonusTimer;
    private int takedBonus;
    public bool thereIsBonus;

    public void Start()
    {
        thereIsBonus = false;
        firstBonusTimer = 1;
        bonusTimer = 1;
        bonusIndex = 0;
        takedBonus = 0;
        bonus = new int [] {0, 1, 2};
        Shuffle(bonus);
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
                GameObject b1 = Instantiate(bonusPrefab[bonus[bonusIndex]], leftBonusSpawnPoint.position, leftBonusSpawnPoint.rotation);
                GameObject b2 = Instantiate(bonusPrefab[bonus[bonusIndex]], rightBonusSpawnPoint.position, rightBonusSpawnPoint.rotation);

                TakeBonus bonus1 = b1.GetComponent<TakeBonus>();
                TakeBonus bonus2 = b2.GetComponent<TakeBonus>();

                bonus1.SetBonusManager(this);
                //bonus1.SetMlAgent(mlAgent.GetComponent<MLAgent>());
                bonus2.SetBonusManager(this);
                //bonus2.SetMlAgent(mlAgent.GetComponent<MLAgent>());
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
    public void ActiveWallBonusButton()
    {
        if (!duplicateBonusButton.IsActive() && !threeSegBonusButton.IsActive())
        {
            wallBonusButton.SetActive(true);
        }
    }

    public void UserWallBonus()
    {
        wallBonusButton.SetActive(false);
        userWall.SetActive(true);
    }

    public void MlAgentWallBonus()
    {
        mlAgentWall.SetActive(true);
    }

    public void ActiveThreeSegBonusButton ()
    {
        if (!duplicateBonusButton.IsActive() && !wallBonusButton.IsActive())
        {
            threeSegBonusButton.SetActive(true);
        }
    }

    public void UserUseThreeSegBonus()
    {
        threeSegBonusButton.SetActive(false);
        StartCoroutine(ThreeSegBonus(user));
    }

    public void MlAgentUseThreeSegBonus()
    {
        StartCoroutine(ThreeSegBonus(mlAgent));
    }

    IEnumerator ThreeSegBonus (Player player)
    {
        player.unitsByWave = 6;
        player.spawnTimer = 0.25f;
        player.unitsCost = 5;
        yield return new WaitForSeconds(3f);
        player.unitsByWave = 3;
        player.spawnTimer = 0.5f;
        player.unitsCost = 10;
    }

    public void ActiveDuplicateBonusButton()
    {
        if (!threeSegBonusButton.IsActive() && !wallBonusButton.IsActive())
        {
           duplicateBonusButton.SetActive(true);
        }        
    }

    public void UseDuplicateBonus()
    {
        duplicateBonusButton.SetActive(false);
        userDuplicate.SetActive(true);
    }

    public void MlAgentDuplicateBonus()
    {
        mlAgentDuplicate.SetActive(true);
    }
}

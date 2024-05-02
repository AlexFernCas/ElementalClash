using System;
using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance;
    public PlayerUnit [] unitsPrefab;
    public Button fireButton;
    public Button waterButton;
    public Button windButton;
    public Button earthButton;
    public BonusButton threeSegBonusButton;
    public BonusButton wallBonusButton;
    public Wall wall;
    public BonusButton duplicateBonusButton;
    public Duplicate duplicate;
    public Transform spawnPoint;
    private int earthPower;
    private int firePower;
    private int waterPower;
    private int windPower;
    private int powerAdd;
    private GameMaster.Element currentElement;
    [SerializeField] private int startTimer;
    [SerializeField] private float spawnTimer;
    [SerializeField] private int wavesTimer;
    [SerializeField] private int unitsByWave; 
    [SerializeField] private int unitsCost;
    [SerializeField] private float powerTimer;
    private bool scored;

    void Awake()
    { 
        if (Instance != this)
        {
            Destroy(Instance); 
            Instance = this;
        }
        startTimer = 5;
        spawnTimer = 0.5f;
        wavesTimer = 2;
        unitsByWave = 3;
        unitsCost = 10;
        powerTimer = 1;
        earthPower = 100;
        firePower = 100;
        waterPower = 100;
        windPower = 100;
        powerAdd = 3;
        scored = false;
        RandomElement();
        StartCoroutine(Spawn());
        StartCoroutine(AddAllPowers());
    }

    void Update ()
    {
        fireButton.GetPower(firePower);
        waterButton.GetPower(waterPower);
        windButton.GetPower(windPower);
        earthButton.GetPower(earthPower);
    }

    public IEnumerator Spawn ()
    {
        yield return new WaitForSeconds(startTimer);
        while (true)
        {
            if (scored) 
            {
                Scored();
                yield return new WaitForSeconds(wavesTimer);  
            }
            for (int i = 0; i < unitsByWave; i++)
            {
                SpawnEnemy();
                yield return new WaitForSeconds(spawnTimer);
            }
            yield return new WaitForSeconds(wavesTimer);
        }
    }

    void SpawnEnemy()
    {
        switch(currentElement)
        {
            case GameMaster.Element.Fire:
                if (firePower < unitsCost) return;
                firePower -= unitsCost;
                break;
            
            case GameMaster.Element.Water:
                if (waterPower < unitsCost) return;
                waterPower -= unitsCost;
                break;

            case GameMaster.Element.Wind: 
                if (windPower < unitsCost) return;
                windPower -= unitsCost;
                break;

            case GameMaster.Element.Earth:
                if (earthPower < unitsCost) return;
                earthPower -= unitsCost;
                break;
        }

        int index = GetElementIndex();
        Instantiate(unitsPrefab[index], spawnPoint.position, spawnPoint.rotation);    
    }

    public IEnumerator AddAllPowers()
    {
        while(true)
        {
            yield return new WaitForSeconds(powerTimer);
            AddFirePower(powerAdd);
            AddWaterPower(powerAdd);
            AddWindPower(powerAdd);
            AddEarthPower(powerAdd);
        }
    }

    public void RestartPower()
    {
        AddFirePower(100);
        AddWaterPower(100);
        AddWindPower(100);
        AddEarthPower(100);
    }
    public void Scored ()
    {
        scored = !scored;
    }

    public void ActiveWallBonusButton()
    {
        if (!duplicateBonusButton.IsActive() && !threeSegBonusButton.IsActive())
        {
            wallBonusButton.SetActive(true);
        }
    }

    public void UseWallBonus()
    {
        wallBonusButton.SetActive(false);
        wall.SetActive(true);
    }

    public void ActiveThreeSegBonusButton ()
    {
        if (!duplicateBonusButton.IsActive() && !wallBonusButton.IsActive())
        {
            threeSegBonusButton.SetActive(true);
        }
    }

    public void UseThreeSegBonus()
    {
        threeSegBonusButton.SetActive(false);
        StartCoroutine(ThreeSegBonus());
    }
    IEnumerator ThreeSegBonus ()
    {
        unitsByWave = 6;
        spawnTimer = 0.25f;
        unitsCost = 5;
        yield return new WaitForSeconds(3f);
        unitsByWave = 3;
        spawnTimer = 0.5f;
        unitsCost = 10;
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
        duplicate.SetActive(true);
    }

    public void SetFireElement()
    {
        currentElement = GameMaster.Element.Fire;
    }

    public void AddFirePower(int power)
    {
        firePower += power;
        if (firePower > 100) firePower = 100;
    }

    public void SetWaterElement()
    {
        currentElement = GameMaster.Element.Water;
    }

    public void AddWaterPower(int power)
    {
        waterPower += power;
        if (waterPower > 100) waterPower = 100;
    }

    public void SetWindElement()
    {
        currentElement = GameMaster.Element.Wind;
    }

    public void AddWindPower(int power)
    {
        windPower += power;
        if (windPower > 100) windPower = 100;
    }

    public void SetEarthElement()
    {
        currentElement = GameMaster.Element.Earth;
    }

    public void AddEarthPower(int power)
    {
        earthPower += power;
        if (earthPower > 100) earthPower = 100;
    }

    private int GetElementIndex()
    {
        return currentElement switch
        {
            (GameMaster.Element.Fire) => 0,
            (GameMaster.Element.Water) => 1,
            (GameMaster.Element.Wind) => 2,
            (GameMaster.Element.Earth) => 3,
            _ => -1,
        };
    }

    void RandomElement()
    {
        int randomIndex = UnityEngine.Random.Range(0, 4);
        currentElement = (GameMaster.Element)randomIndex;
    }
}

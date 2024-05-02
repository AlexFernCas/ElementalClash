using System.Collections;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public GameObject[] enemyPrefab;
    public Transform spawnPoint;
    private  GameMaster.Element currentElement;
    [SerializeField] private int powerAdd;
    [SerializeField] private int unitCost;
    [SerializeField] private int startTimer;
    [SerializeField] private float spawnTimer;
    [SerializeField] private int wavesTimer;
    [SerializeField] private int powerTimer;
    private int earthPower;
    private int firePower;
    private int waterPower;
    private int windPower;
    private bool scored; 
    void Start()
    {
        firePower = 100;
        waterPower = 100;
        windPower = 100;
        earthPower = 100;
        powerAdd = 3;
        unitCost = 10;
        startTimer = 5;
        spawnTimer = 0.5f;
        wavesTimer = 2;
        powerTimer = 1;
        scored = false;
        StartCoroutine(Spawn());
        StartCoroutine(AddAllPowers());
    }

    public IEnumerator Spawn ()
    {
        yield return new WaitForSeconds(startTimer);
        while (true)
        {
            if (scored) { 
                yield return new WaitForSeconds(wavesTimer); 
                Scored();
            }
            for (int i = 0; i < 3; i++)
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
                if (firePower < unitCost) return;
                firePower -= unitCost;
                break;
            
            case GameMaster.Element.Water:
                if (waterPower < unitCost) return;
                waterPower -= unitCost;
                break;

            case GameMaster.Element.Wind: 
                if (windPower < unitCost) return;
                windPower -= unitCost;
                break;

            case GameMaster.Element.Earth:
                if (earthPower < unitCost) return;
                earthPower -= unitCost;
                break;
        }
        int randomIndex = Random.Range(0, enemyPrefab.Length); 
        Instantiate(enemyPrefab[randomIndex], spawnPoint.position, spawnPoint.rotation);
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
    public void Scored ()
    {
        scored = !scored;
    }

    public void RestartPower()
    {
        AddFirePower(100);
        AddWaterPower(100);
        AddWindPower(100);
        AddEarthPower(100);
    }

    public void AddFirePower(int power){
        firePower += power;
        if (firePower > 100) firePower = 100;
    }

    public void AddWaterPower(int power){
        waterPower += power;
        if (waterPower > 100) waterPower = 100;
    }

    public void AddWindPower(int power){
        windPower += power;
        if (windPower > 100) windPower = 100;
    }

    public void AddEarthPower(int power){
        earthPower += power;
        if (earthPower > 100) earthPower = 100;
        
    }
    public void SetFireElement(){
        currentElement = GameMaster.Element.Fire;
    }
    
    public void SetWaterElement(){
        currentElement = GameMaster.Element.Water;
    }

    public void SetWindElement(){
        currentElement = GameMaster.Element.Wind;
    }

    public void SetEarthElement(){
        currentElement = GameMaster.Element.Earth;
    }

}
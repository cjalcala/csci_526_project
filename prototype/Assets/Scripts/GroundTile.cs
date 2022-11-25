using System.Drawing;
using UnityEngine;

public class GroundTile : MonoBehaviour
{

    GroundSpawner groundSpawner;
    public GameObject obstaclePrefab;
    public GameObject obstacle2Prefab;
    public GameObject logPrefab;
    public GameObject coinPrefab;
    public GameObject sanctumEntrancePrefab;
    public GameObject HammerPrefab;
    //public GameObject TimePowerUpPrefab;
    public GameObject fiftyFiftyPowerUpPrefab;
    public GameObject hintPrefab;

    // level1
    public GameObject CucumberPrefab;
    public GameObject LemonPrefab;
    public GameObject YogurtPrefab;
    // level2
    public GameObject BasilPrefab;
    public GameObject TomatoPrefab;
    public GameObject OnionPrefab;
    // level3
    public GameObject MushroomPrefab;
    public GameObject PepperPrefab;
    public GameObject SteakPrefab;

    public GameObject CookingStationPrefab;

    public GameObject mousePrefab;

    // Start is called before the first frame update
    private void Start()
    {
        groundSpawner = GameObject.FindObjectOfType<GroundSpawner>();
    }

    private void OnTriggerExit(Collider other)
    {
        groundSpawner.SpawnTile(true, true, false);
        Destroy(gameObject, 2);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SpawnObstacle()
    {
        // Choose random point to spawn the obstacles
        int obstacleSpawnIndex = Random.Range(2, 5);
        Transform spawnPoint = transform.GetChild(obstacleSpawnIndex).transform;

        // Spawn the obstacle at the position
        int obstacleChoice = Random.Range(0, 2);
        // if (obstacleChoice < 2)
        // {
        //     Instantiate(obstacle2Prefab, spawnPoint.position, transform.rotation * Quaternion.Euler(new Vector3(0, Random.Range(0f, 360f), 0)), transform);
        // }
        // else
        // {
        //     Instantiate(obstacle2Prefab, spawnPoint.position, transform.rotation * Quaternion.Euler(new Vector3(0, Random.Range(0f, 360f), 0)), transform);
        // }
        if (GameTracker.level == 1){
            Instantiate(obstaclePrefab, spawnPoint.position, transform.rotation * Quaternion.Euler(new Vector3(0, Random.Range(0f, 360f), 0)), transform);

        }
        else if (GameTracker.level == 2){
            Instantiate(obstacle2Prefab, spawnPoint.position, transform.rotation * Quaternion.Euler(new Vector3(0, Random.Range(0f, 360f), 0)), transform);
        }
        else{
            Instantiate(logPrefab, spawnPoint.position, transform.rotation * Quaternion.Euler(new Vector3(0, Random.Range(0f, 360f), 0)), transform);
        }
        
    }

    // public void SpawnCoins()
    // {
    //     int coinsToSpawn = 2;
    //     for (int i = 0; i < coinsToSpawn; i++)
    //     {
    //         GameObject temp = Instantiate(coinPrefab, transform);
    //         temp.transform.position = GetRandomPointInCollider(GetComponent<Collider>());
    //     }
    // }

    // spwan ingredients along the path
    public void SpawnCucumber()
    {
        GameObject temp = Instantiate(CucumberPrefab, transform);
        temp.transform.position = GetRandomPointInCollider(GetComponent<Collider>());

    }
    public void SpawnLemon() 
    {
        GameObject temp = Instantiate(LemonPrefab, transform);
        temp.transform.position = GetRandomPointInCollider(GetComponent<Collider>());
    }
    public void SpawnYogurt() 
    {
        GameObject temp = Instantiate(YogurtPrefab, transform);
        temp.transform.position = GetRandomPointInCollider(GetComponent<Collider>());
    }
    public void SpawnBasil() 
    {
        GameObject temp = Instantiate(BasilPrefab, transform);
        temp.transform.position = GetRandomPointInCollider(GetComponent<Collider>());
    }

    public void SpawnTomato() 
    {
        GameObject temp = Instantiate(TomatoPrefab, transform);
        temp.transform.position = GetRandomPointInCollider(GetComponent<Collider>());
    }

    public void SpawnOnion() 
    {
        GameObject temp = Instantiate(OnionPrefab, transform);
        temp.transform.position = GetRandomPointInCollider(GetComponent<Collider>());
    }
    public void SpawnMushroom()
    {
        GameObject temp = Instantiate(MushroomPrefab, transform);
        temp.transform.position = GetRandomPointInCollider(GetComponent<Collider>());
    }
    public void SpawnPepper()
    {
        GameObject temp = Instantiate(PepperPrefab, transform);
        temp.transform.position = GetRandomPointInCollider(GetComponent<Collider>());
    }
    public void SpawnSteak()
    {
        GameObject temp = Instantiate(SteakPrefab, transform);
        temp.transform.position = GetRandomPointInCollider(GetComponent<Collider>());
    }

    public void SpawnStation()
    {
        GameObject temp = Instantiate(CookingStationPrefab, transform);
        temp.transform.position = GetRandomPointInCollider(GetComponent<Collider>());
    }

    public void SpawnFiftyFifty()
    {    
        GameObject temp = Instantiate(fiftyFiftyPowerUpPrefab, transform);
        // if(GameTracker.fiftyFiftyCount >= 1)
        // {
        //     Destroy(gameObject);
        // }
        // else
        // {
        temp.transform.position = GetRandomPointInCollider(GetComponent<Collider>());  
        // } 
    }

    public void SpawnHammer()
    {
        GameObject temp = Instantiate(HammerPrefab, transform);
        temp.transform.position = GetRandomPointInCollider(GetComponent<Collider>());
    }
    /*
    public void SpawnClock()
    {
        // for (int i = 0; i < 2; i++)
        // {
        GameObject temp = Instantiate(TimePowerUpPrefab, transform);
        temp.transform.position = GetRandomPointInCollider(GetComponent<Collider>());
        // }
    }
    */
    public void SpawnEntrance()
    {
        Collider collider = GetComponent<Collider>();
        Vector3 position = new Vector3(Random.Range(collider.bounds.min.x, collider.bounds.max.x), 0, Random.Range(collider.bounds.min.z, collider.bounds.max.z));
        if (position != collider.ClosestPoint(position))
        {
            position = GetRandomPointInCollider(collider);
        }
        Instantiate(sanctumEntrancePrefab, position, Quaternion.identity, transform);
        //temp.transform.position = GetRandomPointInCollider(GetComponent<Collider>());
    }
    public void SpawnHints() {
        GameObject temp = Instantiate(hintPrefab, transform);
        // if(GameTracker.hintCount >= 1)
        // {
        //     Destroy(gameObject);
        // }
        // else
        // {
        // temp.transform.position = GetRandomPointInCollider(GetComponent<Collider>());  
        // } 
        temp.transform.position = GetRandomPointInCollider(GetComponent<Collider>());
    }

    public void SpawnMouse() {
        GameObject temp = Instantiate(mousePrefab, transform);
        Vector3 p = GetRandomPointInCollider(GetComponent<Collider>());
        p.y=0.1f;
        temp.transform.position = p;
    }

    Vector3 GetRandomPointInCollider(Collider collider)
    {
        Vector3 point = new Vector3(
            Random.Range(collider.bounds.min.x, collider.bounds.max.x),
            Random.Range(collider.bounds.min.y, collider.bounds.max.y),
            Random.Range(collider.bounds.min.z, collider.bounds.max.z)
        );
        if (point != collider.ClosestPoint(point))
        {
            point = GetRandomPointInCollider(collider);
        }
        point.y = 1;
        return point;
    }
}

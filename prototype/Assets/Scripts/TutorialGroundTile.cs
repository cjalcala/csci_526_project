using UnityEngine;

public class TutorialGroundTile : MonoBehaviour
{

    public GameObject tutorialobstaclePrefab;
    TutorialGroundSpawner tutorialgroundSpawner;
    public GameObject tutorialcoinPrefab;
    public GameObject tutorialArrowPrefab;
    public GameObject tutorialIngredentPrefab;
    public GameObject HammerPrefab;
    //public GameObject TimePowerUpPrefab;
    public GameObject fiftyFiftyPowerUpPrefab;
    public GameObject hintPrefab;
    public GameObject cookingStationPrefab;

    // Start is called before the first frame update
    void Start()
    {
        tutorialgroundSpawner = GameObject.FindObjectOfType<TutorialGroundSpawner>();
        //TutorialSpawnObstacle();
        //TutorialSpawnCoins();
    }

    private void OnTriggerExit(Collider other)
    {
        //tutorialgroundSpawner.SpawnTutorialTile(true, true, false, false,false,false); 
        int i = TutorialGroundSpawner.i;
        // SpawnObstacle,  SpawnIngredent,  SpawnHammer,  SpawnClock, SpawnFifty,  SpawnHint

        if (i > 10 && i < 17)
        {
            tutorialgroundSpawner.SpawnTutorialTile(true, false, false, false, true, false, 4);//SpawnObstacle, SpawnFifty
        }
        else if (i >= 17 && i < 20)
        {
            tutorialgroundSpawner.SpawnTutorialTile(true, false, false, true, true, true, 5);//SpawnObstacle,  SpawnClock, SpawnFifty,  SpawnHint
        }
        else
        {
            tutorialgroundSpawner.SpawnTutorialTile(true, TutorialManager.popUpIndex <= 7 && TutorialManager.popUpIndex >= 4, false, false, true, true, 7);//SpawnObstacle,  SpawnIngredent when 50-50 ins displayed, start to spawn ingredient
        }
        
        //int state = TutorialManager.popUpIndex;

        //tutorialgroundSpawner.SpawnTutorialTile(state);


        TutorialGroundSpawner.i++;
        Destroy(gameObject, 2);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public Vector3 TutorialSpawnObstacle()
    {
        // Choose random point to spawn the obstacles
        int obstacleSpawnIndex = Random.Range(2, 5);
        // int obstacleSpawnIndex = 2;
        Transform spawnPoint = transform.GetChild(obstacleSpawnIndex).transform;

        // Spawn the obstacle at the position
        Instantiate(tutorialobstaclePrefab, spawnPoint.position, transform.rotation * Quaternion.Euler(new Vector3(0, Random.Range(0f, 360f), 0)), transform);
        return spawnPoint.position;
    }

    // public void TutorialSpawnObstacle()
    // {

    //     GameObject temp = Instantiate(tutorialArrowPrefab, transform);

    //     temp.transform.position = new Vector3(pos.x, pos.y * 5, pos.z);

    // }

    public void TutorialSpawnArrow(Vector3 pos, float multiple)
    {

        GameObject temp = Instantiate(tutorialArrowPrefab, transform);

        temp.transform.position = new Vector3(pos.x, pos.y * multiple, pos.z);

    }

    public Vector3 TutorialSpawnIngredent()
    {
        Collider collider = GetComponent<Collider>();
        Vector3 position = new Vector3(Random.Range(collider.bounds.min.x, collider.bounds.max.x), 1, Random.Range(collider.bounds.min.z, collider.bounds.max.z));
        if (position != collider.ClosestPoint(position))
        {
            position = GetRandomPointInCollider(collider);
        }
        Instantiate(tutorialIngredentPrefab, position, Quaternion.identity, transform);
        return position;
        //temp.transform.position = GetRandomPointInCollider(GetComponent<Collider>());
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

    public Vector3 SpawnHammer()
    {
        GameObject temp = Instantiate(HammerPrefab, transform);
        temp.transform.position = GetRandomPointInCollider(GetComponent<Collider>());
        return temp.transform.position;
    }


    public Vector3 SpawnStation()
    {

        GameObject temp = Instantiate(cookingStationPrefab, transform);
        temp.transform.position = GetRandomPointInCollider(GetComponent<Collider>());
        return temp.transform.position;
    }

    public Vector3 SpawnFiftyFifty()
    {
        GameObject temp = Instantiate(fiftyFiftyPowerUpPrefab, transform);
        temp.transform.position = GetRandomPointInCollider(GetComponent<Collider>());
        return temp.transform.position;
    }

    public Vector3 SpawnHints()
    {
        GameObject temp = Instantiate(hintPrefab, transform);
        temp.transform.position = GetRandomPointInCollider(GetComponent<Collider>());
        return temp.transform.position;
    }
}

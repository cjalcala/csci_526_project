using UnityEngine;

public class TutorialGroundTile : MonoBehaviour
{

    public GameObject tutorialobstaclePrefab;
    TutorialGroundSpawner tutorialgroundSpawner;
    public GameObject tutorialcoinPrefab;
    public GameObject tutorialsanctumEntrancePrefab;

    // Start is called before the first frame update
    void Start()
    {
        tutorialgroundSpawner = GameObject.FindObjectOfType<TutorialGroundSpawner>();
        //TutorialSpawnObstacle();
        //TutorialSpawnCoins();
    }

    private void OnTriggerExit(Collider other) 
    {
        tutorialgroundSpawner.SpawnTutorialTile(true, true, true); 
        Destroy(gameObject, 2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     public void TutorialSpawnObstacle()
    {
        // Choose random point to spawn the obstacles
        int obstacleSpawnIndex = Random.Range(2, 5);
        Transform spawnPoint = transform.GetChild(obstacleSpawnIndex).transform;

        // Spawn the obstacle at the position
        Instantiate(tutorialobstaclePrefab, spawnPoint.position, Quaternion.identity, transform);
    }

    public void TutorialSpawnCoins()
    {
        int coinsToSpawn = 2;
        for(int i = 0; i < coinsToSpawn; i++)
        {
            GameObject temp = Instantiate(tutorialcoinPrefab, transform);
            temp.transform.position = GetRandomPointInCollider(GetComponent<Collider>());
        }
    }

    public void TutorialSpawnEntrance()
    {
        Collider collider = GetComponent<Collider>();
        Vector3 position = new Vector3(Random.Range(collider.bounds.min.x, collider.bounds.max.x), 1, Random.Range(collider.bounds.min.z, collider.bounds.max.z));
        if (position != collider.ClosestPoint(position))
        {
            position = GetRandomPointInCollider(collider);
        }
        Instantiate(tutorialsanctumEntrancePrefab, position, Quaternion.identity, transform);
        //temp.transform.position = GetRandomPointInCollider(GetComponent<Collider>());
    }

    Vector3 GetRandomPointInCollider(Collider collider)
    {
        Vector3 point = new Vector3(
            Random.Range(collider.bounds.min.x, collider.bounds.max.x),
            Random.Range(collider.bounds.min.y, collider.bounds.max.y),
            Random.Range(collider.bounds.min.z, collider.bounds.max.z)
        );
        if(point != collider.ClosestPoint(point))
        {
            point = GetRandomPointInCollider(collider);
        }
        point.y = 1;
        return point;
    }

}

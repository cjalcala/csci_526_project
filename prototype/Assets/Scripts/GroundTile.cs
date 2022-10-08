using System.Drawing;
using UnityEngine;

public class GroundTile : MonoBehaviour
{

    GroundSpawner groundSpawner;
    public GameObject obstaclePrefab;
    public GameObject coinPrefab;
    public GameObject sanctumEntrancePrefab;
    public GameObject HammerPrefab;

    // Start is called before the first frame update
    private void Start()
    {
        groundSpawner = GameObject.FindObjectOfType<GroundSpawner>();
        //SpawnHammer();
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
        Instantiate(obstaclePrefab, spawnPoint.position, Quaternion.identity, transform);
    }

    public void SpawnCoins()
    {
        int coinsToSpawn = 2;
        for(int i = 0; i < coinsToSpawn; i++)
        {
            GameObject temp = Instantiate(coinPrefab, transform);
            temp.transform.position = GetRandomPointInCollider(GetComponent<Collider>());
        }
    }

    public void SpawnHammer()
    {
        GameObject temp = Instantiate(HammerPrefab, transform);
        temp.transform.position = GetRandomPointInCollider(GetComponent<Collider>());
    }

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

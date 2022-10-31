using Newtonsoft.Json.Bson;
using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    public GameManager gameManager;
    public GameObject groundTile;
    public GameObject terrainPrefab;
    public SanctumEntrance entrance;
    Vector3 nextSpawnPoint;
    public int hammerSpawnTime;
    int cnt = 0;


    public void SpawnTile(bool spawnItems, bool spawnTile, bool spawnHammer)
    {
        GameObject temp = Instantiate(groundTile, nextSpawnPoint, Quaternion.identity);
        nextSpawnPoint = temp.transform.GetChild(1).transform.position;
        GameObject leftTerrain = Instantiate(terrainPrefab, new Vector3(nextSpawnPoint.x - 15, nextSpawnPoint.y, nextSpawnPoint.z), Quaternion.identity);
        GameObject rightTerrain = Instantiate(terrainPrefab, new Vector3(nextSpawnPoint.x + 15, nextSpawnPoint.y, nextSpawnPoint.z), Quaternion.identity);

        if (spawnItems)
        {
            temp.GetComponent<GroundTile>().SpawnObstacle();
            temp.GetComponent<GroundTile>().SpawnCoins();
            int rand = Random.Range(0,100);
            if (rand == 1) {
                temp.GetComponent<GroundTile>().SpawnFiftyFifty();
            }
            
            if (SpawnEntrance() && spawnTile)
            {
                temp.GetComponent<GroundTile>().SpawnEntrance();
            }
        }
        if (spawnHammer)
        {
            temp.GetComponent<GroundTile>().SpawnHammer();
            // temp.GetComponent<GroundTile>().SpawnClock();
        }
        if (GameTracker.timeRemain < 75 && Mathf.Abs(GameTracker.timeRemain % 30) <= 1)
        {
            temp.GetComponent<GroundTile>().SpawnClock();
        }
    }

    public bool SpawnEntrance()
    {
        bool spawn = false;
        // float time = (GameTracker.originalTime - GameTracker.timeRemain) % 5;
        entrance = GameObject.FindObjectOfType<SanctumEntrance>();

        // if (entrance == null && (GameTracker.originalTime - GameTracker.timeRemain) > 5 && time < 5)
        // if (cnt < 3)
        // {
        spawn = true;
        cnt++;
        // }

        return spawn;
    }

    // Start is called before the first frame update
    private void Start()
    {
        hammerSpawnTime = Random.Range((int)GameTracker.timeRemain - 5, (int)GameTracker.timeRemain);
        Debug.Log(hammerSpawnTime);
        for (int i = 0; i < 15; i++)
        {
            //if (gameManager.tileCount < 2 && GameTracker.timeRemain > 118)
            if (gameManager.tileCount < 1)
            {
                SpawnTile(false, false, false);
            }
            else if (cnt < 2 && i % 8 == 0)
            {
                SpawnTile(true, true, false);
            }
            else
            {
                SpawnTile(true, false, false);
            }
            gameManager.tileCount += 1;

        }
    }

    void Update()
    {
        //Debug.Log(GameTracker.timeRemain);
        if (GameTracker.timeRemain <= hammerSpawnTime)
        {
            //Debug.Log("True");
            SpawnTile(true, true, true);
            hammerSpawnTime = -1;
        }
    }
}

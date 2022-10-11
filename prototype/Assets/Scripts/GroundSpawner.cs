using Newtonsoft.Json.Bson;
using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    public GameManager gameManager;
    public GameObject groundTile;
    public SanctumEntrance entrance;
    Vector3 nextSpawnPoint;
    public int hammerSpawnTime;
    int cnt = 0;


    public void SpawnTile(bool spawnItems, bool spawnTile, bool spawnHammer)
    {
        GameObject temp = Instantiate(groundTile, nextSpawnPoint, Quaternion.identity);
        nextSpawnPoint = temp.transform.GetChild(1).transform.position;

        if (spawnItems)
        {
            temp.GetComponent<GroundTile>().SpawnObstacle();
            temp.GetComponent<GroundTile>().SpawnCoins();
            if (SpawnEntrance() && spawnTile)
            {
                temp.GetComponent<GroundTile>().SpawnEntrance();
            }
        }
        if(spawnHammer)
        {
            temp.GetComponent<GroundTile>().SpawnHammer();
        }
    }

    public bool SpawnEntrance()
    {
        bool spawn = false;
        // float time = (ScoreTracker.originalTime - ScoreTracker.timeRemain) % 5;
        entrance = GameObject.FindObjectOfType<SanctumEntrance>();

        // if (entrance == null && (ScoreTracker.originalTime - ScoreTracker.timeRemain) > 5 && time < 5)
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
        hammerSpawnTime = Random.Range((int)ScoreTracker.timeRemain-5, (int)ScoreTracker.timeRemain);
        Debug.Log(hammerSpawnTime);
        for (int i = 0; i < 15; i++)
        {
            //if (gameManager.tileCount < 2 && ScoreTracker.timeRemain > 118)
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
        //Debug.Log(ScoreTracker.timeRemain);
        if(ScoreTracker.timeRemain<=hammerSpawnTime)
        {
            //Debug.Log("True");
            SpawnTile(true, true, true);
            hammerSpawnTime = -1; 
        }
    }
}

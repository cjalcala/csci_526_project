using Newtonsoft.Json.Bson;
using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    public GameManager gameManager;
    public GameObject groundTile;
    public SanctumEntrance entrance;
    Vector3 nextSpawnPoint;

    public void SpawnTile(bool spawnItems, bool spawmTile)
    {
        GameObject temp = Instantiate(groundTile, nextSpawnPoint, Quaternion.identity);
        nextSpawnPoint = temp.transform.GetChild(1).transform.position;

        if (spawnItems)
        {
            temp.GetComponent<GroundTile>().SpawnObstacle();
            temp.GetComponent<GroundTile>().SpawnCoins();
            if (SpawnEntrance() && spawmTile)
            {
                temp.GetComponent<GroundTile>().SpawnEntrance();
            }
        }
    }

    public bool SpawnEntrance()
    {
        bool spawn = false;
        // float time = (ScoreTracker.originalTime - ScoreTracker.timeRemain) % 5;
        entrance = GameObject.FindObjectOfType<SanctumEntrance>();

        // if (entrance == null && (ScoreTracker.originalTime - ScoreTracker.timeRemain) > 5 && time < 5)
        if (entrance == null)
        {
            spawn = true;
        }

        return spawn;
    }

    // Start is called before the first frame update
    private void Start()
    {
        for (int i = 0; i < 15; i++)
        {
            if (i < 2 && ScoreTracker.timeRemain >= 118)
            {
                SpawnTile(false, false);
            }

            // else if (i < 1)
            // {
            //     SpawnTile(true, false);
            // }
            else
            {
                SpawnTile(true, true);
            }

        }
    }
}

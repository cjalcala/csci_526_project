using Newtonsoft.Json.Bson;
using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    public GameManager gameManager;
    public GameObject groundTile;
    public SanctumEntrance entrance;
    Vector3 nextSpawnPoint;

    public void SpawnTile(bool spawnItems)
    {
        GameObject temp = Instantiate(groundTile, nextSpawnPoint, Quaternion.identity);
        nextSpawnPoint = temp.transform.GetChild(1).transform.position;

        if (spawnItems)
        {
            temp.GetComponent<GroundTile>().SpawnObstacle();
            temp.GetComponent<GroundTile>().SpawnCoins();
            if (SpawnEntrance())
            {
                temp.GetComponent<GroundTile>().SpawnEntrance();
            }
        }
    }

    public bool SpawnEntrance()
    {
        bool spawn = false;
        float time = (gameManager.originalTime - gameManager.timeRemain) % 11;
        entrance = GameObject.FindObjectOfType<SanctumEntrance>();

        if (entrance == null && (gameManager.originalTime - gameManager.timeRemain) > 5 && time < 5)
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
            if (i < 2)
            {
                SpawnTile(false);
            }
            else
            {
                SpawnTile(true);
            }
            
        }
    }
}

using UnityEngine;

public class TutorialGroundSpawner : MonoBehaviour
{

    public GameObject groundTile;
    public GameObject terrainPrefab;
    Vector3 nextSpawnPoint;


    public void SpawnTutorialTile(bool SpawnObstacle, bool SpawnCoins, bool SpawnEntrance) 
    {
        GameObject temp = Instantiate(groundTile, nextSpawnPoint, Quaternion.identity);
        nextSpawnPoint = temp.transform.GetChild(1).transform.position;
        GameObject leftTerrain = Instantiate(terrainPrefab, new Vector3(nextSpawnPoint.x - 15, nextSpawnPoint.y, nextSpawnPoint.z), Quaternion.identity);
        GameObject rightTerrain = Instantiate(terrainPrefab, new Vector3(nextSpawnPoint.x + 15, nextSpawnPoint.y, nextSpawnPoint.z), Quaternion.identity);

        if (SpawnObstacle)
        {
            temp.GetComponent<TutorialGroundTile>().TutorialSpawnObstacle();
        }

        if(SpawnCoins)
        {
            temp.GetComponent<TutorialGroundTile>().TutorialSpawnCoins();
        }

        if(SpawnEntrance)
        {
            temp.GetComponent<TutorialGroundTile>().TutorialSpawnEntrance();
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 25; i++)
        {
            if(i < 5)
            {
                SpawnTutorialTile(false, false, false);
            }
            else if(i>=5 && i<=7)
            {
                SpawnTutorialTile(true, false, false);
            }
            else if(i>7 && i<15)
            {
                SpawnTutorialTile(true, true, false);
            }
            else
            {
                SpawnTutorialTile(true, true, true);
            }
        }
    }
}

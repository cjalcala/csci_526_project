using UnityEngine;

public class TutorialGroundSpawner : MonoBehaviour
{

    public GameObject groundTile;
    Vector3 nextSpawnPoint;


    public void SpawnTutorialTile(bool SpawnObstacle)
    {
        GameObject temp = Instantiate(groundTile, nextSpawnPoint, Quaternion.identity);
        nextSpawnPoint = temp.transform.GetChild(1).transform.position;

        if(SpawnObstacle)
        {
            temp.GetComponent<TutorialGroundTile>().TutorialSpawnObstacle();
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 15; i++)
        {
            if(i < 5)
            {
                SpawnTutorialTile(false);
            }
            else
            {
                SpawnTutorialTile(true);
            }
        }
    }
}

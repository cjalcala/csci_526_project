using UnityEngine;

public class TutorialGroundSpawner : MonoBehaviour
{

    public GameObject groundTile;
    public GameObject terrainPrefab;
    Vector3 nextSpawnPoint;
    public int hammerSpawnTime;


    public void SpawnTutorialTile(bool SpawnObstacle, bool SpawnIngredent, bool SpawnHammer, bool SpawnClock,bool SpawnFifty, bool SpawnHint) 
    {
        GameObject temp = Instantiate(groundTile, nextSpawnPoint, Quaternion.identity);
        nextSpawnPoint = temp.transform.GetChild(1).transform.position;
        GameObject leftTerrain = Instantiate(terrainPrefab, new Vector3(nextSpawnPoint.x - 15, nextSpawnPoint.y, nextSpawnPoint.z), Quaternion.identity);
        GameObject rightTerrain = Instantiate(terrainPrefab, new Vector3(nextSpawnPoint.x + 15, nextSpawnPoint.y, nextSpawnPoint.z), Quaternion.identity);

        if (SpawnObstacle)
        {
            temp.GetComponent<TutorialGroundTile>().TutorialSpawnObstacle();
        }
        if(SpawnIngredent)
        {
            temp.GetComponent<TutorialGroundTile>().TutorialSpawnIngredent();
        }
        if (SpawnHammer)
        {
            temp.GetComponent<TutorialGroundTile>().SpawnHammer();
            // temp.GetComponent<GroundTile>().SpawnClock();
        }
        if (SpawnClock)
        {
            temp.GetComponent<TutorialGroundTile>().SpawnClock();
        }
        if (TutorialGameManager.time <= 80 && Mathf.Abs(TutorialGameManager.time % 20) <= 3)
        {
            temp.GetComponent<TutorialGroundTile>().SpawnClock();
        }
        if (SpawnFifty) {
            temp.GetComponent<TutorialGroundTile>().SpawnFiftyFifty();
        }
        if (SpawnHint) {
            temp.GetComponent<TutorialGroundTile>().SpawnHints();
        }
        if (TutorialManager.getIngredent) {
            temp.GetComponent<TutorialGroundTile>().SpawnStation();

        }

    }


    // Start is called before the first frame update
    void Start()
    {
        hammerSpawnTime = Random.Range((int)TutorialGameManager.time - 5, (int)TutorialGameManager.time);
        for (int i = 0; i < 26; i++)
        {

            if (i < 4) {//leftright jump hammer clock 50-50 hint onion cookingstation
                // SpawnObstacle,  SpawnIngredent,  SpawnHammer,  SpawnClock, SpawnFifty,  SpawnHint
                SpawnTutorialTile(false, false, false, false, false, false);
            }
            else if (i >= 4 && i <= 11) {
                SpawnTutorialTile(true, false, false, false, false, false);//SpawnObstacle
            }
            else if (i >= 11 && i <= 12) {
                SpawnTutorialTile(true, true, true, false, false, false);//SpawnObstacle, SpawnHammer
            }
            else if (i > 12 && i < 14) {
                SpawnTutorialTile(true, true, false, true, false, false);//SpawnObstacle, SpawnClock
            }
            else if (i >= 14 && i < 19) {
                SpawnTutorialTile(true, true, false, false, true, false);//SpawnObstacle, SpawnFifty
            }
            else if (i >= 19 && i < 23) {
                SpawnTutorialTile(true, true, false, true, true, true);//SpawnObstacle,  SpawnClock, SpawnFifty,  SpawnHint
            }
            else {
                SpawnTutorialTile(true, true, false, false, false, false);//SpawnObstacle,  SpawnIngredent
            }
        }
    }

     void Update()
     {
        //Debug.Log(GameTracker.timeRemain);
        //     if (TutorialGameManager.time <= hammerSpawnTime)
        //     {
        //         //Debug.Log("True");
        //         SpawnTutorialTile(true, true, true, false, false);
        //         hammerSpawnTime = -1;
        //     }
      }
}

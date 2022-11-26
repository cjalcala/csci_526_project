using UnityEngine;

public class TutorialGroundSpawner : MonoBehaviour
{

    public GameObject groundTile;
    public GameObject terrainPrefab;
    Vector3 nextSpawnPoint;
    public int hammerSpawnTime;
    public static int i = 0;

    public static bool showArrow = false;
    public Vector3 currArrowPos;

    public void SpawnTutorialTile(bool SpawnObstacle, bool SpawnIngredent, bool SpawnHammer, bool SpawnClock, bool SpawnFifty, bool SpawnHint, int state)
    //public void SpawnTutorialTile(int state)
    {
        GameObject temp = Instantiate(groundTile, nextSpawnPoint, Quaternion.identity);
        nextSpawnPoint = temp.transform.GetChild(1).transform.position;
        GameObject leftTerrain = Instantiate(terrainPrefab, new Vector3(nextSpawnPoint.x - 15, nextSpawnPoint.y, nextSpawnPoint.z), Quaternion.identity);
        GameObject rightTerrain = Instantiate(terrainPrefab, new Vector3(nextSpawnPoint.x + 15, nextSpawnPoint.y, nextSpawnPoint.z), Quaternion.identity);

        if (SpawnObstacle)
        {
            currArrowPos = temp.GetComponent<TutorialGroundTile>().TutorialSpawnObstacle();
        }
        if (SpawnIngredent)
        {
            currArrowPos = temp.GetComponent<TutorialGroundTile>().TutorialSpawnIngredent();
        }
        if (SpawnHammer)
        {
            currArrowPos = temp.GetComponent<TutorialGroundTile>().SpawnHammer();
            // temp.GetComponent<GroundTile>().SpawnClock();
        }

        if (SpawnFifty)
        {
            int rand = Random.Range(0, 3);
            if (rand == 1)
            {
                currArrowPos = temp.GetComponent<TutorialGroundTile>().SpawnFiftyFifty();
            }
        }
        if (SpawnHint)
        {
            int rand = Random.Range(0, 3);
            if (rand == 1)
            {
                currArrowPos = temp.GetComponent<TutorialGroundTile>().SpawnHints();
            }
        }

        // state = TutorialManager.popUpIndex;
        // Vector3 obsPos = new Vector3(0, 0, 0);

        // if (state == 1)
        // {
        //     currArrowPos = temp.GetComponent<TutorialGroundTile>().TutorialSpawnObstacle();
        // }
        // else if (state == 2)
        // {

        //     currArrowPos = temp.GetComponent<TutorialGroundTile>().SpawnHammer();
        //     obsPos = temp.GetComponent<TutorialGroundTile>().TutorialSpawnObstacle();


        // }
        // else if (state == 3)
        // {
        //     currArrowPos = temp.GetComponent<TutorialGroundTile>().SpawnFiftyFifty();
        // }
        // else if (state == 4)
        // {
        //     currArrowPos = temp.GetComponent<TutorialGroundTile>().SpawnHints();
        // }

        // else if (state == 5)
        // {
        //     currArrowPos = temp.GetComponent<TutorialGroundTile>().TutorialSpawnIngredent();
        // }

        // else if (state == 6)
        // {
        //     currArrowPos = temp.GetComponent<TutorialGroundTile>().SpawnStation();
        // }


        // if (!showArrow && state > 0 && state < 7)
        // {
        //     showArrow = true;
        //     if (state == 20)
        //     {
        //         // currArrowPos = temp.GetComponent<TutorialGroundTile>().TutorialSpawnObstacle();
        //         temp.GetComponent<TutorialGroundTile>().TutorialSpawnArrow(obsPos, 5);
        //     }
        //     else
        //     if (state == 1)
        //     {
        //         temp.GetComponent<TutorialGroundTile>().TutorialSpawnArrow(currArrowPos, 5);
        //     }
        //     else
        //     {
        //         temp.GetComponent<TutorialGroundTile>().TutorialSpawnArrow(currArrowPos, 3);
        //     }

        // }


        if (TutorialManager.getIngredent)
        {
            currArrowPos = temp.GetComponent<TutorialGroundTile>().SpawnStation();

        }



    }


    // Start is called before the first frame update
    void Start()
    {
        hammerSpawnTime = Random.Range((int)TutorialGameManager.time - 5, (int)TutorialGameManager.time);
        //SpawnTutorialTile(TutorialManager.popUpIndex);
        for (i = 0; i < 10; i++)
        {
            //SpawnTutorialTile(TutorialManager.popUpIndex);

                if (i < 4)
                {//leftright jump hammer clock 50-50 hint onion cookingstation
                    // SpawnObstacle,  SpawnIngredent,  SpawnHammer,  SpawnClock, SpawnFifty,  SpawnHint
                    SpawnTutorialTile(false, false, false, false, false, false, 0);
                }
                else if (i >= 4 && i < 7)
                {
                    SpawnTutorialTile(true, false, true, false, false, false, 1);//SpawnObstacle SpawnHammer
                }
                else if (i >= 7 && i <= 10)
                {
                    SpawnTutorialTile(true, false, false, true, false, false, 2);//SpawnObstacle, SpawnClock
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

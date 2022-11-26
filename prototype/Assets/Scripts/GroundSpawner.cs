using Newtonsoft.Json.Bson;
using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    public GameManager gameManager;
    public GameObject groundTile;
    public GameObject terrainPrefab;
    public SanctumEntrance entrance;
    public static bool i_set;
    
    Vector3 nextSpawnPoint;
    public int hammerSpawnTime;
    int cnt = 0;
    static int fiftyfityspawnFlag = 0;

    private GameObject[] stations;

    public void SpawnTile(bool spawnItems, bool spawnTile, bool spawnHammer)
    {
        GameObject temp = Instantiate(groundTile, nextSpawnPoint, Quaternion.identity);
        nextSpawnPoint = temp.transform.GetChild(1).transform.position;
        GameObject leftTerrain = Instantiate(terrainPrefab, new Vector3(nextSpawnPoint.x - 15, nextSpawnPoint.y, nextSpawnPoint.z), Quaternion.identity);
        GameObject rightTerrain = Instantiate(terrainPrefab, new Vector3(nextSpawnPoint.x + 15, nextSpawnPoint.y, nextSpawnPoint.z), Quaternion.identity);

        if (spawnItems)
        {
            temp.GetComponent<GroundTile>().SpawnObstacle();
            // temp.GetComponent<GroundTile>().SpawnCoins();

            // int rand = Random.Range(0,50);
            // if (rand == 1) {
            //     temp.GetComponent<GroundTile>().SpawnFiftyFifty();
            // }

            // rand = Random.Range(0, 20);
            // if (rand == 1) {
            //     temp.GetComponent<GroundTile>().SpawnHints();
            // }

            int rand;
            if(GameTracker.fiftyFiftyCount>=1)
            {
                // rand = Random.Range(0,50);
                // if (rand == 1) {
                //     temp.GetComponent<GroundTile>().SpawnFiftyFifty();
                // }
            }

            else
            {
                rand = Random.Range(0,10);
                if (rand == 1) {
                    if(fiftyfityspawnFlag == 0 && GameTracker.fiftyFiftyCount == 0)
                    {
                        temp.GetComponent<GroundTile>().SpawnFiftyFifty();
                        if(GameTracker.fiftyFiftyCount >= 1)
                        {
                            fiftyfityspawnFlag = 1;
                            GameObject fiftyfifty = GameObject.FindGameObjectWithTag("FiftyFifty").gameObject;
                            if (fiftyfifty.CompareTag("FiftyFifty"))
                            {
                                Destroy(fiftyfifty);
                            }
                        }
                    }
                }
            }

            if(GameTracker.hintCount>=1)
            {
                // rand = Random.Range(0,50);
                // if (rand == 1) {
                //     temp.GetComponent<GroundTile>().SpawnHints();
                // }
            }

            else
            {
                rand = Random.Range(0,10);
                if (rand == 1) {
                    temp.GetComponent<GroundTile>().SpawnHints();
                }
            }
            

            rand = Random.Range(0, 5);
            if (rand == 1 && GameTracker.level!=1) {
                temp.GetComponent<GroundTile>().SpawnMouse();
            }

            // randomly generate ingredients along the path
            int rand_ingredient = Random.Range(1, 4);
            if (rand_ingredient == 1) {
                if (GameTracker.level == 1) {
                    temp.GetComponent<GroundTile>().SpawnCucumber();
                }
                if (GameTracker.level == 2) {
                    temp.GetComponent<GroundTile>().SpawnBasil();
                }
                if (GameTracker.level == 3) {
                    temp.GetComponent<GroundTile>().SpawnMushroom();
                }
                
            }
            if (rand_ingredient == 2) {
                if (GameTracker.level == 1) {
                    temp.GetComponent<GroundTile>().SpawnLemon();
                } 
                if (GameTracker.level == 2) {
                    temp.GetComponent<GroundTile>().SpawnTomato();
                }
                if (GameTracker.level == 3) {
                    temp.GetComponent<GroundTile>().SpawnPepper();
                } 

                
            }
            if (rand_ingredient == 3) {
                if (GameTracker.level == 1) {
                    temp.GetComponent<GroundTile>().SpawnYogurt();
                }
                if (GameTracker.level == 2) {
                    temp.GetComponent<GroundTile>().SpawnOnion();
                }
                if (GameTracker.level == 3) {
                    temp.GetComponent<GroundTile>().SpawnSteak();
                }
                
            }
             i_set=gameManager.CheckIngredientSet();
            
            if (gameManager.CheckIngredientSet())

            {
                stations = GameObject.FindGameObjectsWithTag("CookingStation");
                if (stations.Length < 1)
                {
                    temp.GetComponent<GroundTile>().SpawnStation();
                }
            }



            else{

            
            stations = GameObject.FindGameObjectsWithTag("CookingStation");
                if (stations.Length < 1)
                {
                    temp.GetComponent<GroundTile>().SpawnStation();
                }
            // GameObject vedika_1 = GameObject.FindGameObjectWithTag("CookingStation").gameObject;
            // if (vedika_1.CompareTag("CookingStation")  )
            //         {
            //             Destroy(vedika_1);
            //         }    
            }

            

            
        }
        if (spawnHammer && GameTracker.level != 1)
        {
            temp.GetComponent<GroundTile>().SpawnHammer();
            // temp.GetComponent<GroundTile>().SpawnClock();
        }
        /*
        if (GameTracker.timeRemain < 75 && Mathf.Abs(GameTracker.timeRemain % 30) <= 1 && GameTracker.level == 3)
        {
            temp.GetComponent<GroundTile>().SpawnClock();
        }
        */
    }

    // Start is called before the first frame update
    private void Start()
    {
        hammerSpawnTime = Random.Range((int)GameTracker.timeRemain - 5, (int)GameTracker.timeRemain);
        Debug.Log(hammerSpawnTime);
        for (int i = 0; i < 10; i++)
        {
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

using UnityEngine;

public class TutorialGroundTile : MonoBehaviour
{

    public GameObject tutorialobstaclePrefab;
    TutorialGroundSpawner tutorialgroundSpawner;
    // Start is called before the first frame update
    void Start()
    {
        tutorialgroundSpawner = GameObject.FindObjectOfType<TutorialGroundSpawner>();
        //TutorialSpawnObstacle();
    }

    private void OnTriggerExit(Collider other) 
    {
        tutorialgroundSpawner.SpawnTutorialTile(true); 
        Destroy(gameObject, 2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     public void TutorialSpawnObstacle()
    {
        // Choose random point to spawn the obstacles
        int obstacleSpawnIndex = Random.Range(2, 5);
        Transform spawnPoint = transform.GetChild(obstacleSpawnIndex).transform;

        // Spawn the obstacle at the position
        Instantiate(tutorialobstaclePrefab, spawnPoint.position, Quaternion.identity, transform);
    }
}

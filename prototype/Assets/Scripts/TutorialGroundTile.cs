using UnityEngine;

public class TutorialGroundTile : MonoBehaviour
{

    TutorialGroundSpawner tutorialgroundSpawner;
    // Start is called before the first frame update
    void Start()
    {
        tutorialgroundSpawner = GameObject.FindObjectOfType<TutorialGroundSpawner>();
    }

    private void OnTriggerExit(Collider other) 
    {
        tutorialgroundSpawner.SpawnTutorialTile(); 
        Destroy(gameObject, 2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

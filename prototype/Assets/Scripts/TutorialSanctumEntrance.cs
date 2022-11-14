using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialSanctumEntrance : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (TutorialGameManager.tutCoinCnt < 2) return;
        if (other.gameObject.GetComponent<TutorialObstacle>() != null)
        {
            Destroy(gameObject);
            return;
        }

        if (other.gameObject.name != "Player")
        {
            return;
        }
        TutorialGameManager.tutCoinCnt -= 2;
        TutorialGameManager.ingredientNum++;
        Destroy(gameObject);

        // SceneManager.LoadScene("Sanctum");
    }
    // Update is called once per frame
    void Update()
    {

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalScreen : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Setup(float timeScore)
    {
        gameObject.SetActive(true);
    }

    public void ContinueButton()
    {
        SceneManager.LoadScene("Game");
    }

}

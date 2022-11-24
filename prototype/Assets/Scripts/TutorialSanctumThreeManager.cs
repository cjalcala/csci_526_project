using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TutorialSanctumThreeManager : MonoBehaviour
{
    public Button correctOption;
    public Button wrongOption;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void tutorialCompleteSceneBtn()
    {
        correctOption.image.color = new Color32(0,255,0,255);;
        Invoke("LoadTutorialComplete", 1.5f);
    }

    public void wrongBtn()
    {
        wrongOption.image.color = new Color32(255,0,0,255);;
    }

    public void LoadTutorialComplete()
    {
        SceneManager.LoadScene("TutorialComplete");
    }
}

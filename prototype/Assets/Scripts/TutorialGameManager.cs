using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialGameManager : MonoBehaviour
{

    public int score;
    public static TutorialGameManager inst;
    public Text tutorialCoinText;
    public static int tutCoinCnt;
    // Start is called before the first frame update

    private void Awake()
    {
        inst = this;
    }

    public void IncrementScore()
    {
        score++;
        tutorialCoinText.text= "        : " + score;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        tutCoinCnt=score;
    }
}

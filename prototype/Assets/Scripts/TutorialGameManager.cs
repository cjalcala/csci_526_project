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
    public Text timeText; 
    public static float time = 120;
    TutorialPlayerMovement tutorialplayerMovement;
    public static bool isPaused = false;
    public static bool horizontalArrows = false;
    public static bool spaceBar = false;
    // Start is called before the first frame update

    private void Awake()
    {
        inst = this;
    }

    public void IncrementScore()
    {
        score++;
        tutorialCoinText.text="        : "+score;
    }

    void Start()
    {
        tutorialplayerMovement = GameObject.FindObjectOfType<TutorialPlayerMovement>();
        isPaused = false;
        horizontalArrows = false;
        spaceBar = false;
    }

    // Update is called once per frame
    void Update()
    {
        tutCoinCnt=score;
        if (time > 0)
        {
            if((!isPaused ) && (!horizontalArrows) && (!spaceBar))
            {
                time -= Time.deltaTime;
                timeText.text = ": " + time.ToString("0") + " Sec";
            }
        }
        else
        {
            tutorialplayerMovement.Die();
        }
    }
}

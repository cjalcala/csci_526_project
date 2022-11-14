using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialGameManager : MonoBehaviour
{

    public static TutorialGameManager inst;
    public static int tutCoinCnt = 10;
    public Text timeText;
    public static float time = 90;
    public static int ingredientNum = 0;
    TutorialPlayerMovement tutorialplayerMovement;
    public static bool isPaused = false;
    public static bool horizontalArrows = false;
    public static bool spaceBar = false;
    public Image TimeSlider;
    // Start is called before the first frame update

    private void Awake()
    {
        inst = this;
    }

    void Start()
    {
        tutCoinCnt = 10;
        time = 90;
        tutorialplayerMovement = GameObject.FindObjectOfType<TutorialPlayerMovement>();
        isPaused = false;
        horizontalArrows = false;
        spaceBar = false;
    }

    // Update is called once per frame
    void Update()
    {
        // tutCoinCnt=score;
        if (time > 0)
        {
            if ((!isPaused) && (!horizontalArrows) && (!spaceBar))
            {
                time -= Time.deltaTime;
                // TimeSlider.fillAmount = time/90;
                timeText.text = ": " + time.ToString("0") + " Sec";
            }
        }
        else
        {
            tutorialplayerMovement.Die();
        }
    }

    public int getcoin()
    {
        return tutCoinCnt;
    }

    public void updateCoin(int val)
    {
        tutCoinCnt -= val;
    }
}

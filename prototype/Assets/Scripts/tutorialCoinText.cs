using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tutorialCoinText : MonoBehaviour
{
    // Start is called before the first frame update
    string heading = "x ";
    string ending = "/15";
    public Text text;
    void Start()
    {
        text.text = "x 10/15";
    }

    // Update is called once per frame
    void Update()
    {
        text.text = text.text = heading + TutorialGameManager.tutCoinCnt + ending;
    }
}
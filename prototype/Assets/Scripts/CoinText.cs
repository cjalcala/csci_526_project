using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinText : MonoBehaviour
{
    // Start is called before the first frame update
    string heading = "x ";
    // string ending = "/15";

    // int initialCoin = 0;
    string totalCoin = "";
    public Text text;
    void Start()
    {
        // text.text = "x 10/15";
        string[] arr = text.text.Split("/");
        totalCoin = "/" + arr[1];
    }

    // void coinSet(int initial, int total)
    // {
    //     this.initialCoin = initial;
    //     this.totalCoin = "/" + total;
    //     text.text = heading + initialCoin + totalCoin;
    // }



    // Update is called once per frame
    // mode: 0 tutorial
    // mode: 1 level 1
    // mode: 2 level 2 ...
    void Update()
    {
        if (TutorialManager.tutorialActive)
        {
            text.text = heading + TutorialGameManager.tutCoinCnt + totalCoin;
        }
        else
        {
            text.text = heading + GameTracker.coins + totalCoin;
        }

    }
}
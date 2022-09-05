using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CoinDisplay : MonoBehaviour
{

    public static int coinCount;
    public GameObject coinDisplay;

    // Update is called once per frame
    void Update()
    {
        coinDisplay.GetComponent<TextMeshProUGUI>().text = "" + coinCount;
    }
}

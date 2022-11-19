using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tutorialOnionText : MonoBehaviour
{
    // Start is called before the first frame update
    string heading = ": ";
    string ending = "";
    public Text text;
    void Start()
    {
        text.text = ": 0";
    }

    // Update is called once per frame
    void Update()
    {
        text.text = text.text = heading + TutorialGameManager.ingredientNum + ending;
    }
}
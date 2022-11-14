using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tutorialOnionText : MonoBehaviour
{
    // Start is called before the first frame update
    string heading = "x ";
    string ending = "/1";
    public Text text;
    void Start()
    {
        text.text = "x 0/1";
    }

    // Update is called once per frame
    void Update()
    {
        text.text = text.text = heading + TutorialGameManager.ingredientNum + ending;
    }
}
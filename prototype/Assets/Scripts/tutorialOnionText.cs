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
    public int prev;
    void Start()
    {
        text.text = ": 0";
    }

    // Update is called once per frame
    void Update()
    {
        if (prev != TutorialGameManager.ingredientNum) {
            prev = TutorialGameManager.ingredientNum;
            text.text = heading + TutorialGameManager.ingredientNum + ending;
            StartCoroutine(FadeTextToFullAlpha(1f, text));
            
        }
       // text.text = text.text = heading + TutorialGameManager.ingredientNum + ending;
    }
    public IEnumerator FadeTextToFullAlpha(float t, Text i) {
        i.color = new Color(i.color.r, i.color.g, i.color.b, 0);
        while (i.color.a < 1.0f) {
            i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a + (Time.deltaTime / t));
            yield return null;
        }
    }
}
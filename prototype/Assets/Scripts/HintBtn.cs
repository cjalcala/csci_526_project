using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HintBtn : MonoBehaviour
{
    public Text questionText; 
    public Button btn;
    public void giveHint() {
        btn.gameObject.SetActive(false);
        questionText.text = questionText.text + "\nHint: " + SanctumQuiz.hint;
        GameTracker.hintCount--;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

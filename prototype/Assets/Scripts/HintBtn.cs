using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HintBtn : MonoBehaviour
{
    public Text hintText; 
    public Button btn;
    public void giveHint() {
        btn.gameObject.SetActive(false);
        hintText.text = "<color=red>Hint: "+ SanctumQuiz.hint + "</color>";
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

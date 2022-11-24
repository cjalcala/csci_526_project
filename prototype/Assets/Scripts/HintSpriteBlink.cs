using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HintSpriteBlink : MonoBehaviour
{
    //private SpriteRenderer sr;
    public float minimum = 0.5f;
    public float maximum = 1f;
    public float cyclesPerSecond = 0.5f;
    private float a;
    private bool increasing = true;
    public Image HintBtnSprite;
    Color color;    

    // Start is called before the first frame update
    void Start()
    {
        //sr = gameObject.GetComponent<SpriteRenderer>();
        color = HintBtnSprite.color;
        a = maximum;
    }

    // Update is called once per frame
    void Update()
    {
        float t = Time.deltaTime;
        if (a >= maximum) increasing = false;
        if (a <= minimum) increasing = true;
        a = increasing ? a += t * cyclesPerSecond * 2 : a -= t * cyclesPerSecond;
        color.a = a;
        HintBtnSprite.color = color;
    }
}

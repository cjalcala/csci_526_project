using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvatarSkinSwitcher : MonoBehaviour
{
    public Material[] mats;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(ChangeBleed());
        StartCoroutine(ChangeBleedHammer());


    }

    IEnumerator ChangeBleed()
    {
        if (TutorialObstacle.hit == true)
        {
            GetComponent<Renderer>().material = mats[1];
            yield return new WaitForSeconds(1);
            GetComponent<Renderer>().material = mats[0];



        }

    }
    
    IEnumerator ChangeBleedHammer()
    {
        if (TutorialManager.hammerFlag != 0){
            GetComponent<Renderer>().material = mats[2];
            yield return new WaitForSeconds(5.0f);
            GetComponent<Renderer>().material = mats[0];
        }

        if (GameTracker.hammerFlag != 0){
            GetComponent<Renderer>().material = mats[2];
            yield return new WaitForSeconds(5.0f);
            GetComponent<Renderer>().material = mats[0];
        }
    }
}
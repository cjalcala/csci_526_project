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
        StartCoroutine(ChangeHammerEffect());


    }

    IEnumerator ChangeBleed()
    {

        if ((TutorialManager.tutorialActive && TutorialObstacle.hit) || (!TutorialManager.tutorialActive && (Obstacle.hit || Mouse.hit)))

        {
            GetComponent<Renderer>().material = mats[1];
            yield return new WaitForSeconds(1);
            GetComponent<Renderer>().material = mats[0];
        }



    }


    IEnumerator ChangeHammerEffect()
    {
        if (TutorialManager.tutorialActive && TutorialManager.hammerFlag == 1)
        {
            GetComponent<Renderer>().material = mats[2];
            yield return new WaitForSeconds(5.0f);
            GetComponent<Renderer>().material = mats[0];
        }
        else

        if (!TutorialManager.tutorialActive && GameTracker.hammerFlag == 1)
        {
            GetComponent<Renderer>().material = mats[2];
            yield return new WaitForSeconds(5.0f);
            GetComponent<Renderer>().material = mats[0];
        }
    }


}
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
}
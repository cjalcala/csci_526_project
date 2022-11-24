using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public bool floatUp;
    void Start()
    {
        floatUp = false;

    }

    // Update is called once per frame
    void Update()
    {

        StartCoroutine(helper());
    }

    IEnumerator helper()
    {
        if (floatUp)
        {
            // floatingUp();
            transform.position += new Vector3(0, 0.4f * Time.deltaTime, 0);
            yield return new WaitForSeconds(1);
            floatUp = false;
        }

        else
        {
            // floatingDown();
            transform.position -= new Vector3(0, 0.4f * Time.deltaTime, 0);
            yield return new WaitForSeconds(1);
            floatUp = true;
        }
    }


}

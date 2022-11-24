using UnityEngine;
using System.Collections;

public class AnimationScript : MonoBehaviour
{

    public bool isAnimated = false;

    public bool isRotating = false;
    public bool isFloating = false;
    public bool isScaling = false;
    public bool isBounce = false;

    public Vector3 rotationAngle;
    public float rotationSpeed;

    public float floatSpeed;
    private bool goingUp = true;
    public float floatRate;
    private float floatTimer;

    public Vector3 startScale;
    public Vector3 endScale;

    private bool scalingUp = true;
    public float scaleSpeed;
    public float scaleRate;
    private float scaleTimer;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {




        if (isAnimated)
        {

            if (isRotating)
            {
                transform.Rotate(0, 0, 0.45f * Time.deltaTime);
                // bool up = true;
                // if ()
                // transform.position

            }

            if (isBounce)
            {
                // transform.Rotate(0, 0.45f * Time.deltaTime, 0);
                // int goingUp = -1;
                // if (goingUp == 1)
                // {
                //     transform.position += new Vector3(0, 0.01f, 0);
                // }
                // else
                // {
                //     transform.position -= new Vector3(0, 0.01f, 0);
                // }
                // goingUp *= -1;
                // floatTimer += Time.deltaTime;

                goingUp = false;
                if (goingUp)
                {
                    goingUp = false;
                    // floatTimer = 0;
                    floatSpeed *= -1;
                    for (int j = 1; j < 5; j++)
                    {
                        transform.position = new Vector3(transform.position.x, transform.position.y + 0.1f, transform.position.z);
                    }
                    // transform.position.y += 0.5 * Time.deltaTime;
                }
                else
                {
                    goingUp = true;
                    // floatTimer = 0;
                    floatSpeed *= -1;
                    for (int j = 1; j < 5; j++)
                    {
                        transform.position = new Vector3(transform.position.x, transform.position.y - 0.1f, transform.position.z);
                    }
                }

                int i = 0;
                // while (i < 100)
                // {
                //     i++;
                // }

                // transform.position = new Vector3(transform.position.x, transform.position.y + floatSpeed, transform.position.z);

            }

            if (isFloating)
            {
                floatTimer += Time.deltaTime;
                Vector3 moveDir = new Vector3(0.0f, 0.0f, floatSpeed);
                transform.Translate(moveDir);

                if (goingUp && floatTimer >= floatRate)
                {
                    goingUp = false;
                    floatTimer = 0;
                    floatSpeed = -floatSpeed;
                }

                else if (!goingUp && floatTimer >= floatRate)
                {
                    goingUp = true;
                    floatTimer = 0;
                    floatSpeed = +floatSpeed;
                }
            }

            if (isScaling)
            {
                scaleTimer += Time.deltaTime;

                if (scalingUp)
                {
                    transform.localScale = Vector3.Lerp(transform.localScale, endScale, scaleSpeed * Time.deltaTime);
                }
                else if (!scalingUp)
                {
                    transform.localScale = Vector3.Lerp(transform.localScale, startScale, scaleSpeed * Time.deltaTime);
                }

                if (scaleTimer >= scaleRate)
                {
                    if (scalingUp) { scalingUp = false; }
                    else if (!scalingUp) { scalingUp = true; }
                    scaleTimer = 0;
                }
            }
        }
    }
}

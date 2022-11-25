using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class player2bag : MonoBehaviour
{
    // Start is called before the first frame update
    public Sprite sprite;
    public Rigidbody rb;
    private Coroutine movementCoroutine;
    private Transform destination;
    public GameObject bagUI;
    public float moveSpeed = 1f;
    public static player2bag inst;
    public Camera cam;
    void Start() {
        inst = this;
        gameObject.SetActive(false); 
    }
    public void MoveToBag(string name) {
        destination = bagUI.transform.GetChild(bagUI.transform.childCount - 1);
        gameObject.SetActive(true);
        gameObject.GetComponent<Image>().sprite = IngredientMapping.getSprite(name);
        transform.position = RectTransformUtility.WorldToScreenPoint(cam,rb.position);


        // if the coroutine is still running, stop it
        if (movementCoroutine != null) {
            StopCoroutine(movementCoroutine);
        }

        // start the coroutine
        movementCoroutine = StartCoroutine(MoveToDestinationCoroutine());
    }
        // the coroutine
    private IEnumerator MoveToDestinationCoroutine() {

        // while this object is not at the destinationad
        while (transform.position != destination.position) {

            // move it towards the destination, never moving farther than "moveSpeed" in one frame.
            transform.position = Vector2.MoveTowards(transform.position, destination.position, moveSpeed );

            // wait until next frame to continue
            yield return null;
            //gameObject.SetActive(false);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Coin : MonoBehaviour
{
    public GameObject player;
    public float speed = 5;
    public float height = 0.5f;

    // Update is called once per frame
    void Update()
    {
        Vector3 origin_pos = transform.position;
        float y_pos = Mathf.Sin(Time.time * speed) * height;
        transform.position = new Vector3(origin_pos.x, y_pos, origin_pos.z);
    }

    private void OnTriggerEnter(Collider other)
    {
        this.gameObject.GetComponent<CapsuleCollider>().enabled = false;
        CoinDisplay.coinCount += 1;
        this.gameObject.SetActive(false);
    }
}

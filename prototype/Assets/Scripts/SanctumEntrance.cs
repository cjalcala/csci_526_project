using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SanctumEntrance : MonoBehaviour
{
    PlayerMovement playerMovement;
    public Mesh[] mesh;
    public Material[] mat;

    // Start is called before the first frame update
    void Start()
    {
        playerMovement = GameObject.FindObjectOfType<PlayerMovement>();
        int idx = Random.Range(0, mesh.Length);
        Mesh curr = mesh[idx];
        GetComponent<MeshFilter>().mesh = curr;
        GetComponent<Renderer>().material = mat[idx];

    }

    private void OnTriggerEnter(Collider other)
    {

        SceneManager.LoadScene("Sanctum");
    }

    // Update is called once per frame
    void Update()
    {

    }
}

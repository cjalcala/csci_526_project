using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SanctumEntrance : MonoBehaviour
{
    PlayerMovement playerMovement;
    public Mesh[] mesh;
    public Material[] mat;
    public int ingredientID;
    public string[] ingredientList = { "Broccoli", "Onion", "Meat" };//TODO: Create spresdsheet to match index to ingredient
    // Start is called before the first frame update
    void Start()
    {
        playerMovement = GameObject.FindObjectOfType<PlayerMovement>();
        int idx = Random.Range(0, mesh.Length);
        ingredientID = idx;
        Mesh curr = mesh[idx];
        GetComponent<MeshFilter>().mesh = curr;
        GetComponent<Renderer>().material = mat[idx];

    }

    private void OnTriggerEnter(Collider other)
    {
        //PlayerPrefs.SetInt("IngredientID", ingredientID);
        PlayerPrefs.SetString("IngredientID", ingredientList[ingredientID]);

        SceneManager.LoadScene("Sanctum");
    }

    // Update is called once per frame
    void Update()
    {

    }
}

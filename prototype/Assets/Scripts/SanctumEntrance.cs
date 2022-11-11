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
    List<string> result ;
    static System.Random random=new System.Random();
    public string[] ingredientList = { "Broccoli", "Onion", "Steak", "Bread", "Avocado", "Mushroom",
    "Tomato", "Pepper"};//TODO: Create spresdsheet to match index to ingredient
    // Start is called before the first frame update
    void Start()
    {
        List<int> indx= new List<int>();
        result=GameTracker.uncompletedIngredients();
        
        for(int i=0;i<result.Count;i++)
        {
            if(result[i]=="Broccoli")
            {
                indx.Add(0);

            }
            if(result[i]=="Onion")
            {
                indx.Add(1);

            }
            if(result[i]== "Steak")
            {
                indx.Add(2);

            }
            if (result[i] == "Bread")
            {
                indx.Add(3);

            }
            if (result[i] == "Avocado")
            {
                indx.Add(4);

            }
            if (result[i] == "Mushroom")
            {
                indx.Add(5);

            }
            if (result[i] == "Tomato")
            {
                indx.Add(6);

            }
            if (result[i] == "Pepper")
            {
                indx.Add(7);

            }

        }
        

        playerMovement = GameObject.FindObjectOfType<PlayerMovement>();
        //int idx = Random.Range(0, mesh.Length);
        // var random=new Random();

        if(indx.Count != 0)
        {
            int idx=indx[random.Next(indx.Count)];
            ingredientID = idx;
            Mesh curr = mesh[idx];
            GetComponent<MeshFilter>().mesh = curr;
            GetComponent<Renderer>().material = mat[idx];
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        //PlayerPrefs.SetInt("IngredientID", ingredientID);
        PlayerPrefs.SetString("IngredientID", ingredientList[ingredientID]);
        if(other.gameObject.GetComponent<Obstacle>()!=null)
        {
            Destroy(gameObject);
            return;
        }

        if(other.gameObject.name != "Player")
        {
            return;
        }

        Destroy(gameObject);

        if (GameTracker.coins >= GameTracker.ingredientsList[ingredientList[ingredientID]].cost)
        {

            //GameTracker.coins -= GameTracker.ingredientsList[ingredientList[ingredientID]].cost;
            SceneManager.LoadScene("Sanctum");

        }
        if (GameTracker.coins == 0 || GameTracker.coins < GameTracker.ingredientsList[ingredientList[ingredientID]].cost)
        {
            GameTracker.insufficientCoins = true;
        }

        else
        {
            return;
        }

        
    }

    // Update is called once per frame
    void Update()
    {

    }
}

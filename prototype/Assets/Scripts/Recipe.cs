using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.ParticleSystem;
public class Recipe : MonoBehaviour
{
    public string name { get; set; }
    public int earning { get; set; }

    public Recipe(string recipeName, int amtEarned)
    {
        name = recipeName;
        earning = amtEarned;
    }
}

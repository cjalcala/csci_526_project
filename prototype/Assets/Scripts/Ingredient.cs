using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.ParticleSystem;

public class Ingredient : MonoBehaviour
{
    //public string name { get; set; }
    public int requiredCount { get; set; }
    public int currentCount { get; set; }

    public Ingredient(string ingredientName, int required)
    {
        name = ingredientName;
        requiredCount = required;
        currentCount = 0;
    }
}

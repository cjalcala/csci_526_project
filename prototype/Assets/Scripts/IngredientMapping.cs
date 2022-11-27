using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientMapping : MonoBehaviour {
     public Sprite BasilIcon;
     public GameObject BasilPrefab;
     public Sprite CucumberIcon;
     public GameObject CucumberPrefab;
     public Sprite LemonIcon;
     public GameObject LemonPrefab;
     public Sprite MushroomIcon;
     public GameObject MushroomPrefab;
     public Sprite OnionIcon;
     public GameObject OnionPrefab;
     public Sprite PepperIcon;
     public GameObject PepperPrefab;
     public Sprite SteakIcon;
     public GameObject SteakPrefab;
     public Sprite TomatoIcon;
     public GameObject TomatoPrefab;
     public Sprite YogurtIcon;
    public GameObject YogurtPrefab;
    public static IngredientMapping inst;
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {

    }
    private void Awake() {
        inst = this;
    }

    public static Sprite getSprite(string name) {
        if (name == "Basil") {
            return inst.BasilIcon;
        }
        else if (name == "Cucumber") {
            return inst.CucumberIcon;
        }
        else if (name == "Lemon") {
            return inst.LemonIcon;
        }
        else if (name == "Mushroom") {
            return inst.MushroomIcon;
        }
        else if (name == "Onion") {
            return inst.OnionIcon;
        }
        else if (name == "Pepper") {
            return inst.PepperIcon;
        }
        else if (name == "Steak") {
            return inst.SteakIcon;
        }
        else if (name == "Tomato") {
            return inst.TomatoIcon;
        }
        else if (name == "Yogurt") {
            return inst.YogurtIcon;
        }

        else {
            return null;

        }
    }
    public static GameObject getPrefab(string name) {
        if (name == "Basil") {
            return inst.BasilPrefab;
        }
        else if (name == "Cucumber") {
            return inst.CucumberPrefab;
        }
        else if (name == "Lemon") {
            return inst.LemonPrefab;
        }
        else if (name == "Mushroom") {
            return inst.MushroomPrefab;
        }
        else if (name == "Onion") {
            return inst.OnionPrefab;
        }
        else if (name == "Pepper") {
            return inst.PepperPrefab;
        }
        else if (name == "Steak") {
            return inst.SteakPrefab;
        }
        else if (name == "Tomato") {
            return inst.TomatoPrefab;
        }
        else if (name == "Yogurt") {
            return inst.YogurtPrefab;
        }
        else {
            return null;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PauseMenu : MonoBehaviour
{
    // Start is called before the first frame update
   [SerializeField] public GameObject PauseMenuPanel;
   public static bool GameIsPaused = false;
   public GameObject Obj;

   public void Pause() {
    PauseMenuPanel.SetActive(true);
    Time.timeScale = 0f;
    GameIsPaused = true;
    Obj = GameObject.FindGameObjectWithTag("GameMusic");
    Obj.SetActive(false);
   }

   public void Resume() {
    PauseMenuPanel.SetActive(false);
    Time.timeScale = 1f;
    GameIsPaused = false;
    //Obj = GameObject.FindGameObjectsWithTag('GameMusic');
    Obj.SetActive(true);
   }

   public void Restart() {
    Time.timeScale = 1f;
    GameIsPaused = false;
    ScoreTracker.coins = 0;
    ScoreTracker.timeRemain = 120;
    ScoreTracker.ingredientsList = new SortedDictionary<string, Ingredient>();
    ScoreTracker.ingredientsList.Add("Broccoli", new Ingredient("Broccoli", 1, 2));
    ScoreTracker.ingredientsList.Add("Onion", new Ingredient("Onion", 1, 2));
    ScoreTracker.ingredientsList.Add("Steak", new Ingredient("Steak", 1, 2));
    Welcome.immunity = false;
    SceneManager.LoadScene("Game");
    Obj.SetActive(true);
   }


   public void ExitButton() {
    Time.timeScale = 1f;
    GameIsPaused = true;
    SceneManager.LoadScene("WelcomeScreen");
    Obj.SetActive(true);
   }

}

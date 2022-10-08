using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PauseMenu : MonoBehaviour
{
    // Start is called before the first frame update
   [SerializeField] public GameObject PauseMenuPanel;
   public static bool GameIsPaused = false;

   public void Pause() {
    PauseMenuPanel.SetActive(true);
    Time.timeScale = 0f;
    GameIsPaused = true;
   }

   public void Resume() {
    PauseMenuPanel.SetActive(false);
    Time.timeScale = 1f;
    GameIsPaused = false;
   }

   public void Restart() {
    Time.timeScale = 1f;
    GameIsPaused = false;
    ScoreTracker.coins = 0;
    ScoreTracker.timeRemain = 120;
    ScoreTracker.ingredientsList = new SortedDictionary<string, Ingredient>();
    ScoreTracker.ingredientsList.Add("Broccoli", new Ingredient("Broccoli", 1));
    ScoreTracker.ingredientsList.Add("Onion", new Ingredient("Onion", 1));
    ScoreTracker.ingredientsList.Add("Steak", new Ingredient("Steak", 1));
    Welcome.immunity = false;
    SceneManager.LoadScene("Game");
   }


   public void ExitButton() {
    Time.timeScale = 1f;
    GameIsPaused = true;
    SceneManager.LoadScene("WelcomeScreen");
   }

}

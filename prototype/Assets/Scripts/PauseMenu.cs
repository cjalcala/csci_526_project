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
    GameTracker.GameSetup();
    Welcome.immunity = false;
    GameTracker.LoadScenes();
    Obj.SetActive(true);
   }


   public void ExitButton() {
    Time.timeScale = 1f;
    GameIsPaused = true;
    SceneManager.LoadScene("WelcomeScreen");
    Obj.SetActive(true);
   }

}

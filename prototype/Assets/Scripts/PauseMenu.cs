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
   public static int audio_flag = 0;
   public static PauseMenu pm;


    private void Awake() {
        pm = this;
    }
   
   
   public void Pause() {
    PauseMenuPanel.SetActive(true);
    Time.timeScale = 0f;
    GameIsPaused = true;
    Obj = GameObject.FindGameObjectWithTag("GameMusic");
    //Obj.SetActive(false);
    // if (AudioListener.pause == false){ //music was playing
    //     audio_flag = 1;
    // }
    
    // AudioListener.pause = true;
   }

   public void Resume() {
    PauseMenuPanel.SetActive(false);
    Time.timeScale = 1f;
    GameIsPaused = false;
    //Obj = GameObject.FindGameObjectsWithTag('GameMusic');
    //Obj.SetActive(true);
    // if (audio_flag == 1){
    //     AudioListener.pause = false;
    // }else{
    //     AudioListener.pause = true;
    // }
   }

   public void Restart() {
    Time.timeScale = 1f;
    GameIsPaused = false;
    GameTracker.health=5;
    GameTracker.ingred1 = 0;
    GameTracker.ingred2 = 0;
    GameTracker.ingred3 = 0;
    SanctumQuiz.dish = 0;


    GameTracker.GameSetup();
    Welcome.immunity = false;
    GameTracker.LoadScenes();
    Obj.SetActive(true);

    
    // if (audio_flag == 1){
    //     AudioListener.pause = false;
    // }else{
    //     AudioListener.pause = true;
    // }

   }


   public void ExitButton() {
    Time.timeScale = 1f;
    GameIsPaused = true;
    GameTracker.ingred1 = 0;
    GameTracker.ingred2 = 0;
    GameTracker.ingred3 = 0;
    SanctumQuiz.dish = 0;
    SceneManager.LoadScene("WelcomeScreen");
    
    // if (audio_flag == 1){
    //     AudioListener.pause = false;
    // }else{
    //     AudioListener.pause = true;
    // }
   }

}

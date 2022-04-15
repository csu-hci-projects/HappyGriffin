using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool isPaused = false;
    public static bool automatic = true;
    public static bool recall = false;
    public static int half = 0;
    public GameObject pauseMenuUI;

    // Update is called once per frame
    void Update()
    {
        //if pause input is pressed
        if (Input.GetKeyDown(KeyCode.Escape)){
        if (isPaused){
            Resume();
        }
        else{
            Pause();
        }
        }
        if (Input.GetKeyDown(KeyCode.S)){
            playAnimations(gestures[half], automatic, recall)
    }
    }

    void playAnimations(char[] gestures, bool auto, bool recall){
        for(int i = 0; i < gestures.Length; i++){
            if(auto){
                Nathan.GetCompnent<Animator>().Play(gestures[i])
            }
            else{
                Pause();
                if(Input.GetKeyDown(KeyCode.Space)){
                    Resume();
                    Nathan.GetCompnent<Animator>().Play(gestures[i]);
                }
            }
        }
    }
    

    void Resume(){
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    void Pause(){
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }
}

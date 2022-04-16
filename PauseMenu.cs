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
    public Animator anim;
    public GameObject Nathan;

    // Update is called once per frame
    void Start()
    {
        

        //get settings: automatic and recall
        // if(Input.GetKeyDown(KeyCode.Alpha0)){
        //     automatic = true;
        //     recall = true;
        // }
        // if(Input.GetKeyDown(KeyCode.1)){
        //     automatic = false;
        //     recall = true;
        // }
        // if(Input.GetKeyDown(KeyCode.2)){
        //     automatic = true;
        //     recall = false;
        // }
        // if(Input.GetKeyDown(KeyCode.3)){
        //     automatic = false;
        //     recall = false;
        // }
    }

    void Update()
    {
        string[] g1 = {"A", "B"};
        string[] g2 = {"C", "Raise Hand"};
        string[][] gestures = {g1, g2};
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
            playAnimations(gestures[half], automatic, recall);
        }  
    }

    void playAnimations(string[] gestures, bool auto, bool recall){
        for(int i = 0; i < gestures.Length; i++){
            if(auto){
                Nathan.GetComponent<Animator>().Play(gestures[i]);
            }
            else{
                Pause();
                if(Input.GetKeyDown(KeyCode.Space)){
                    Resume();
                    Nathan.GetComponent<Animator>().Play(gestures[i]);
                }
            }
        }
        automatic = !auto;
        half = 1;
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

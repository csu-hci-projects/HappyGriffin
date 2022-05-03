using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{

    public GameObject pauseMenuUI;
    public Animator anim;
    public GameObject Nathan;
    public Text letter;

    public char let = 'A';
    public static bool isPaused = false;
    public static bool automatic = false;
    public static bool recall = false;
    public static int half = 0;
    public static int i = 0;
    public static int Lesson = 0;
    public float time = 0.0f;
    public float interval = 5f;



    // Update is called once per frame
    void Start()
    {
    }

    void Update()
    {
        string[] g1 = {"A", "B","C"};
        string[] g2 = {"C", "B", "A"};
        string[][] Gestures = {g1, g2};
        //choose lesson mode
        getMode();
        //automatic cannot pause
        
        if (Input.GetKeyDown(KeyCode.Space)){
            if (isPaused){
                Resume();
            }
            else{
                Pause();
            }
        }
        else{
        //S to Start
        //next lesson after n repeats
        if(Lesson == 2){
                if (half == 1){
                    Pause();
                }
                    half = 1;
                    Lesson = 0;
                    i = 0;
                    recall = !recall;
                }
        if(automatic){
            time += Time.deltaTime;
            if(time > interval){
                playAnimations(Gestures[half], recall);
                time = 0.0f;
            }
        }
        if(Input.GetKeyDown(KeyCode.S)){
            playAnimations(Gestures[half], recall); 
        }
        }
    }

    void playAnimations(string[] gestures, bool recall){
            Time.timeScale = .75f;
           // play the next gesture, i is counter
                Nathan.GetComponent<Animator>().Play(gestures[i%gestures.Length]);
                //go to next letter
                ++i;
                //show the answer for the first lesson, and non-recall lesson
                if(!recall || Lesson == 0){
                    showAnswer(gestures[i%gestures.Length].ToCharArray()[0]);
                }
                //restart lesson at the end
                if(i == gestures.Length){
                    ++Lesson;
                    i = 0;
                    if(Lesson == 2 && half == 0){
                        showAnswer('C');
                    }
                }
                if(recall && Lesson > 0 && i == 1){
                        let=' ';
                        letter.text = let.ToString();
                    }
                
                
                
    }

    void showAnswer(char myletter){
        letter.text = let.ToString();
        let = myletter;
    }
    
    void getMode(){
        if(Input.GetKeyDown(KeyCode.Alpha1)){
            automatic = true;
            recall = true;
        }
        if(Input.GetKeyDown(KeyCode.Alpha2)){
            automatic = true;
            recall = false;
        }
        if(Input.GetKeyDown(KeyCode.Alpha3)){
            automatic = false;
            recall = true;
        }
        if(Input.GetKeyDown(KeyCode.Alpha4)){
            automatic = false;
            recall = false;
        }
    }

    void Resume(){
        pauseMenuUI.SetActive(false);
        Time.timeScale = .75f;
        isPaused = false;
    }

    void Pause(){
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }
}

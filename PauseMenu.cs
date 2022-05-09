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
    public float interval = 1f;
    public bool form = true;



    // Update is called once per frame
    void Start()
    {
    }

    void Update()
    {
        string[] g1 = {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K","L","M"};
        string[] g2 = {"N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"};
        string[][] Gestures = {g1, g2};
        string[] word = {"B", "Y", "E"};
        //choose lesson mode
        getMode();
        //automatic cannot pause
        
        if (Input.GetKeyDown(KeyCode.S)){
            if(isPaused){
                Resume();
            }
            else{
                Pause();
            }
        }
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
        }else{
            if(Input.GetKeyDown(KeyCode.Space)){
                playAnimations(Gestures[half], recall); 
            }
            if(Input.GetKeyDown(KeyCode.Escape)){
                playAnimations(word, recall);
            }
        }
    }

    void playAnimations(string[] gestures, bool recall){
            Time.timeScale = 1.25f;
            // play the next gesture, i is counter
            if(form){
                Nathan.GetComponent<Animator>().Play(gestures[i%gestures.Length]);
                //show the answer for the first lesson, and non-recall lesson
                if(!recall || Lesson == 0){
                    showAnswer(gestures[i%gestures.Length].ToCharArray()[0]);
                }
                //go to next letter
                form = false;
            }else{
                Nathan.GetComponent<Animator>().Play("-"+gestures[i%gestures.Length]);
                form = true;
                ++i;
            }
            //restart lesson at the end
            
            if(recall && Lesson > 0 && i == 0){
                    let=' ';
                    letter.text = let.ToString();
                }
            if(i == gestures.Length){
                ++Lesson;
                i = 0;
                // if(Lesson == 2 && half == 0){
                //     showAnswer('N');
                // }
            }
    }

    void showAnswer(char myletter){
        let = myletter;
        letter.text = let.ToString();

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

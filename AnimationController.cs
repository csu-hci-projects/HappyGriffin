using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{

    public Animator anim;
    public GameObject Nathan;
    // Start is called before the first frame update
    void Start()
    {
        // Nathan.GetComponent<Animator>().Play("Raise Hand");
        // Nathan.GetComponent<Animator>().Play("A");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S)){
            Nathan.GetComponent<Animator>().Play("A");
        }

        while(true){
        }
    }
}

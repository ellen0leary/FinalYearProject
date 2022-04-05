using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GOAP : MonoBehaviour
{
    Animator anim;
    AnimatorStateInfo info;
    TheQueue queueCon;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        queueCon = GameObject.Find("Workers").GetComponent<TheQueue>();
    }

    // Update is called once per frame
    void Update()
    {
        info = anim.GetCurrentAnimatorStateInfo(0);

        if(info.IsName("Work")){
            // look at queue for stuff to do

            //if queue has item
                // go do it
            //else 
                //mill about
                //mabe feed other needs
        } else if (info.IsName("Eat")){
            // go to eat

            //find point 
            //send

            //if feed is high again move back
        } else if( info.IsName("Sleep")){
            // go to sleep

            //find point 
            //send

            //if sleep is high again move back
        } else if(info.IsName("Train")){
            // go to train

            //find point 
            //send

            //if train is high again move back
        }



    }

    public void lowSleep(){

    }


    public void lowEat(){

    }

    public void lowTrain(){

    }
}

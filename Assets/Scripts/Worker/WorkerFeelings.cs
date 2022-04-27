using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkerFeelings : MonoBehaviour
{
    public float sleepNeed;
    public float eatNeed;
    public float knowledge;
    public float accurcy;
    public bool ifAuto;
    GOAP goap;
    WorkerMovement move;

    float max = 100f;
    public float sleepVal, eatVal, trainVal;
    // Start is called before the first frame update
    void Start()
    {
        float diffence = (Random.Range(0,10));
        sleepVal = diffence/4f;
        diffence = (Random.Range(0,10));
        eatVal = diffence/4f;
        diffence = (Random.Range(0,10));
        trainVal = diffence/4f;
        sleepNeed = max;
        eatNeed = max;
        knowledge = max;
        accurcy = max;
        if(!ifAuto) goap = gameObject.GetComponent<GOAP>();
        else move = gameObject.GetComponent<WorkerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        sleepNeed -=( sleepVal * Time.deltaTime );
        eatNeed -= (eatVal* Time.deltaTime);
        knowledge -= (trainVal * Time.deltaTime);
        accurcy = sleepNeed/3+ eatNeed/3+ knowledge/2;
        
        if(sleepNeed<25 ){
            if(!ifAuto) goap.ifLowSleep(true);
            else move.setSpeed(false);
        }
        if(eatNeed<25 && !ifAuto){
            if(!ifAuto) goap.ifLowEat(true);
            else move.setSpeed(false);
        }
        if(knowledge<25 && !ifAuto){
            if(!ifAuto) goap.ifLowTrain(true);
            else move.setSpeed(false);
        }
    }


    public void IncreaseSleep(int value){
        sleepNeed += value;
        if(!ifAuto) goap.ifLowSleep(false);
        else move.setSpeed(true);
    }

    public void IncreaseEat(int value)
    {
        if(!ifAuto) goap.ifLowEat(false);
        else move.setSpeed(true);
        eatNeed += value;
    }

    public void IncreaseKnowledge(int value)
    {
        if(!ifAuto) goap.ifLowTrain(false);
        else move.setSpeed(false);
        knowledge += value;
    }

    void OnMouseEnter() {
        print("enter");
        if(Input.GetMouseButtonDown(0)){
            print("clicking");
        }
    }
}

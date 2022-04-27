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

    float max = 100f;
    public float sleepVal, eatVal, trainVal;
    // Start is called before the first frame update
    void Start()
    {
        float diffence = (Random.Range(0,10));
        sleepVal = diffence/3f;
        diffence = (Random.Range(0,10));
        eatVal = diffence/3f;
        diffence = (Random.Range(0,10));
        trainVal = diffence/3f;
        sleepNeed = max;
        eatNeed = max;
        knowledge = max;
        accurcy = max;
        goap = gameObject.GetComponent<GOAP>();
    }

    // Update is called once per frame
    void Update()
    {
        sleepNeed -=( sleepVal * Time.deltaTime );
        eatNeed -= (eatVal* Time.deltaTime);
        knowledge -= (trainVal * Time.deltaTime);
        accurcy = sleepNeed/3+ eatNeed/3+ knowledge/2;
        
        if(sleepNeed<25 && !ifAuto){
            goap.ifLowSleep(true);
        }
        if(eatNeed<25 && !ifAuto){
            goap.ifLowEat(true);
        }
        if(knowledge<25 && !ifAuto){
            goap.ifLowTrain(true);
        }
        // if (sleepNeed < 10 || eatNeed <= 15)
        // {
        //     this.gameObject.GetComponent<WorkerMovement>().setSpeed(false);
        //     this.gameObject.GetComponent<GOAP>().ifLowSleep(true);
        // } else {
        //     this.gameObject.GetComponent<WorkerMovement>().setSpeed(true);
        //     this.gameObject.GetComponent<GOAP>().ifLowSleep(false);
        // }
        // if(sleepNeed<=0 || eatNeed<=0 || knowledge<=0){
        //     this.gameObject.GetComponent<WorkerMovement>().noFeels(false);
        // } else {
        //     this.gameObject.GetComponent<WorkerMovement>().noFeels(true);
        // }
    }


    public void IncreaseSleep(int value){
        sleepNeed += value;
        goap.ifLowSleep(false);
    }

    public void IncreaseEat(int value)
    {
        goap.ifLowEat(false);
        eatNeed += value;
    }

    public void IncreaseKnowledge(int value)
    {
        goap.ifLowTrain(false);
        knowledge += value;
    }

    void OnMouseEnter() {
        print("enter");
        if(Input.GetMouseButtonDown(0)){
            print("clicking");
        }
    }
}

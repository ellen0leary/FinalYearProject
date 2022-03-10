using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkerFeelings : MonoBehaviour
{
    public float sleepNeed;
    public float eatNeed;
    public float knowledge;
    public float accurcy;

    float max = 100f;
    // Start is called before the first frame update
    void Start()
    {
        sleepNeed = max;
        eatNeed = max;
        knowledge = max;
        accurcy = max;
    }

    // Update is called once per frame
    void Update()
    {
        sleepNeed -= 2 * Time.deltaTime;
        eatNeed -= 4 * Time.deltaTime;
        knowledge -= 1 * Time.deltaTime;
        accurcy = sleepNeed/3+ eatNeed/3+ knowledge/2;
        if (sleepNeed < 10 || eatNeed <= 15)
        {
            this.gameObject.GetComponent<WorkerMovement>().setSpeed(false);
        } else {
            this.gameObject.GetComponent<WorkerMovement>().setSpeed(true);
        }
        if(sleepNeed<=0 || eatNeed<=0 || knowledge<=0){
            this.gameObject.GetComponent<WorkerMovement>().noFeels(false);
        } else {
            this.gameObject.GetComponent<WorkerMovement>().noFeels(true);
        }
    }


    public void IncreaseSleep(int value){
        sleepNeed += value;
    }

    public void IncreaseEat(int value)
    {
        eatNeed += value;
    }

    public void IncreaseKnowledge(int value)
    {
        knowledge += value;
    }

    void OnMouseEnter() {
        print("enter");
        if(Input.GetMouseButtonDown(0)){
            print("clicking");
        }
    }
}

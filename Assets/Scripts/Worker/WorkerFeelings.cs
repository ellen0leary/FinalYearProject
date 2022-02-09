using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkerFeelings : MonoBehaviour
{
    public float sleepNeed;
    public float eatNeed;
    public float knowledge;

    float max = 100f;
    // Start is called before the first frame update
    void Start()
    {
        sleepNeed = max;
        eatNeed = max;
        knowledge = max;
    }

    // Update is called once per frame
    void Update()
    {
        sleepNeed -= 5 * Time.deltaTime;
        eatNeed -= 5 * Time.deltaTime;
        knowledge -= 5 * Time.deltaTime;
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
}

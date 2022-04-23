using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class WorkerDisplay : MonoBehaviour
{
    WorkerFeelings wf;
    bool ifActive = false;

    Button sendToEatBtn, sendToSleepBtn, sendToTrainBtn;
    TextMeshProUGUI knowTxt , eatTxt, sleepTxt;
    // Start is called before the first frame update
    void Start()
    {
        wf = GetComponent<WorkerFeelings>();
        // sendToEatBtn = GameObject.Find("Eat Btn").GetComponent<Button>();
        // sendToSleepBtn = GameObject.Find("Eat Btn").GetComponent<Button>();
        // sendToTrainBtn = GameObject.Find("Eat Btn").GetComponent<Button>();

        knowTxt = GameObject.Find("knowledge").GetComponent<TextMeshProUGUI>();
        eatTxt = GameObject.Find("eat skill").GetComponent<TextMeshProUGUI>();
        sleepTxt = GameObject.Find("sleep skill").GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        // if(gameObject.activeInHierarchy){
        if (ifActive)
        {
            knowTxt.text = "knowledge skill " + (int)wf.knowledge;
            eatTxt.text = "eat need  " + (int)wf.eatNeed;
            sleepTxt.text = "knowledge skill " + (int)wf.sleepNeed;

            // sendToEatBtn.onClick.AddListener(() => sendToEat());
        }
    }

    public void setDeatils(){
        //get components
        knowTxt.text = "knowledge skill " + (int) wf.knowledge;
        eatTxt.text = "eat need  " + (int) wf.eatNeed;
        sleepTxt.text = "knowledge skill " + (int) wf.sleepNeed;
        ifActive = true;
        // sendToEatBtn.onClick.AddListener(() => sendToEat());
        // sendToSleepBtn.onClick.AddListener(() => sendToSleep());
        // sendToTrainBtn.onClick.AddListener(() => sendToTrain());
        //set component
    }

    public void sendToEat(){
        print ("Sending worker to eat");
    }

    public void sendToSleep(){
        print ("Sending worker to sleep");
    }
    public void sendToTrain(){
        print ("Sending worker to train");
    }
}

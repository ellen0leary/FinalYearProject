using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class WorkerDisplay : MonoBehaviour
{
    WorkerFeelings wf;
    bool ifActive = false;

    public Button sendToEatBtn, sendToSleepBtn, sendToTrainBtn,closeBtn;
    TextMeshProUGUI knowTxt , eatTxt, sleepTxt, nameTxt, ageTxt, favItemTxt;
    string name, age, favItem;


    private static string URL = "https://sensorial-hammer.000webhostapp.com/api/worker.php";
    // Start is called before the first frame update
    void Start()
    {
        wf = GetComponent<WorkerFeelings>();
        sendToEatBtn = GameObject.Find("eat btn").GetComponent<Button>();
        sendToSleepBtn = GameObject.Find("break btn").GetComponent<Button>();
        sendToTrainBtn = GameObject.Find("trainging btn").GetComponent<Button>();
        closeBtn = GameObject.Find("close btn").GetComponent<Button>();
        knowTxt = GameObject.Find("knowledge").GetComponent<TextMeshProUGUI>();
        eatTxt = GameObject.Find("eat skill").GetComponent<TextMeshProUGUI>();
        sleepTxt = GameObject.Find("sleep skill").GetComponent<TextMeshProUGUI>();
        nameTxt = GameObject.Find("name").GetComponent<TextMeshProUGUI>();
        ageTxt = GameObject.Find("age").GetComponent<TextMeshProUGUI>();
        favItemTxt = GameObject.Find("from").GetComponent<TextMeshProUGUI>();
        StartCoroutine(getDetails());
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
        sendToEatBtn.onClick.AddListener(this.sendToEat);
        sendToSleepBtn.onClick.AddListener( this.sendToSleep);
        sendToTrainBtn.onClick.AddListener( this.sendToTrain);
        closeBtn.onClick.AddListener(this.closePanel);
        nameTxt.text=name;
        ageTxt.text =age;
        favItemTxt.text =favItem;
        //set component
    }

    public void sendToEat(){
        print ("Sending "+this.gameObject.name +" to eat");
        GetComponent<WorkerMovement>().sendWorkerToEat();
    }

    public void sendToSleep(){
        print ("Sending "+this.gameObject.name +" to sleep");
        GetComponent<WorkerMovement>().sendWorkerToSleep();
    }
    public void sendToTrain(){
        print ("Sending "+this.gameObject.name +" to train");
        GetComponent<WorkerMovement>().sendWorkerToKnowelge();
    }

    IEnumerator getDetails(){
        WWW www = new WWW(URL);
        yield return www;
        string result = www.text;
        // print(result);
        string[] list = result.Split(',');
        name="Name - "+ list[0];
        age ="Age - "+  list[1];
        favItem="Favourite Item - "+  list[2];
    }


    public void closePanel(){
        GameObject.Find("worker details").SetActive(false);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TruckManager : MonoBehaviour
{
    bool timerActivate;
    int timeLeft;
    public GameObject truck;
    int numOfTrucks;
    // Start is called before the first frame update
    void Start()
    {
        timerActivate = false;
        timeLeft = 0;
        numOfTrucks =2+ Random.Range(4, 7);
        Debug.Log(numOfTrucks.ToString());
    }

    // Update is called once per frame
    void Update()
    {
        // if(numOfTrucks<0){
        //     // SceneManager.LoadScene(2);
        // }else
         if(timerActivate){
            timeLeft--;
            if(timeLeft<=0){
                // print("rest")
                Instantiate(truck, truck.transform.position, truck.transform.rotation);
                timerActivate= false;
            }
        }
    }

    public void startTimer(){
        timeLeft = Random.Range(10,50);
        timerActivate = true;
        numOfTrucks--;
    }

    
}

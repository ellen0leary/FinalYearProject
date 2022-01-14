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
        numOfTrucks = Random.Range(0, 6);
    }

    // Update is called once per frame
    void Update()
    {
        if(numOfTrucks<0){
            SceneManager.LoadScene(2);
        }else if(timerActivate){
            timeLeft--;
            if(timeLeft==0){
                // print("rest")
                Instantiate(truck, truck.transform.position, truck.transform.rotation);
            }
        }
    }

    public void startTimer(){
        timeLeft = Random.Range(10,200);
        timerActivate = true;
        numOfTrucks--;
    }
    // void OnTriggerEnter(Collider other) {
    //     if(other.gameObject.CompareTag("truck")){
    //         print("Stop truck");
    //     }
    // }

    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TruckManager : MonoBehaviour
{
    bool timerActivate;
    int timeLeft;
    public GameObject truck;
    // Start is called before the first frame update
    void Start()
    {
        timerActivate = false;
        timeLeft = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(timerActivate){
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
        print(timeLeft);
    }
    // void OnTriggerEnter(Collider other) {
    //     if(other.gameObject.CompareTag("truck")){
    //         print("Stop truck");
    //     }
    // }

    
}

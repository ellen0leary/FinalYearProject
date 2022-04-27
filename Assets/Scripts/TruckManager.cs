using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TruckManager : MonoBehaviour
{
    bool timerActivate;
    float timeLeft;
    public GameObject truck;
    public GameObject GOAPTruck;

    int numOfTrucks;
    float multipiler;
    // Start is called before the first frame update
    void Start()
    {
        timerActivate = false;
        timeLeft = 0;
        numOfTrucks =2+ Random.Range(4, 7);
        Debug.Log(numOfTrucks.ToString());
        multipiler = 1;
    }

    // Update is called once per frame
    void Update()
    {
         if(timerActivate){
            timeLeft-=( 1f * Time.deltaTime* multipiler);
            if(timeLeft<=0){

                GameObject g = Instantiate(truck, truck.transform.position, truck.transform.rotation);
                g.GetComponent<TruckMovement>().IncreseMultipler(multipiler);
                timerActivate= false;
            }
        }
    }

    public void startTimer(){
        timeLeft = Random.Range(1,3);
        timerActivate = true;
        numOfTrucks--;
    }

    public void spawnInGOAP(GameObject g){
        GameObject truck = Instantiate(GOAPTruck, GOAPTruck.transform.position, GOAPTruck.transform.rotation);
        truck.GetComponent<GOAPItem>().item = g;
    }

    public void changeMultipiler(float value){
        multipiler += 0.01f;
        if(multipiler>1.2f){
            multipiler =1.2f;
        }
        print(multipiler);
    }

    public void resetMultiplayiler(){
        multipiler = 1;
    }
}

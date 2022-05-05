using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OtherTruckController : MonoBehaviour
{
   bool timerActivate;
    float timeLeft;
    public GameObject truck;
    public GameObject GOAPTruck;

    int numOfTrucks;
    float multipiler;
    public bool ifAuto = false;
    // Start is called before the first frame update
    void Start()
    {
        timerActivate = true;
        timeLeft = 0;
        numOfTrucks =2+ Random.Range(4, 7);
        Debug.Log(numOfTrucks.ToString());
        multipiler = 1;
    }

    // Update is called once per frame
    void Update()
    {
         if(timerActivate){
            if(ifAuto) timeLeft-=( 1f * Time.deltaTime* multipiler);
            else timeLeft-=( 1f * Time.deltaTime);
            if(timeLeft<=0){
                print("spawning");
                GameObject g = Instantiate(truck, this.gameObject.transform.position, truck.transform.rotation);
                g.GetComponent<TruckMovement>().IncreseMultipler(multipiler);
                startTimer();
            }
        }
    }

    public void startTimer(){
        timeLeft = Random.Range(5,8);
        timerActivate = true;
        numOfTrucks--;
    }

    public void changeMultipiler(float value){
        multipiler += 0.01f;
        if(multipiler>1.2f){
            multipiler =1.2f;
        }
        print(multipiler);
    }

}

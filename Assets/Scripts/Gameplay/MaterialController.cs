using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialController : MonoBehaviour
{
    int currentScore = 100;
    int[] material = {0,1,2};
    int value = 1000;
    int curentIndex = 0;
    int[] currentProcess = {-1-1,-1};
    int extraActons = 0;
    // Start is called before the first frame update
    ScoreController sc;
    void Start()
    {
        GameObject gb = GameObject.FindGameObjectWithTag("score");
        sc = gb.GetComponent<ScoreController>();
    }
    // makegamegud plz()

    // Update is called once per frame
    void Update()
    {
        
    }

    public void materialFinished(int layer){
        //add to []
        // Debug.Log(layer);
        currentScore += 1000;
    }

    public void sell(){
        //calculate
        Debug.Log("selling for " + currentScore);
        sc.setScore(currentScore);
    }


    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.CompareTag("selling"))
        {
            Debug.Log(other.gameObject.tag);
            sell();
            Destroy(this.gameObject);
        }
    }


    /** 
    base class for materials - idk if i will use this
    **/
    public class Material {
        enum Order {
            NEW = 8,
            WASH,
            SORT,
            SHREAD,
            DONE
        }

        Order loc;
        int error;

        public Material(){
            error = 0;
            loc = Order.NEW;
        }
    }
}

//create base class with enum to track 

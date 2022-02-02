using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialController : MonoBehaviour
{
    int currentScore = 0;
    int[] material = {0,1,2};
    int value = 1000;
    int curentIndex = 0;
    int[] currentProcess = {-1-1,-1};
    int extraActons = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    // makegamegud plz()

    // Update is called once per frame
    void Update()
    {
        
    }

    public void materialFinished(int layer){
        //add to []
        Debug.Log(layer);
        
    }

    public void sell(){
        //calculate
    }




    /** 
    base class for materials
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

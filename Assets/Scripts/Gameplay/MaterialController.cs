using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialController : MonoBehaviour
{
    int currentScore = 100;
    int[] material = {9,10,11};
    int value = 1000;
    int curentIndex = 0;
    int[] currentProcess = {-1-1,-1};
    int extraActons = 0;
    // Start is called before the first frame update
    ScoreController sc;
    WorkerManager wm;
    IntelligentChecker checker;
    TruckManager tm;

    
    void Start()
    {
        wm = GameObject.Find("Workers").GetComponent<WorkerManager>();
        print("sending workers" + wm.gameObject.name);
        GameObject gb = GameObject.FindGameObjectWithTag("score");
        sc = gb.GetComponent<ScoreController>();
        checker = GameObject.Find("ScoreController").GetComponent<IntelligentChecker>();
        tm = GameObject.Find("Truck Manager").GetComponent<TruckManager>();
    }
    // makegamegud plz()

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool materialFinished(int layer){
        for (int x = 0; x<material.Length; x++){
            if (material[x] == layer){
                material[x] = -1;
                tm.changeMultipiler(0.1f);
                return true;
            }
        }
        checker.activateWrongPanel(nextItem());
        tm.resetMultiplayiler();
        return false;
    }

    public void sell(){
        //calculate
        Debug.Log("selling for " + currentScore);
        foreach (int i in material) {
            if( i !=-1){
                break;
            } else {
                break;
            }
         }
        sc.setScore(currentScore, true);
    }


    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.CompareTag("selling"))
        {
            foreach(int i in material){}
            Debug.Log(other.gameObject.tag);
            sell();
            Destroy(this.gameObject);
        }
    }
    public void upScore(){
        currentScore += 1000;
    }


    public void sendWorker(Vector3 startPos, Vector3 endPos)
    {
        // int index = wm.workers.Length;
        //get cloest worker thats workug
        wm = GameObject.Find("Workers").GetComponent<WorkerManager>();
        print("sending workers" + wm.gameObject.name);
        GameObject g = wm.getCloest(startPos);
        g.GetComponent<WorkerMovement>().sendToWork(startPos, endPos, this.gameObject);
    }

    string nextItem(){
         for (int x = 0; x<material.Length; x++){
            if (material[x] != -1){
                if(material[x] == 9) return "<color=\"red\">washer<color>";
                else if(material[x] == 10) return "<color=\"red\">sorter<color>";
                else if(material[x] == 11) return "<color=\"red\">shreder<color>";
            }
        }
        return "sell";
    }
}

//create base class with enum to track 

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
    void Start()
    {
        wm = GameObject.Find("Workers").GetComponent<WorkerManager>();
        print("sending workers" + wm.gameObject.name);
        GameObject gb = GameObject.FindGameObjectWithTag("score");
        sc = gb.GetComponent<ScoreController>();
    }
    // makegamegud plz()

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool materialFinished(int layer){
        //add to []
        // Debug.Log(layer);
        for (int x = 0; x<material.Length; x++){
            if (material[x] == layer){
                material[x] = -1;
                return true;
            }
        }
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
}

//create base class with enum to track 

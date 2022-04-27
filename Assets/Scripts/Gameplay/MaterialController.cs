using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MaterialController : MonoBehaviour
{
    int currentScore = 100;
    int[] material;// = {9,10,11};
    int value = 1000;
    int curentIndex = 0;
    int[] currentProcess = {-1-1,-1};
    int extraActons = 0;
    // Start is called before the first frame update
    ScoreController sc;
    WorkerManager wm;
    IntelligentChecker checker;
    TruckManager tm;
    bool ifMulti;
    
    
    void Start()
    {
        if(SceneManager.GetActiveScene().buildIndex ==4) ifMulti = true;
        else ifMulti = false;
        if(!ifMulti) wm = GameObject.Find("Workers").GetComponent<WorkerManager>();
        GameObject gb = GameObject.FindGameObjectWithTag("score");
        sc = gb.GetComponent<ScoreController>();
        checker = GameObject.Find("ScoreController").GetComponent<IntelligentChecker>();
        tm = GameObject.Find("Truck Manager").GetComponent<TruckManager>();
        if(this.gameObject.name.Contains("Plastic")){
            material = new int[]{9,10,11};
        } else if(this.gameObject.name.Contains("Tin")){
            material = new int[]{9,10};
        } else {
            material =new int[] {10, 11};
        }
        print(material.Length);
    }
    // makegamegud plz()

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool materialFinished(int layer){
        int pre = -1;
        for (int x = 0; x<material.Length; x++){
            if (material[x] == layer){
                if(pre== -1){
                    material[x] = -1;
                    tm.changeMultipiler(0.1f);
                    return true;
                } else break;
            }
            pre = material[x];
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
                checker.increseWrongProcess();
                sc.setScore(currentScore, true);
                break;
            }
         }
        sc.setScore(1000, true);
    }


    private void OnCollisionStay(Collision other) {
        if(other.gameObject.CompareTag("selling"))
        {
            Debug.Log(other.gameObject.tag);
            if(!ifMulti) sell();
            else sell(other.gameObject.layer);
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
                if(material[x] == 9) return "<color=#FF0062>washer";
                else if(material[x] == 10) return "<color=#FF5800>sorter";
                else if(material[x] == 11) return "<color=#E600FF>shreder";
            }
        }
        return "sell";
    }

    public void sell(int layer){
        //calculate
        
    }
}


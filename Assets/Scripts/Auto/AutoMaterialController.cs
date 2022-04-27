using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoMaterialController : MonoBehaviour
{

    int currentScore = 100;
    int[] material = { 9, 10, 11 };
    int value = 1000;
    int curentIndex = 0;
    int[] currentProcess = { -1 - 1, -1 };
    int extraActons = 0;
    // Start is called before the first frame update
    ScoreController sc;
    WorkerManager wm;
    Queue<Vector3> locations;
    TheQueue queueCon;
    IntelligentChecker checker;
    GameObject sellPoint;

    void Start()
    {
        sellPoint = GameObject.Find("Sell Area");
        wm = GameObject.Find("Workers").GetComponent<WorkerManager>();
        print("sending workers" + wm.gameObject.name);
        GameObject gb = GameObject.FindGameObjectWithTag("score");
        sc = gb.GetComponent<ScoreController>();
        queueCon = GameObject.Find("Workers").GetComponent<TheQueue>();
        queueCon.addToQueue(this.gameObject);
        checker = GameObject.Find("ScoreController").GetComponent<IntelligentChecker>();
        if(this.gameObject.name.Contains("Plastic")){
            material = new int[]{9,10,11};
        } else if(this.gameObject.name.Contains("Tin")){
            material = new int[]{9,10};
        } else {
            material =new int[] {10, 11};
        }
    }
    // makegamegud plz()

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool materialFinished(int layer)
    {
        //add to []
        // Debug.Log(layer);
        for (int x = 0; x < material.Length; x++)
        {
            if (material[x] == layer)
            {
                material[x] = -1;
                return true;
            }
        }
        // checker.activateWrongPanel();
        return false;
    }

    public void sell()
    {
        //calculate
        Debug.Log("selling for " + currentScore);
        foreach (int i in material)
        {
            if (i != -1)
            {
                break;
            }
            else
            {
                break;
            }
        }
        sc.setScore(currentScore, true);
    }


    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("selling"))
        {
            Debug.Log(other.gameObject.tag);
            this.gameObject.transform.parent.GetComponent<GOAP>().finMaterial();
            sell();
            Destroy(this.gameObject);
        } 
        else if(other.gameObject.tag=="worker"  && this.gameObject.transform.parent== null && other.gameObject.GetComponent<GOAP>().targetItem == this.gameObject){
            if(other.transform.childCount==3){
                if(material.Length == curentIndex){
                    this.gameObject.transform.parent = other.gameObject.transform;
                    GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;
                    other.gameObject.GetComponent<GOAP>().haveMaterial(sellPoint.transform.position);
                }
                GameObject g = findBuilding();
                if(g!= null){
                    this.gameObject.transform.parent = other.gameObject.transform;
                    other.gameObject.GetComponent<GOAP>().haveMaterial(g.transform.position);
                }
            } else {
                print("coll childCount is not 3");
                 other.gameObject.GetComponent<GOAP>().checkChild();
            }
        }
    }

    
    void upScore()
    {
        currentScore += 100;
    }



    public void sendWorker(Vector3 startPos, Vector3 endPos)
    {
        wm = GameObject.Find("Workers").GetComponent<WorkerManager>();
        GameObject g = wm.getCloest(this.transform.position);
        //get next building
        GameObject build = findBuilding();
        // g.GetComponent<WorkerMovement>().sendToWork(startPos, endPos, this.gameObject);
        //find cloest unactive one
        if(build!= null){
            //  g.GetComponent<WorkerMovement>().sendToWork(this.transform.position, build.transform.position, this.gameObject);
            endPos = build.transform.position;
        }else {
            // locations.Enqueue(startPos);
        }
        // g.GetComponent<WorkerMovement>().sendToWork(this.transform.position, endPos, this.gameObject);
    }
    //descirbe each feacture and what you have created
    // test and feedbaxcck even basic
        //decribe what feedback - takl aloud or remote or querstion
    //how stuff workers together

        //user manual
        //write section on how to use
        //how people will learn fro m game

    //reflective part

    //what learnied tech, time mangent hard or soft
    //what you found challenging and why
    //if you could do again what would you chage
    // i you had more timme, what would you add

    GameObject findBuilding(){
        print("finding building");
        GameObject[] buildings = GameObject.FindGameObjectsWithTag("building");
        foreach (GameObject x in buildings)
        {
            if (curentIndex < material.Length &&x.layer == material[curentIndex] && !x.GetComponent<AutoActiveBuilding>().isActive())
            {
                print("found building");
                return x;
            }
        }
        return null;
    }

    public void next(){
        upScore();
        curentIndex++;
        queueCon.addToQueue(this.gameObject);
        //add next location
        // sendWorker(this.transform.position, new Vector3(-1.02999997f, 0.589999974f, -4.63999987f));
    }
}

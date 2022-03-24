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

    void Start()
    {
        wm = GameObject.Find("Workers").GetComponent<WorkerManager>();
        print("sending workers" + wm.gameObject.name);
        GameObject gb = GameObject.FindGameObjectWithTag("score");
        sc = gb.GetComponent<ScoreController>();
        locations = new Queue<Vector3>();
        locations.Enqueue(this.transform.position);
        locations.Enqueue(findBuilding().transform.position);
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
            foreach (int i in material) { }
            Debug.Log(other.gameObject.tag);
            sell();
            Destroy(this.gameObject);
        } else if (other.gameObject.CompareTag("building")){
            //check layer
            //report back
            //start building
        } else if (other.gameObject.CompareTag("selling")){
            //sell obj
        }
    }
    void upScore()
    {
        currentScore += 1000;
    }



    public void sendWorker(Vector3 startPos, Vector3 endPos)
    {
        print("sending worker");
        //get cloest worker thats workug
        wm = GameObject.Find("Workers").GetComponent<WorkerManager>();
        GameObject g = wm.getCloest(this.transform.position);
        //get next building
        GameObject build = findBuilding();
        // g.GetComponent<WorkerMovement>().sendToWork(startPos, endPos, this.gameObject);
        //find cloest unactive one
        if(build!= null){
            print("going to building");
             g.GetComponent<WorkerMovement>().sendToWork(this.transform.position, build.transform.position, this.gameObject);
        }else {
            // locations.Enqueue(startPos);
        }
    }

    GameObject findBuilding(){
        print("finding building");
        GameObject[] buildings = GameObject.FindGameObjectsWithTag("building");
        foreach (GameObject x in buildings)
        {
            if (x.layer == material[curentIndex] && !x.GetComponent<AutoActiveBuilding>().isActive())
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
        //add next location
        sendWorker(this.transform.position, new Vector3(0f,0f,0f));
    }

    public void getNextLocation(){
        //get next in queue
    }
}

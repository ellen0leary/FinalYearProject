using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WorkerManager : MonoBehaviour
{
    public GameObject woker;
    public WorkerMovement[] workers;
    ScoreController sc;

    // Start is called before the first frame update
    void Start()
    {
        GameObject go = GameObject.Find("ScoreController");
        sc = go.GetComponent<ScoreController>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void sendWorker(Vector3 startPos, Vector3 endPos, GameObject material){
        GameObject g = workers[0].gameObject;
        float shortestPos =200000000f;
        foreach(WorkerMovement i in workers){
            if(Vector3.Distance(startPos,i.gameObject.transform.position)<shortestPos){
                shortestPos = Vector3.Distance(startPos,i.gameObject.transform.position);
                g =i.gameObject;
            }
        }
        print(g.name);
        g.GetComponent<WorkerMovement>().sendToWork(startPos, endPos, material);
    }

    // public void addWorker(){
    //     if(sc.setScore(-500, false)){
    //     //create temp array
    //     int lastIndex = workers.Length;
    //     WorkerMovement[] temp = new WorkerMovement[lastIndex + 1];
    //     //replace current array
    //     workers = temp;
    //     //add worker
    //     GameObject newWorker = Instantiate(woker, new Vector3(-0.0384554863f, 0.109999992f, -0.737234116f),woker.transform.rotation);
    //     workers[lastIndex] = newWorker.GetComponent<WorkerMovement>();
    //     }
    // }

    public void IncreaseEat(){
        int num = 4;
        while(num >=0){
            int index = Random.Range(0, workers.Length - 1);
            print(index);
            workers[index].gameObject.GetComponent<WorkerMovement>().sendWorkerToEat();
            num--;
        }
    }

    public void IncreaseSleep()
    {
        int num = 4;
        while (num >= 0)
        {
            int index = Random.Range(0, workers.Length - 1);
            print(index);
            workers[index].gameObject.GetComponent<WorkerMovement>().sendWorkerToSleep();
            num--;
        }
    }

    public void IncreaseKnowledge()
    {
        int num = 4;
        while (num >= 0)
        {
            int index = Random.Range(0, workers.Length - 1);
            print(index);
            workers[index].gameObject.GetComponent<WorkerMovement>().sendWorkerToKnowelge();
            num--;
        }
    }

    public void addWorker(Vector3 pos){
        // if(sc.setScore(-500, false)){
        //create temp array
        print(pos.ToString());
        int lastIndex = workers.Length;
        WorkerMovement[] temp = new WorkerMovement[lastIndex + 1];
        //replace current array
        workers = temp;
        //add worker
        GameObject newWorker = Instantiate(woker, pos,woker.transform.rotation);
        workers[lastIndex] = newWorker.GetComponent<WorkerMovement>();
        // }
    }
}

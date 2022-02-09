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

    public void sendWorker(){
        int index = Random.Range(0, workers.Length-1);
        workers[index].sendToTruck();
    }

    public void addWorker(){
        if(sc.setScore(-500)){
        //create temp array
        int lastIndex = workers.Length;
        WorkerMovement[] temp = new WorkerMovement[lastIndex + 1];
        //replace current array
        workers = temp;
        //add worker
        GameObject newWorker = Instantiate(woker, new Vector3(-0.0384554863f, 0.109999992f, -0.737234116f),woker.transform.rotation);
        workers[lastIndex] = newWorker.GetComponent<WorkerMovement>();
        }
    }

    public void IncreaseEat(){
        foreach(WorkerMovement i in workers){
            i.gameObject.GetComponent<WorkerFeelings>().IncreaseEat(70);
        }
    }

    public void IncreaseSleep()
    {
        foreach (WorkerMovement i in workers)
        {
            i.gameObject.GetComponent<WorkerFeelings>().IncreaseSleep(70);
        }
    }

    public void IncreaseKnowledge()
    {
        foreach (WorkerMovement i in workers)
        {
            i.gameObject.GetComponent<WorkerFeelings>().IncreaseKnowledge(70);
        }
    }
}

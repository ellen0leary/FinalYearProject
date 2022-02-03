using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WorkerManager : MonoBehaviour
{
    public GameObject woker;
    public WorkerMovement[] workers;

    // Start is called before the first frame update
    void Start()
    {

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
        //to do - add worker
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

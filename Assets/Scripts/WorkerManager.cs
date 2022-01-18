using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WorkerManager : MonoBehaviour
{
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
}

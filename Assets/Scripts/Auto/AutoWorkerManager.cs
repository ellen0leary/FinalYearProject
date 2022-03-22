using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoWorkerManager : MonoBehaviour
{
    //gets all worker
    WorkerManager wm;
    //finds closests worker with active work
    //send worker to the item
    //when item is freeded from building send to next step
    // Start is called before the first frame update
    void Start()
    {
        wm = this.gameObject.GetComponent<WorkerManager>();
        if(wm == null){
            print("not here");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // public void sendWorker(Vector3 startPos, Vector3 endPos, GameObject material){
    //     // int index = wm.workers.Length;
    //     //get cloest worker thats workug
    //     GameObject g = wm.getCloest(startPos);
    //     g.GetComponent<WorkerMovement>().sendToWork(startPos, endPos, material);
    // }
}

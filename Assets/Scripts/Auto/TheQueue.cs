using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheQueue : MonoBehaviour
{
    public Queue<GameObject> jobs = new Queue<GameObject>();
    public Queue<Vector3> locs;
    // Start is called before the first frame update
    void Start()
    {
        // jobs = new Queue<GameObject>();
        locs = new Queue<Vector3>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void addToQueue(GameObject g){
        print(jobs.Count);
        jobs.Enqueue(g);
        print(jobs.Count);
    }


    public GameObject getJob(){
        if(jobs.Count>0){
            print(jobs.Count);
            return jobs.Dequeue();
        }
        return null;
    }

    // public void addToQueueLoc(Vector3 g){
    //     locs.Enqueue(g);
    //     print(jobs.Count);
    // }


    // public Vector3 getJobLoc(){
    //     if(locs.Count>0){
    //         return locs.Dequeue();
    //     }
    //     return new Vector3();
    // }
}

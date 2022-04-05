using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheQueue : MonoBehaviour
{
    public Queue<GameObject> jobs;
    // Start is called before the first frame update
    void Start()
    {
        jobs = new Queue<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void addToQueue(GameObject g){
        jobs.Enqueue(g);
        print(jobs.Count);
    }


    public GameObject getJob(){
        return jobs.Dequeue();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheQueue : MonoBehaviour
{
    public Queue<GameObject> jobs = new Queue<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
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
            return jobs.Dequeue();
        }
        return null;
    }
}

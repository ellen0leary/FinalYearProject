using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShoppingManager : MonoBehaviour
{
    WorkerManager wk;
    BuildingManager bld;
    // Start is called before the first frame update
    void Start()
    {
        GameObject workers =GameObject.Find("Workers"); 
        wk = workers.GetComponent<WorkerManager>();
        GameObject buildings = GameObject.Find("Buildings");
        bld = buildings.GetComponent<BuildingManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addWorker(){
        // wk.addWorker();
    }

    public void addBuilding(){
        bld.createBuilding();
    }
}

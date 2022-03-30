using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShoppingManager : MonoBehaviour
{
    WorkerManager wk;
    BuildingManager bld;
    GameObject buildingScreen;
    bool isActive = true;
    // Start is called before the first frame update
    void Start()
    {
        GameObject workers =GameObject.Find("Workers"); 
        wk = workers.GetComponent<WorkerManager>();
        GameObject buildings = GameObject.Find("Buildings");
        bld = buildings.GetComponent<BuildingManager>();
        buildingScreen = GameObject.Find("BuildingPanel");
        buildingScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addWorker(){
        // wk.addWorker();
    }

    public void addBuilding(){
        // bld.createBuilding();
        buildingScreen.SetActive(isActive);
        isActive = !isActive;
    }

    public void buyShredder(){
        print("buying shredder");
        bld.createBuild(2);
    }

    public void buySorter(){
        bld.createBuild(1);
    }

    public void buyWasher(){
        bld.createBuild(0);
    }
}

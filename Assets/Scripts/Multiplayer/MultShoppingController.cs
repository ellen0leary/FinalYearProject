using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultShoppingController : MonoBehaviour
{
    WorkerManager wk;
    public BuildingManager bld;
    // Start is called before the first frame update
    void Start()
    {
        // wk = GameObject.Find("Workers").GetComponent<WorkerManager>();
        bld = GameObject.Find("Buildings").GetComponent<BuildingManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addBuildingP1(){
        print("creating a building for player 1");
        bld.createBuilding(new Vector3(1, 0.119999997f, -0.5f));
    }

    public void addBuildingP2(){
        print("creating a building for player 2");
        bld.createBuilding(new Vector3(2, 0.119999997f, -23));
    }
}

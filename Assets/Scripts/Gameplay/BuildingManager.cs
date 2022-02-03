using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingManager : MonoBehaviour
{
    public GameObject[] allBuildings;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void createBuilding(){
        int index = Random.Range(0, allBuildings.Length - 1);
        float xValiue = Random.Range(-5,5);
        float yValiue = Random.Range(-5, 5);
        GameObject gOb =Instantiate(allBuildings[index],new Vector3(-0.0384554863f+xValiue, 0.109999992f, -0.737234116f-yValiue) ,allBuildings[index].transform.rotation);

    }
}

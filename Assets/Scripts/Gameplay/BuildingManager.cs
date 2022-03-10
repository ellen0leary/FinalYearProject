using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingManager : MonoBehaviour
{
    public GameObject[] allBuildings;
    ScoreController sc;
    // Start is called before the first frame update
    void Start()
    {
        GameObject go = GameObject.Find("ScoreController");
        sc = go.GetComponent<ScoreController>();

    }

    public void createBuilding(){
        if(sc.setScore(-1000, false)){
            int index = Random.Range(0, allBuildings.Length - 1);
            float xValiue = Random.Range(-5,5);
            float yValiue = Random.Range(-5, 5);
            GameObject gOb =Instantiate(allBuildings[index],new Vector3(-0.0384554863f+xValiue, 0.109999992f, -0.737234116f-yValiue) ,allBuildings[index].transform.rotation);
        }

    }


    public void createBuilding(Vector3 pos)
    {
        // if (sc.setScore(-1000, false))
        // {
            int index = Random.Range(0, allBuildings.Length - 1);
            float xValiue = Random.Range(-5, 5);
            float yValiue = Random.Range(-5, 5);
            Vector3 newPos = pos - new Vector3(xValiue, 0 , yValiue);
            GameObject gOb = Instantiate(allBuildings[index], newPos, allBuildings[index].transform.rotation);
        // }

    }
}

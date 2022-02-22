using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkerClick : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject wdScreen;
    void Start()
    {
        wdScreen = GameObject.Find("worker details");
        wdScreen.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)){
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
           
            if (Physics.Raycast(ray, out hit))
            {
                print(hit.transform.tag.ToString());
                if (hit.transform.tag == "worker"){ 
                    wdScreen.SetActive(true);
                    hit.transform.gameObject.GetComponent<WorkerDisplay>().setDeatils();
                    }
                else wdScreen.SetActive(false);
            }
            
        }
        
    }
}

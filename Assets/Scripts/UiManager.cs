using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{

    public GameObject truck;
    TruckMovement script;
    public GameObject material1Heading;
    public GameObject material2Heading;
    // Start is called before the first frame update
    void Start()
    {
        script = truck.GetComponent<TruckMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetMaterialOne(string name){
        TextMeshProUGUI title = material1Heading.GetComponent<TextMeshProUGUI>();
        title.text = name;
    }
    public void SetMaterialTwo(string name){
        TextMeshProUGUI title = material2Heading.GetComponent<TextMeshProUGUI>();
        title.text = name;
    }
    public void sendWorker(){
        print("Sending worker to get ......");
        script.closeScreen();
        
    }

    public void sendWorkerCardboard()
    {
        print("Sending worker to get cardboard");
        script.closeScreen();
    }

    public void sendWorkerTin()
    {
        print("Sending worker to get tin");
        script.closeScreen();
    }
}

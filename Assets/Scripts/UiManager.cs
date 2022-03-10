using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{

    // public GameObject truck;
    public GameObject helpScreen;
    TruckMovement script;
    public GameObject material1Heading;
    public GameObject material2Heading;
    // Start is called before the first frame update
    void Start()
    {
        // helpScreen.SetActive(false);
        
        
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
        // GameObject truck = GameObject.Find("Truck");
        // script = truck.GetComponent<TruckMovement>();
        script = GameObject.FindObjectOfType<TruckMovement>();
        script.closeScreen();
        
    }

    public void sendWorkerCardboard()
    {
        script.closeScreen();
    }

    public void sendWorkerTin()
    {
        script.closeScreen();
    }

    public void clickHelp(){
        helpScreen.SetActive(true);
    }

    public void closeHelp(){
        helpScreen.SetActive(false);
    }
}

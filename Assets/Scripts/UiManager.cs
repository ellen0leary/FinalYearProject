using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiManager : MonoBehaviour
{

    public GameObject truck;
    TruckMovement script;
    // Start is called before the first frame update
    void Start()
    {
        script = truck.GetComponent<TruckMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void sendWorkerPlastic(){
        print("Sending worker to get plastic");
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

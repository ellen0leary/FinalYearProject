using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TruckMovement : MonoBehaviour
{

    bool stop = false;
    public GameObject uiScreen;
    public GameObject mainUIScreen;
    TruckManager manager;
    // Start is called before the first frame update
    private WorkerManager workerManager;
    void Start()
    {
        workerManager = FindObjectOfType<WorkerManager>();
        manager = FindObjectOfType<TruckManager>();
        uiScreen = GameObject.Find("Canvas").transform.Find("Sorting Panel").gameObject;
        // uiScreen = mainUIScreen.Find;
        uiScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(!stop){
            this.transform.Translate (Vector3.forward * 1 * Time.deltaTime);
        }
       
        if(transform.position.z >5){
            manager.startTimer();
            Destroy(this.gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Stopping Area"))
        {
            stop = true;
            uiScreen.SetActive(true);
        }
    }

    public void closeScreen(){
        uiScreen.SetActive(false);
        workerManager.sendWorker();
        stop = false;
    }
}

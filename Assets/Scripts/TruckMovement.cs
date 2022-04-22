using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TruckMovement : MonoBehaviour
{

    bool stop = false;
    public GameObject uiScreen;
    TruckManager manager;
    // Start is called before the first frame update
    private WorkerManager workerManager;
    public bool ifGOAP;
    void Start()
    {
        workerManager = FindObjectOfType<WorkerManager>();
        manager = FindObjectOfType<TruckManager>();

        // uiScreen = GameObject.Find("Canvas").transform.Find("Sorting Panel").gameObject;
        // uiScreen = mainUIScreen.Find;
        // uiScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(!stop){
            this.transform.Translate (Vector3.forward * 1.5f * Time.deltaTime);
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
            // uiScreen.SetActive(true);
            if (!ifGOAP )gameObject.GetComponent<AutoTruckMaterial>().setMaterial();
            else gameObject.GetComponent<GOAPItem>().spawnItem();
            // workerManager.sendWorker();
            stop = false;
        }
    }

    public void closeScreen(){
        uiScreen.SetActive(false);
        // workerManager.sendWorker()s;
        stop = false;
    }
}

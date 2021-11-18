using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TruckMovement : MonoBehaviour
{

    bool stop = false;
    public GameObject uiScreen;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!stop){
            this.transform.Translate (Vector3.forward * 1 * Time.deltaTime);
        }

        if(transform.position.z >5){
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
        stop = false;
    }
}

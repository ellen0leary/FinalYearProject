using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveBuilding : MonoBehaviour
{
    bool ifActive = false;
    //for change the size of the building
    float changeValue = 0.15f;
    float maxTime = 50;
    float timer;
    bool whichDir = false;

    // for dealing with the material
    float maxMaterialTimer = 500;
    float materialTimer;
    // Start is called before the first frame update
    public GameObject material;
    public GameObject scoreController;
    void Start()
    {
        timer = maxTime;
        materialTimer = maxMaterialTimer;
        scoreController = GameObject.FindGameObjectWithTag("score");
    }

    // Update is called once per frame
    void Update()
    {
        if(ifActive){
            if(whichDir){
                transform.localScale += new Vector3(1, 1, 1) * Time.deltaTime* changeValue;
                timer--;
            } else {
                transform.localScale -= new Vector3(1, 1, 1) * Time.deltaTime* changeValue; 
                timer--; 
            }
            materialTimer--;
            if(timer<=0){
                if (materialTimer <= 0 && whichDir)
                {
                    material.SetActive(true);
                    material.transform.position =  new Vector3(transform.position.x + 1, transform.position.y, transform.position.z + 1);
                    ifActive = false;
                    int thisLayer = (int) this.gameObject.layer;
                    material.GetComponent<MaterialController>().materialFinished(this.gameObject.layer);
                    // Debug.Log((int)this.gameObject.layer);
                }
                timer = maxTime;
                whichDir = !whichDir;
            }
            
        }

    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("material") && !ifActive)
        {
            ifActive = true;
            other.gameObject.SetActive(false);
            material = other.gameObject;
        }
    }
}


// get material contriller
// send layer to materialcontriller once done
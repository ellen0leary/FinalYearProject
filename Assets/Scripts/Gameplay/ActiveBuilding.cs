using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveBuilding : MonoBehaviour
{
    bool ifActive = false;
    //for change the size of the building
    float changeValue = 0.1f;
    float maxTime = 50;
    float timer;
    bool whichDir = false;

    // for dealing with the material
    float maxMaterialTimer = 500;
    float materialTimer;
    // Start is called before the first frame update
    public GameObject material;
    void Start()
    {
        timer = maxTime;
        materialTimer = maxMaterialTimer;
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
                    //instaite object
                    Instantiate(material, new Vector3(transform.position.x+1, transform.position.y, transform.position.z+1), Quaternion.identity);
                    ifActive = false;

                }
                timer = maxTime;
                whichDir = !whichDir;
            }
            
        }

    }

    public void StartMaterial(){
        ifActive = true;
    }
}

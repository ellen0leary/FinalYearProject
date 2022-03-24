using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoActiveBuilding : MonoBehaviour
{
    bool ifActive = false;
    //for change the size of the building
    float changeValue = 0.15f;
    float maxTime = 40;
    float timer;
    bool whichDir = false;

    // for dealing with the material
    float maxMaterialTimer = 100;
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
        if (ifActive)
        {
            if (whichDir)
            {
                transform.localScale += new Vector3(1, 1, 1) * Time.deltaTime * changeValue;
                timer--;
            }
            else
            {
                transform.localScale -= new Vector3(1, 1, 1) * Time.deltaTime * changeValue;
                timer--;
            }
            materialTimer--;
            if (timer <= 0)
            {
                if (materialTimer <= 0 && whichDir)
                {
                    material.SetActive(true);
                    material.transform.position = new Vector3(transform.position.x + 1, transform.position.y, transform.position.z + 1);
                    ifActive = false;
                    int thisLayer = (int)this.gameObject.layer;
                    // material.GetComponent<MaterialController>().upScore();
                    material.GetComponent<AutoMaterialController>().next();
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
            if (other.gameObject.GetComponent<AutoMaterialController>().materialFinished(this.gameObject.layer))
            {
                other.gameObject.transform.parent.gameObject.GetComponent<WorkerMovement>().setIsBusy();
                print("here");
                ifActive = true;
                timer = maxTime;
                materialTimer = maxMaterialTimer;
                other.gameObject.SetActive(false);
                other.gameObject.transform.parent = null;
                material = other.gameObject;
            }
            else
            {
                // other.gameObject.transform.position = new Vector3(transform.position.x + 1, transform.position.y + 0.5f, transform.position.z + 1);
                //nothing happens
            }
        }
    }

    public bool isActive()
    {
        return ifActive;
    }
}


// get material contriller
// send layer to materialcontriller once done
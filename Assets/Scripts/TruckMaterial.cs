using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;



public class TruckMaterial : MonoBehaviour
{
    //eventually import data from db
    //now hardcoded
    public Button btn;
    
    public UiManager uiManager;
    TextMeshProUGUI title;
    

    string[] materials = {"Plastic", "Cardboard", "Tin"};
    public GameObject[] mats;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void setMaterial(){
        uiManager = FindObjectOfType<UiManager>();
        int randInt1 = Random.Range(0, mats.Length);
        int randInt2 = Random.Range(0, materials.Length);
        
        
        
        // string materialName = materialNames[randInt1];
        // uiManager.SetMaterialOne(mats[randInt1]);
        // uiManager.SetMaterialTwo(materials[randInt2]);
        GameObject go = mats[randInt1];
        go.tag = "material";
        Instantiate(go, new Vector3(transform.position.x+1, transform.position.y+1,transform.position.z), go.transform.rotation);
        GameObject.Find("Workers").GetComponent<AutoWorkerManager>().sendWorker(this.transform.position,this.transform.position*1.5f, this.gameObject );
        // TextMeshPro buttonText = uiElement.GetComponentInChildren<Button>().GetComponentInChildren<TextMeshPro>();

    }
}

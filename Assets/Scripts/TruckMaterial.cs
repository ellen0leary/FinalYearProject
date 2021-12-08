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
        int randInt1 = Random.Range(0, materials.Length);
        int randInt2 = Random.Range(0, materials.Length);
        
        
        
        // string materialName = materialNames[randInt1];
        uiManager.SetMaterialOne(materials[randInt1]);
        uiManager.SetMaterialTwo(materials[randInt2]);
        
        // TextMeshPro buttonText = uiElement.GetComponentInChildren<Button>().GetComponentInChildren<TextMeshPro>();

    }
}

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
    public GameObject uiElement;
    public GameObject material1;
    public GameObject material2;
    public GameObject heading;
    public GameObject buttonText;

    TextMeshProUGUI title;
    

    string[] materials = {"Plastic", "Cardboard", "Tin"};
    // Start is called before the first frame update
    void Start()
    {
        material1 = GameObject.Find("Material1");
        material2 = GameObject.Find("Material2");
         title = heading.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void setMaterial(){
        int randInt1 = Random.Range(0, materials.Length);
        int randInt2 = Random.Range(0, materials.Length);
        
        
        
        // string materialName = materialNames[randInt1];
        title.text =materials[randInt1];
        // TextMeshPro buttonText = uiElement.GetComponentInChildren<Button>().GetComponentInChildren<TextMeshPro>();

    }
}

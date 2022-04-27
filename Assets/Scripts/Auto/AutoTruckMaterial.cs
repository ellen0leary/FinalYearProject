using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;



public class AutoTruckMaterial : MonoBehaviour
{
    //eventually import data from db
    //now hardcoded
    public Button btn;

    public UiManager uiManager;
    TextMeshProUGUI title;


    string[] materials = { "Plastic", "Cardboard", "Tin" };
    public GameObject[] mats;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    public void setMaterial()
    {
        uiManager = FindObjectOfType<UiManager>();
        int randInt1 = Random.Range(0, mats.Length);
        int randInt2 = Random.Range(0, materials.Length);
        GameObject go = mats[randInt1];
        print(go.name);
        go.tag = "material";
        print("creating material");    
        float randX = Random.Range(-0.5f, 0.5f);
        float randY = Random.Range(-0.5f, 0.5f);
        Vector3 pos = new Vector3(transform.position.x + 1, transform.position.y + 1, transform.position.z);
        GameObject g = Instantiate(go, pos, go.transform.rotation);
        // GetComponent<
        // g.GetComponent<AutoMaterialController>().sendWorker(pos, new Vector3(6.42000008f, -0.160999998f, 5.10999966f));
        // TextMeshPro buttonText = uiElement.GetComponentInChildren<Button>().GetComponentInChildren<TextMeshPro>();

    }
}

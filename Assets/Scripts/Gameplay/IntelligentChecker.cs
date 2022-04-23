using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class IntelligentChecker : MonoBehaviour
{
    string[] tips = {"Plastic should be washed, sorted and shreeded",
    "Tins should be cleaned and sorted", "Cardboard should be sorted the shreeded"};
    GameObject tipPanel;
    public TextMeshProUGUI tipText;
    // Start is called before the first frame update
    void Start()
    {
        tipPanel = GameObject.Find("Tip Panel");
        tipText = GameObject.Find("Tip Text").GetComponent<TextMeshProUGUI>();
        tipPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ActivatePanel(string matName){
        tipPanel.SetActive(true);
        if(matName.Contains("Plastic")) tipText.text = tips[0];
        else if (matName.Contains("Tin")) tipText.text = tips[1];
        else tipText.text = tips[2];
    }
}

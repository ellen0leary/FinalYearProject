using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class IntelligentChecker : MonoBehaviour
{
    //fir the tips
    string[] tips = {"Plastic should be washed, sorted and shreeded",
    "Tins should be cleaned and sorted", "Cardboard should be sorted the shreeded"};
    GameObject tipPanel;
    public TextMeshProUGUI tipText;

    //worng enter
    GameObject wrongPanel;
    public TextMeshProUGUI worngText;
    bool isWrongPanelActive; 
    float maxTimer = 5;
    public float currentTimer;
    // Start is called before the first frame update
    void Start()
    {
        tipPanel = GameObject.Find("Tip Panel");
        tipText = GameObject.Find("Tip Text").GetComponent<TextMeshProUGUI>();
        tipPanel.SetActive(false);

        worngText = GameObject.Find("WrongText").GetComponent<TextMeshProUGUI>();
        wrongPanel = GameObject.Find("Worng Panel");
        wrongPanel.SetActive(false);
        isWrongPanelActive = false;
        currentTimer = maxTimer;
    }

    // Update is called once per frame
    void Update()
    {
        if(isWrongPanelActive){
            currentTimer -= (1*Time.deltaTime);
            if(currentTimer <=0){
                isWrongPanelActive = false;
                wrongPanel.SetActive(false);
                currentTimer = maxTimer;
            }
        }
    }

    public void activateTipPanel(string matName){
        tipPanel.SetActive(true);
        if(matName.Contains("Plastic")) tipText.text = tips[0];
        else if (matName.Contains("Tin")) tipText.text = tips[1];
        else tipText.text = tips[2];
    }

    public void closeTipPanel(){
        tipPanel.SetActive(false);
    }

    public void activateWrongPanel(string nextBuild){
        // print("activating wrong panel");
        wrongPanel.SetActive(true);
        worngText.text = "This needs to go to " + nextBuild;
        isWrongPanelActive = true;
    }
}

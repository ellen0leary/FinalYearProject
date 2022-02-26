using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class WorkerDisplay : MonoBehaviour
{
    WorkerFeelings wf;
    bool ifActive = false;
    // Start is called before the first frame update
    void Start()
    {
        wf = GetComponent<WorkerFeelings>();
    }

    // Update is called once per frame
    void Update()
    {
        // if(gameObject.activeInHierarchy){
        if (ifActive)
        {
            GameObject.Find("knowledge").GetComponent<TextMeshProUGUI>().text = "knowledge skill " + (int)wf.knowledge;
            GameObject.Find("eat skill").GetComponent<TextMeshProUGUI>().text = "eat need  " + (int)wf.eatNeed;
            GameObject.Find("sleep skill").GetComponent<TextMeshProUGUI>().text = "knowledge skill " + (int)wf.sleepNeed;
        }
    }

    public void setDeatils(){
        //get components
        GameObject.Find("knowledge").GetComponent<TextMeshProUGUI>().text = "knowledge skill " + (int) wf.knowledge;
        GameObject.Find("eat skill").GetComponent<TextMeshProUGUI>().text = "eat need  " + (int) wf.eatNeed;
        GameObject.Find("sleep skill").GetComponent<TextMeshProUGUI>().text = "knowledge skill " + (int) wf.sleepNeed;
        ifActive = true;
        //set component
    }
}

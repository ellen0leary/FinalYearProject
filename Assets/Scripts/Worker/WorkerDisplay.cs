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
            GameObject.Find("knowledge").GetComponent<TextMeshProUGUI>().text = wf.knowledge.ToString();
            GameObject.Find("eat skill").GetComponent<TextMeshProUGUI>().text = wf.eatNeed.ToString();
            GameObject.Find("sleep skill").GetComponent<TextMeshProUGUI>().text = wf.sleepNeed.ToString();
        }
    }

    public void setDeatils(){
        //get components
        GameObject.Find("knowledge").GetComponent<TextMeshProUGUI>().text = wf.knowledge.ToString();
        GameObject.Find("eat skill").GetComponent<TextMeshProUGUI>().text = wf.eatNeed.ToString();
        GameObject.Find("sleep skill").GetComponent<TextMeshProUGUI>().text = wf.sleepNeed.ToString();
        ifActive = true;
        //set component
    }
}

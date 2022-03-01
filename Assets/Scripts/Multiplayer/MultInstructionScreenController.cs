using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultInstructionScreenController : MonoBehaviour
{
    bool ifOneReady;
    void Start()
    {
        ifOneReady = false;
        Time.timeScale = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void startGame()
    {
        if(ifOneReady){
            this.gameObject.SetActive(false);
            Time.timeScale = 1;
        } else {
            ifOneReady = true;
        }
    }

    public void OpenScreen()
    {
        this.gameObject.SetActive(true);
        Time.timeScale = 0;
    }
}

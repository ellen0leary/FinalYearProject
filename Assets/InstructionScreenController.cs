using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstructionScreenController : MonoBehaviour
{
    // Start is called before the first frame update

    void Start()
    {
        Time.timeScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void startGame(){
        this.gameObject.SetActive(false);
        Time.timeScale = 1;
    }

    public  void OpenScreen(){
        this.gameObject.SetActive(true);
        Time.timeScale = 0;
    }
}

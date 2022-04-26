using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class LevelSelection : MonoBehaviour
{
    public Toggle toggle;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void levelSelect(string level){
        PlayerPrefs.SetString("level", level);
        if(toggle.isOn){
            SceneManager.LoadScene("Wroking");
        } else {
            SceneManager.LoadScene("MainGame");
        }
    }
    public void grassyLevel(){
        levelSelect("grassy");
    }

    public void forestLevel(){
        levelSelect("forest");
    }

    public void snowlyLevel(){
        
    }

    public void closePanel(){
        this.gameObject.SetActive(false);
    }
}

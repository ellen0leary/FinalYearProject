using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuContriller : MonoBehaviour
{

    public GameObject popUpScreen;

    void Start() {
        popUpScreen.SetActive(false);
    }
    public void startSinglePlayer(){
        SceneManager.LoadScene("MainGame");
    }

    public void startOnline(){

    }

    public void startLearn(){

    }

    public void startOptions(){

    }

    public void exitGame(){
        Application.Quit();
    }

    public void featureUnavabile(){
        popUpScreen.SetActive(true);
    }

    public void closePopup(){
        popUpScreen.SetActive(false);
    }
}

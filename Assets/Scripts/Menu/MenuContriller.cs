using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuContriller : MonoBehaviour
{


    public GameObject popUpScreen;
    public GameObject optionsMenu, levelSelectionPanel;

    void Start() {
        popUpScreen.SetActive(false);
         levelSelectionPanel.SetActive(false);
        optionsMenu = GameObject.Find("Options");
        optionsMenu.SetActive(false);
    }
    public void startSinglePlayer(){
        // SceneManager.LoadScene("MainGame");
        levelSelectionPanel.SetActive(true);
    }

    public void startOnline(){
        SceneManager.LoadScene("LocalMultiplayer");
    }

    public void startLearn(){
        SceneManager.LoadScene("Quiz");
    }

    public void startOptions(){
        optionsMenu.SetActive(true);
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

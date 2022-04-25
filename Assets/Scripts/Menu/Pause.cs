using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Pause : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.SetActive(false);
    }

    public void openPanel(){
        this.gameObject.SetActive(true);
        Time.timeScale = 0;
    }

    public void resume(){
        this.gameObject.SetActive(false);
        Time.timeScale = 1;
    }

    public void restart(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void mainMenu(){
        SceneManager.LoadScene("Menu");
    }
}

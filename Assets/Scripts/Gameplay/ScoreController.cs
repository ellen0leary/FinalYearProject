using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ScoreController : MonoBehaviour
{
    int startingScore = 5000;
    int currentScore;
    public TextMeshProUGUI scoreText;
    GameObject scorePanel;
    TextMeshProUGUI timerTxt;

    float mainTimer = 1000f;
    // Start is called before the first frame update
    void Start()
    {
        currentScore = startingScore;
        setScoreText();
        scorePanel = GameObject.Find("Score Panel");
        scorePanel.SetActive(false);
        timerTxt = GameObject.Find("Timer Text").GetComponent<TextMeshProUGUI>();
    }

    void Update(){
        mainTimer-= 1*Time.deltaTime;
        if(mainTimer<= 0){
            gameOverScreen();
        }else timerTxt.text = "Timer Remaining : " + Mathf.FloorToInt(mainTimer % 60);
    }

    // Update is called once per frame
    public bool setScore(int addition){
        if(currentScore + addition>=0) {
            currentScore+=addition;
            print(currentScore);
            setScoreText();
            return true;
        }
        else return false;
    }



    void setScoreText(){
        scoreText.text = "Money - €" + currentScore.ToString();
    }
    void gameOverScreen(){
        string text = "";
        if(mainTimer<=0){
            text = "You Lost....";
        } else {
            text = "You Won!";
        }
        scorePanel.SetActive(true);
        GameObject.Find("FinalTextScore").GetComponent<TextMeshProUGUI>().text = text;
        //set final score
        GameObject.Find("FinalScoreScore").GetComponent<TextMeshProUGUI>().text = "Final Score is "+ currentScore.ToString();
    }

    public void goToMainMenu(){
        SceneManager.LoadScene("Menu");
    }

    void goToReplay(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void goToQuiz(){
        SceneManager.LoadScene("Quiz");
    }
}

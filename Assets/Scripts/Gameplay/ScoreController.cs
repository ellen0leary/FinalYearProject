using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    int startingScore = 5000;
    int currentScore;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI countText;
    GameObject scorePanel;
    TextMeshProUGUI timerTxt;
    public GameObject fillCircle;

    float mainTimer = 120f;
    int materCount = 0;
    int materGoal = 5;
    // Start is called before the first frame update
    void Start()
    {
        materGoal += Random.Range(0,4);
        currentScore = startingScore;
        setScoreText();
        scorePanel = GameObject.Find("Score Panel");
        scorePanel.SetActive(false);
        // timerTxt = GameObject.Find("Timer Text").GetComponent<TextMeshProUGUI>();
        // fillCircle = GameObject.Find("timer fill");
        countText.text = "Material Count " + materCount.ToString() + "/" + materGoal.ToString();
    }

    void Update(){
        mainTimer-= 1*Time.deltaTime;
        if(mainTimer< 0 || materCount >= materGoal){
            print("game over");
            Time.timeScale = 0;
            gameOverScreen(); 
        } else{ 
            // fillCircle.fillAmount1 = 1 -( mainTimer/120);
            fillCircle.GetComponent<Image>().fillAmount =1 -( mainTimer/120);
            // timerTxt.text = "Time Remaining : " + Mathf.FloorToInt(mainTimer);
            countText.text = "Material Count " + materCount.ToString() + "/"+materGoal.ToString();
        }
    }

    // Update is called once per frame
    public bool setScore(int addition, bool increseCounter){
        if(currentScore + addition>=0) {
            currentScore+=addition;
            setScoreText();
            if (increseCounter) materCount++;
            return true;
        }
        else return false;
    }



    void setScoreText(){
        scoreText.text = "€" + currentScore.ToString();
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
        if(GetComponent<IntelligentChecker>()!=null)  GameObject.Find("FinalScoreScore").GetComponent<TextMeshProUGUI>().text = "Final Score is "+ currentScore.ToString() + "\n You misplaced materials "+GetComponent<IntelligentChecker>().worngCounter + " times.\n You did not properly recycle "+ GetComponent<IntelligentChecker>().worngCounter + " materials";
        else GameObject.Find("FinalScoreScore").GetComponent<TextMeshProUGUI>().text = "Final Score is "+ currentScore.ToString() ;
    }

    public void goToMainMenu(){
        SceneManager.LoadScene("Menu");
    }

    public void goToReplay(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void goToQuiz(){
        SceneManager.LoadScene("Quiz");
    }
}

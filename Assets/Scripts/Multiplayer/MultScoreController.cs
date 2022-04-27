using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class MultScoreController : MonoBehaviour
{
    int startingScore = 5000;
    int scoreP1;
    int scoreP2;
    // Start is called before the first frame update
 // player 1
    public TextMeshProUGUI scoreTextP1;
    public TextMeshProUGUI countTextP1;
    GameObject scorePanelP1;
    int materCountP1 = 0;

    // player 2
    public TextMeshProUGUI scoreTextP2;
    public TextMeshProUGUI countTextP2;
    GameObject scorePanelP2;
    int materCountP2 = 0;



    public TextMeshProUGUI timerTxtP2;
    public TextMeshProUGUI timerTxtP1;
    float mainTimer = 20f;
    int materGoal = 20;
    GameObject scorePanel;
    void Start()
    {
        scoreP1 = startingScore;
        scoreP2 = startingScore;
        scorePanel = GameObject.Find("Score Panel");

        timerTxtP2 = GameObject.Find("P2TimerText").GetComponent<TextMeshProUGUI>();
        timerTxtP1 = GameObject.Find("P1TimerText").GetComponent<TextMeshProUGUI>();

        setScoreText();
        countTextP1.text = "Material Count " + materCountP1.ToString() + "/" + materGoal.ToString();
        countTextP2.text= "Material Count " + materCountP2.ToString() + "/" + materGoal.ToString();
        
        scorePanel.SetActive(false);
        scoreTextP1.text = "Money - €" + scoreP1.ToString();
        scoreTextP2.text = "Money - €" + scoreP2.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        mainTimer -= 1 * Time.deltaTime;
        if(mainTimer<=0){
            gameOverScreen();
        } else {
            timerTxtP1.text =  "Timer Remaining : " + (int) mainTimer;
            timerTxtP2.text = "Timer Remaining : " +  (int)mainTimer;
            countTextP1.text = "Material Count " + materCountP1.ToString() + "/" + materGoal.ToString();
            countTextP2.text = "Material Count " + materCountP2.ToString() + "/" + materGoal.ToString();
            scoreTextP1.text = "Money - €" + scoreP1.ToString();
            scoreTextP2.text = "Money - €" + scoreP2.ToString();
        }
    }

    public bool setP1Score(int addition, bool increseCounter){
        if(scoreP1 + addition >=0){
            scoreP1 += addition;
            setScoreText();
            if(increseCounter) materCountP1++;
            return true;
        }
        return false;
    }

    public bool setP2Score(int addition, bool increseCounter)
    {
        if(scoreP2 + addition >=0){
            scoreP2 += addition;
            setScoreText();
            if(increseCounter) materCountP1++;
            return true;
        }
        return false;
    }
    void setScoreText(){
        scoreTextP1.text = "Money - €" + scoreP1.ToString();
        scoreTextP2.text = "Money - €" + scoreP2.ToString();
    }
    void gameOverScreen(){
        string p1EndText = "";
        string p2EndText = "";
        if(scoreP1 > scoreP2){
            p1EndText = "You Won!";
            p2EndText = "You Lost.....";
        }else if  (scoreP1 < scoreP2) {
            p2EndText = "You Won!";
            p1EndText = "You Lost.....";
        } else {
            p2EndText = "Its a tie";
            p1EndText = "Its a tie";
        }
        scorePanel.SetActive(true);
        GameObject.Find("FinalTextScoreP1").GetComponent<TextMeshProUGUI>().text = p1EndText;
        //set final score
        GameObject.Find("FinalScoreScoreP1").GetComponent<TextMeshProUGUI>().text = "Your Final Score is " + scoreP1.ToString();
        GameObject.Find("FinalTextScoreP2").GetComponent<TextMeshProUGUI>().text = p2EndText;
        //set final score
        GameObject.Find("FinalScoreScoreP2").GetComponent<TextMeshProUGUI>().text = "Your Final Score is " + scoreP2.ToString();
    }
    public void goToMainMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    void goToReplay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void goToQuiz()
    {
        SceneManager.LoadScene("Quiz");
    }
}

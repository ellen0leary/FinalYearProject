using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ScoreController : MonoBehaviour
{
    int startingScore = 5000;
    int currentScore;
    public TextMeshProUGUI scoreText;

    // Start is called before the first frame update
    void Start()
    {
        currentScore = startingScore;
        setScoreText();
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
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreController : MonoBehaviour
{
    int startingScore = 5000;
    int currentScore;
    // Start is called before the first frame update
    void Start()
    {
        currentScore = startingScore;
    }

    // Update is called once per frame
    public bool setScore(int addition){
        if(currentScore + addition>=0) {
            currentScore+=addition;
            print(currentScore);
            return true;
        }
        else return false;
    }
}

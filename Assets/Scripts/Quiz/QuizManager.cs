using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuizManager : MonoBehaviour
{

    private string[] questions = {"Tin should be sorted first","Plastic should be cleaned first","Cardboard should be shreaded first"};
    private bool[] answers = {false, false, true};
    // Start is called before the first frame update
    int questionValue = -1;
    int correctQuestions=0;
    int currentQuestions=0;
    int totalQuestions=2;
    TextMeshProUGUI questionText;
    
    void Start()
    {
        questionText =GetComponent<TextMeshProUGUI>();
        setQuestion();
    }


    public void clickTrue(){
        checkValidity(true);
        setQuestion();
    }

    public void clickFalse(){
        checkValidity(false);
        setQuestion();
    }

    void setQuestion(){
        if(currentQuestions == totalQuestions){
            showResults();return;
        }
        currentQuestions++;
        questionValue = Random.Range(0, questions.Length);
        questionText.text = questions[questionValue];
    }

    void checkValidity(bool answer){
        if(answer == answers[questionValue]){
            //correct
            correctQuestions++;
            print("correct");
        } else {
            //wrong
            print("wrong");
        }
        //show yes or no
    }

    void showResults(){
        print("you are finished");
        questionText.text = "You have finished with "+ correctQuestions.ToString() +" right.";
        //TODO - remove btn
    }
}

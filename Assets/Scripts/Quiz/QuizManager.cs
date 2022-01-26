using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class QuizManager : MonoBehaviour
{
    private LoadQuestions QuestionLoader;

    private string[] questions = {"Tin should be sorted first","Plastic should be cleaned first","Cardboard should be shreaded first"};
    private bool[] answers = {false, false, true};
    // Start is called before the first frame update
    int questionValue = -1;
    int correctQuestions=0;
    int currentQuestions=0;
    int totalQuestions=2;
    TextMeshProUGUI questionText;
    public GameObject trueBtn;
    public GameObject falseBtn;
    public GameObject mainBtn;
    void Start()
    {
        mainBtn.SetActive(false);
        questionText =GetComponent<TextMeshProUGUI>();
        setQuestion();
    }

    void setQuestion(){
        if(currentQuestions == totalQuestions){
            showResults();return;
        }
        currentQuestions++;
        questionValue = Random.Range(0, questions.Length);
        questionText.text = questions[questionValue];


        // StartCoroutine(QuestionLoader.getJSON(1));
        

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
    }

    void showResults(){
        print("you are finished");
        questionText.text = "You have finished with "+ correctQuestions.ToString() +" right.";
        Destroy(trueBtn);
        Destroy(falseBtn);
        mainBtn.SetActive(true);
    }



    // btn methods
    public void goToMainMenu(){
        SceneManager.LoadScene(0);
    }

     public void clickTrue(){
        checkValidity(true);
        setQuestion();
    }

    public void clickFalse(){
        checkValidity(false);
        setQuestion();
    }

}

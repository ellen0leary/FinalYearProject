using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class QuizManager : MonoBehaviour
{
    private LoadQuestions QuestionLoader;
    private IntelligentTutor intelligentTutor;

    private string[] questions = {"Tin should be sorted first","Plastic should be cleaned first","Cardboard should be shreaded first"};
    private bool[] answers = {false, false, true};
    List<Question> questionsToAsk;
    // Start is called before the first frame update
    int questionValue = -1;
    public int correctQuestions=0;
    public int currentQuestions=0;
    public int totalQuestions=2;
    TextMeshProUGUI questionText, leftAnswerTxt, rightAnswerTxt;
    public GameObject trueBtn;
    public GameObject falseBtn;
    public GameObject mainBtn;
    public GameObject rightPanel, wrongPanel;
    bool ifQuestions = false;
    string leftAnswer,rightAnswer;
    bool ifTimerActive = false;
    float timeRemaining = 2;
    void Start()
    {
        mainBtn.SetActive(false);
        intelligentTutor = GetComponent<IntelligentTutor>();
        questionText =GetComponent<TextMeshProUGUI>();
        leftAnswerTxt = GameObject.Find("LeftAns").GetComponent<TextMeshProUGUI>();
        rightAnswerTxt = GameObject.Find("RightAns").GetComponent<TextMeshProUGUI>();
        rightPanel.SetActive(false);
        wrongPanel.SetActive(false);
        // setQuestion();
    }

    void Update(){
        if(ifQuestions){
            //remove loading screen#
            totalQuestions = questionsToAsk.Count;
            setQuestion();
            ifQuestions = false;
        }
        if(ifTimerActive){
            timeRemaining -=1f *Time.deltaTime;
            if(timeRemaining<0){
                rightPanel.SetActive(false);
                wrongPanel.SetActive(false);
                timeRemaining =2;
                ifTimerActive = false;
            }
        }
    }
    void setQuestion(){
        if(currentQuestions == totalQuestions){
            showResults();return;
        }
        questionText.text = questionsToAsk[currentQuestions].question;
        currentQuestions++;
        int random = Random.Range(0,4);
        if(random%2==0){
            leftAnswer =questionsToAsk[currentQuestions].answer;
            rightAnswer = questionsToAsk[currentQuestions].wrong;
        } else{
            leftAnswer =questionsToAsk[currentQuestions].wrong;
            rightAnswer = questionsToAsk[currentQuestions].answer;
        }
        leftAnswerTxt.text = leftAnswer;
        rightAnswerTxt.text = rightAnswer;
        // StartCoroutine(QuestionLoader.getJSON(1));
        

    }

    void checkValidity(string answer){
        if(answer == questionsToAsk[currentQuestions-1].answer){
            //correct
            correctQuestions++;
            print("correct");
            rightPanel.SetActive(true);
            ifTimerActive = true;
        } else {
            //wrong
            print("wrong");
            wrongPanel.SetActive(true);
            ifTimerActive = true;
        }
    }

    void showResults(){
        print("you are finished");
        intelligentTutor.addScore(correctQuestions);
        int average = intelligentTutor.getAverage();
        questionText.text = "You have finished with "+ correctQuestions.ToString() +" right. \n Your average so far is "+average.ToString();
        if( correctQuestions> average){
            questionText.text += "\n You have improved you average";
        }
        if(intelligentTutor.returnLastScore()!= -1){
            if(correctQuestions >intelligentTutor.returnLastScore()){
                questionText.text += "\n You did better this quiz than the last one!";
            } else {
                questionText.text += "\n You did worst than the last quiz. Try again";
            }
        }
        Destroy(leftAnswerTxt);
        Destroy(rightAnswerTxt);
        Destroy(trueBtn);
        Destroy(falseBtn);
        intelligentTutor.saveScores();
        mainBtn.SetActive(true);
    }



    // btn methods
    public void goToMainMenu(){
        SceneManager.LoadScene(0);
    }

     public void clickTrue(){
         print("click left");
        checkValidity(leftAnswer);
        setQuestion();
    }

    public void clickFalse(){
        print("click left");
        checkValidity(rightAnswer);
        setQuestion();
    }

    public void setQuestions(List<Question> questions){
        questionsToAsk = questions;
        ifQuestions = true;
        print("have Questions");
    }

}

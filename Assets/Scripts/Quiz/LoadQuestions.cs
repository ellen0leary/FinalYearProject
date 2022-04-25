using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Networking;
using System;

public class LoadQuestions : MonoBehaviour
{
    private static string URL = "https://sensorial-hammer.000webhostapp.com/api/questions.php";
    // Start is called before the first frame update
    public List<Question> questionsToAsk = new List<Question>();
    QuizManager quiz;
    int numOfQuestions= 2;
    bool ifLoaded = false;
    bool ifSent = false;
    public GameObject errorPanel, loadingPanel;
    void Start()
    {
        errorPanel.SetActive(false);
        loadingPanel.SetActive(true);
        quiz = GameObject.Find("QuestionTxt").GetComponent<QuizManager>();
        for(int i=0; i<2; i++){
            StartCoroutine(processRequest());
        }
    }

    void Update(){
        if(questionsToAsk.Count == numOfQuestions && !ifSent){
            ifLoaded = true;
        }
        if(ifLoaded){
            quiz.setQuestions(questionsToAsk);
            ifLoaded = false;
            ifSent = true;
            loadingPanel.SetActive(false);
        }
    }
    private IEnumerator processRequest(){
        WWW www = new WWW(URL);
        yield return www;
        if(www.error == null){
            string result = www.text;
            print(result);
            string[] list = result.Split(',');
            Question qu = new Question{question=list[0], answer = list[1], wrong=list[2]};
            questionsToAsk.Add(qu);
            print(questionsToAsk.Count);
        } else {
            errorPanel.SetActive(true);
        }
    }

    public void tryAgain(){
        for(int i=0; i<2; i++){
            StartCoroutine(processRequest());
        }
    }
}

[Serializable]
public class Question{
    public string question;
    public string answer;
    public string wrong;
}


using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Networking;
using System;

public class LoadQuestions : MonoBehaviour
{
    private static string URL = "http://localhost:8080/api/questions.php";
    private static string LENGTH_URL = "http://localhost:8080/api/questionLength.php";
    // Start is called before the first frame update
    void Start()
    {
        // StartCoroutine(ProcessRequest(URL));
        // StartCoroutine(getJSON());
    }

    public IEnumerator getJSON(int randomInt){
        WWW www = new WWW(URL);
        yield return www;
        if(www.error==null){
            processRequest(www.text);
        } else{
            Debug.Log("not working");
        }
    }

    private void processRequest(string text){
        string qText = "{\"Questions\":" + text+ "}";
        Debug.Log(qText);
        QuestionList questionNow = JsonUtility.FromJson<QuestionList>(qText);
        Debug.Log(questionNow.qs.Count);
    }
}

[Serializable]
public class QuestionList {
    public List<Question> qs;
}



[Serializable]
public class Question{
    public string questions;
    public string answers;
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class IntelligentTutor : MonoBehaviour
{
    List<int> listOfScores = new List<int>();
    private string playerPrefName = "ListOfScores";
    int lastScore = -1;
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetString(playerPrefName,"2,1,4,5,2");
       if(PlayerPrefs.HasKey(playerPrefName)){
           string scoreString = PlayerPrefs.GetString(playerPrefName);
           print(scoreString);
           string[] stringOfScores = scoreString.Split(',');
           foreach(string x in stringOfScores){
                int result = Int32.Parse(x);
                listOfScores.Add(result);
                getLastScore();
           }
       } else {
           PlayerPrefs.SetString(playerPrefName,"2,1,4,5,2");
       }
       Debug.Log(listOfScores.Count);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void getLastScore(){
        lastScore = listOfScores[listOfScores.Count-1];
    }

    public int getAverage(){
        int average = 0;
        foreach(int i in listOfScores){
            average+= i;
        }
        return (average/listOfScores.Count);
    }

    public void addScore(int newScore){
        listOfScores.Add(newScore);
    }

    public void saveScores(){
        string str = "";
        foreach (int i in listOfScores)
        {
            str += i.ToString() + ",";
        }
        PlayerPrefs.SetString(playerPrefName, str);
    }

    public int returnLastScore(){
        return lastScore;
    }
}

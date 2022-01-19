using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class LoadQuestions : MonoBehaviour
{
    private static string URL = "http://localhost:8080/api/questions.php";
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ProcessRequest(URL));
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void GenerateRequest()
    {
        // StartCoroutine(ProcessRequest(URL));
    }

    private IEnumerator ProcessRequest(string uri)
    {
        using (UnityWebRequest request = UnityWebRequest.Get(uri))
        {
            yield return request.SendWebRequest();

            if (request.isNetworkError)
            {
                Debug.Log(request.error);
            }
            else
            {
                Debug.Log(request.downloadHandler.text);
            }
        }
    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Drag : MonoBehaviour
{
    WorkerManager man;
    private Vector3 startingPos;
    private Vector3 endingPos;
    private Vector3 offset;
    float mZCoord;
    bool ifMoved;
    public GameObject checkerObject;
    public IntelligentChecker checker;
    AudioSource audio;
    bool ifMulti;
    void Start(){
        if(SceneManager.GetActiveScene().buildIndex ==4) ifMulti = true;
        else ifMulti = false;
        if(!ifMulti) man = GameObject.Find("Workers").GetComponent<WorkerManager>();

        checkerObject = GameObject.Find("ScoreController");
        checker = checkerObject.GetComponent<IntelligentChecker>();
        ifMoved = false;
        audio = GetComponent<AudioSource>();
    }
    void OnMouseDown() {
        startingPos = gameObject.transform.position;
        mZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        offset = gameObject.transform.position - GetMousePos();
        checker.activateTipPanel(this.gameObject.name);
        ifMoved = false;
        audio.Play();
    }
     void OnMouseDrag() {
        transform.position = GetMousePos()+offset;
        endingPos = transform.position;
        ifMoved = true;
    }

    void OnMouseExit(){
        if(ifMoved && gameObject.tag=="material"){
        // endingPos = transform.position;
            // man.sendWorker(startingPos, endingPos, this.gameObject);
            // this.gameObject.transform.position = startingPos;
            if(!ifMulti)checker.closeTipPanel();
        } else {
            ifMoved  = false;
        }
    }

    Vector3 GetMousePos(){
        Vector3 mousePt = Input.mousePosition;
        mousePt.z = mZCoord;
        return Camera.main.ScreenToWorldPoint(mousePt);
    }
}

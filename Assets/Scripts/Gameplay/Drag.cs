using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    void Start(){
        man = GameObject.Find("Workers").GetComponent<WorkerManager>();

        checkerObject = GameObject.Find("ScoreController");
        checker = checkerObject.GetComponent<IntelligentChecker>();
        ifMoved = false;
    }
    void OnMouseDown() {
        startingPos = gameObject.transform.position;
        mZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        offset = gameObject.transform.position - GetMousePos();
        checker.activateTipPanel(this.gameObject.name);
        ifMoved = false;
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
            checker.closeTipPanel();
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

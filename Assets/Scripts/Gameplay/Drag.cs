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

    void Start(){
        man = GameObject.Find("Workers").GetComponent<WorkerManager>();
        ifMoved = false;
    }
    void OnMouseDown() {
        startingPos = gameObject.transform.position;
        mZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        offset = gameObject.transform.position - GetMousePos();
        ifMoved = false;
    }
     void OnMouseDrag() {
        transform.position = GetMousePos()+offset;
        endingPos = transform.position;
        ifMoved = true;
    }

    void OnMouseExit(){
        if(ifMoved && this.gameObject.tag=="material"){
        // endingPos = transform.position;
            man.sendWorker(startingPos, endingPos);
        }
    }

    Vector3 GetMousePos(){
        Vector3 mousePt = Input.mousePosition;
        mousePt.z = mZCoord;
        return Camera.main.ScreenToWorldPoint(mousePt);
    }
}

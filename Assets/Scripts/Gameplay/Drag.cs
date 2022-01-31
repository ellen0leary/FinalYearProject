using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drag : MonoBehaviour
{
    private Vector3 offset;
    float mZCoord;

    void OnMouseDown() {
        mZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        offset = gameObject.transform.position - GetMousePos();
    }
     void OnMouseDrag() {
        transform.position = GetMousePos()+offset;
    }



    Vector3 GetMousePos(){
        Vector3 mousePt = Input.mousePosition;
        mousePt.z = mZCoord;
        return Camera.main.ScreenToWorldPoint(mousePt);
    }
}

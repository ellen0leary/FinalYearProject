using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialColliderChecker : MonoBehaviour
{
    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.CompareTag("building")){
            print("dropping item");
            ActiveBuilding build = other.gameObject.GetComponent<ActiveBuilding>();
            if(build != null){
                build.StartMaterial();
                Destroy(this.gameObject);
            }
        }
    }
}

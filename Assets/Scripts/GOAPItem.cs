using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GOAPItem : MonoBehaviour
{
    public GameObject item;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void spawnItem(){  
        // float randX = Random.Range(-0.5f, 0.5f);
        // float randY = Random.Range(-0.5f, 0.5f);
        Vector3 pos = new Vector3(transform.position.x + 1.2f, transform.position.y + 1.2f, transform.position.z);
        GameObject g = Instantiate(item, pos, item.transform.rotation);
    }
}

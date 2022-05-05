using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateEnv : MonoBehaviour
{
    public GameObject[] trees;
    public GameObject[] rocks;
    int totalTrees, totalRocks;
    // Start is called before the first frame update
    void Start()
    {
        string level = PlayerPrefs.GetString("level");
        if(level == "grassy"){
            totalTrees = 3;
            totalRocks = 3;
        } else {
            totalTrees = 8;
            totalRocks = 2;
        }
        SetUpEnv();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetUpEnv(){
        for(int i=0; i<totalTrees; i++){
            int yPos = Random.Range(0,4);
            float z= 0;
            if(yPos%2== 0){
                z = Random.Range(-5,-2);
            } else {
                z = Random.Range(2,5);
            }
            float y = 0f;
            float x = Random.Range(-3,10);
            //get random int for tree
            int treeIndex = Random.Range(0, trees.Length);
            //get tree from array
            GameObject tree = trees[treeIndex];
            //put in position and scale
            tree.transform.position = new Vector3(x, y, z);
            tree.transform.localScale = new Vector3(0.25f, 0.25f,0.25f);
            Instantiate(tree, tree.transform.position, tree.transform.rotation);
        }

        for(int i=0; i<totalRocks; i++){
            float rockZ = Random.Range(-5, 5);
            float rockY = 0.1f;
            float rockX = Random.Range(-3, 10);
            //get random int for rocks
            int rockIndex = Random.Range(0, rocks.Length);
            //get rock for array
            GameObject rock = rocks[rockIndex];
            //put in position and scale
            rock.transform.position = new Vector3(rockX,rockY,rockZ);
            rock.transform.localScale = new Vector3(0.25f,0.25f,0.25f);

            Instantiate(rock, rock.transform.position, rock.transform.rotation);
        }
    }
}

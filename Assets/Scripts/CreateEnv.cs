using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateEnv : MonoBehaviour
{
    public GameObject[] trees;
    public GameObject[] rocks;
    // Start is called before the first frame update
    void Start()
    {
        SetUpEnv();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetUpEnv(){
        int totalTrees = Random.Range(1,5);
        for(int i=0; i<totalTrees; i++){
            float z = Random.Range(-5,5);
            float y = 0f;
            float x = Random.Range(-3,10);
            print("getting enviroment");
            //get random int for tree
            int treeIndex = Random.Range(0, trees.Length);
            print(treeIndex);
            //get tree from array
            GameObject tree = trees[treeIndex];
            print(tree);
            //put in position and scale
            tree.transform.position = new Vector3(x, y, z);
            tree.transform.localScale = new Vector3(0.25f, 0.25f,0.25f);
            Instantiate(tree, tree.transform.position, tree.transform.rotation);
        }

        int totalRocks = Random.Range(1,5);
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

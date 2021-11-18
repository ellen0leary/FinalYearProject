using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WorkerManager : MonoBehaviour
{
    public NavMeshAgent nav;
    public Vector3 walkPoint;
    public float walkPointRange;
    public LayerMask whatIsGround;
    bool isBusy, walkPointSet;

    // Start is called before the first frame update
    void Start()
    {
        isBusy= false;
    }

    // Update is called once per frame
    void Update()
    {
        int randomInt = -1;
        //random movement
        //setTasks
        //eating working

        if(!isBusy){
            randomInt = Random.Range(0,2);
            isBusy=true;
        }

    Patrolling(); 
        if(randomInt == 0){
            Patrolling(); 
        }else if(randomInt==1){
            //eat
        }else if(randomInt == 2){
            //working
        }
    }

    void Patrolling(){
        if(!walkPointSet){
            lookForPoint();
        } else {
            nav.SetDestination(walkPoint);
        }

        Vector3 distaneToPoint = transform.position - walkPoint;

        if(distaneToPoint.magnitude <1f){
            walkPointSet = false;
        }
    }

    void lookForPoint(){
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint= new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z+ randomZ);

        if(Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround)) walkPointSet = true;
        else walkPointSet = false;
    }
}

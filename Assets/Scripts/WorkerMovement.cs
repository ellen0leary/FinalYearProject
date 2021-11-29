using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WorkerMovement : MonoBehaviour
{
    public NavMeshAgent nav;
    public Vector3 walkPoint;
    public float walkPointRange;
    public GameObject brick;
    public LayerMask whatIsGround;
    bool isBusy;
    bool walkPointSet;
    float randomInt = -1;

    // Start is called before the first frame update
    void Start()
    {
        isBusy = false;
    }

    // Update is called once per frame
    void Update()
    {

        //random movement
        //setTasks
        //eating working

        if (!isBusy)
        {
            randomInt = (int)Random.Range(0, 5);
            isBusy = true;
        }
        if (randomInt == 0f || randomInt == 2f || randomInt == 4f)
        {
            Patrolling();
        }
        else if (randomInt == 3f || randomInt == 1f)
        {
            GoToEat();
        }
        // else if(randomInt == 2){
        //     //working
        // }
    }

    void Patrolling()
    {
        print("Patrolling");
        if (!walkPointSet)
        {
            lookForPoint();
        }
        else
        {
            nav.SetDestination(walkPoint);
        }

        Vector3 distaneToPoint = transform.position - walkPoint;

        if (distaneToPoint.magnitude < 1f)
        {
            walkPointSet = false;
            isBusy = false;
        }
    }

    void lookForPoint()
    {
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround)) walkPointSet = true;
        else walkPointSet = false;
    }

    void GoToEat()
    {
        print("eat");
        walkPoint = new Vector3(6.4f, transform.position.y, -1.6f);
        nav.SetDestination(walkPoint);

        walkPointSet = true;
        Vector3 distaneToPoint = transform.position - walkPoint;
        if (distaneToPoint.magnitude < 3f)
        {
            walkPointSet = false;
            isBusy = false;
        }

    }

    public void sendToTruck(){
        print("going to truck");
        nav.SetDestination(new Vector3(-3f,0.12f, 1f));
        walkPointSet = true;
        walkPoint = new Vector3(-3f, 0.12f, 1f);
        isBusy=true;
    }
}

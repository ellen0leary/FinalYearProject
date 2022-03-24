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
    public bool isBusy;
    bool walkPointSet;
    float randomInt = -1;
    bool noFeelings=true;

    // Start is called before the first frame update
    bool ifTimerActive;
    float timer = 0;
    float sleepTimer = 500;
    float eatTimer = 200;
    Vector3 sleepPoint;
    Vector3 eatPoint;
    Vector3 knowedgePoint;
    Vector3 stopingArea;
    WorkerFeelings feel;

    bool isWorking;
    bool isFirstPos;
    Vector3 startPos;
    Vector3 endPos;
    GameObject child;
    bool isReady;
    void Start()
    {
        isReady = true;
        isBusy = false;
        isWorking = false;
        eatPoint = GameObject.FindGameObjectWithTag("cantain").transform.position;
        sleepPoint = GameObject.FindGameObjectWithTag("dormitory").transform.position;
        knowedgePoint = GameObject.FindGameObjectWithTag("knowledge").transform.position;
        stopingArea = GameObject.FindGameObjectWithTag("Stopping Area").transform.position;
        feel = GetComponent<WorkerFeelings>();
        GetComponent<NavMeshAgent>().speed = 0.7f;
    }

    // Update is called once per frame
    void Update()
    {
        // if(!noFeelings){
        //     // nav.SetDestination(this.gameObject.transform.position);
        //     nav.ResetPath();
        //     return;
        // }
        if(isWorking){
            checkWorking();
            return;
        } else {
        Patrolling();
        }
        // if (!isBusy)
        // {
        //     randomInt = (int)Random.Range(0, 5);
        //     isBusy = true;
        // }
        // if (randomInt == 0f || randomInt == 4f)
        // {
        //     Patrolling();
        //     isReady = true;
        // }
        // else if (randomInt == 3f || randomInt == 1f)
        // {
        //     GoToEat();
        //     isReady = false;
        // }
        // else if(randomInt == 2){
        //     GoToWork();
        //     isReady = false;
        // }
    }

    void Patrolling()
    {
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
        walkPoint =eatPoint;
        nav.SetDestination(walkPoint);

        walkPointSet = true;
        Vector3 distaneToPoint = transform.position - walkPoint;
        if (distaneToPoint.magnitude < 1f)
        {
            feel.IncreaseEat(70);
            ifTimerActive = true;
            timer = eatTimer;
            walkPointSet = false;
            isBusy = false;
        }

    }

    void GoToSleep()
    {
        walkPoint = sleepPoint;
        nav.SetDestination(walkPoint);

        walkPointSet = true;
        Vector3 distaneToPoint = transform.position - walkPoint;
        if (distaneToPoint.magnitude < 1f)
        {
            feel.IncreaseSleep(70);
            ifTimerActive = true;
            timer = eatTimer;
            walkPointSet = false;
            isBusy = false;
        }

    }

    void GoGetKnowledge()
    {
        walkPoint = knowedgePoint;
        nav.SetDestination(walkPoint);

        walkPointSet = true;
        Vector3 distaneToPoint = transform.position - walkPoint;
        if (distaneToPoint.magnitude < 1f)
        {
            feel.IncreaseKnowledge(70);
            ifTimerActive = true;
            timer = eatTimer;
            walkPointSet = false;
            isBusy = false;
        }

    }

    void GoToWork(){
        walkPoint = stopingArea;
        nav.SetDestination(walkPoint);

        walkPointSet = true;
        Vector3 distaneToPoint = transform.position - walkPoint;
        if (distaneToPoint.magnitude < 1f)
        {
            ifTimerActive = true;
            timer = eatTimer;
            walkPointSet = false;
            isBusy = false;
        }

    }
    public void sendToTruck(){
        nav.SetDestination(new Vector3(-3f,0.12f, 1f));
        walkPointSet = true;
        walkPoint = new Vector3(-3f, 0.12f, 1f);
        isBusy=true;
    }

    public void noFeels(bool obj){
        noFeelings = obj;
    }

    public void setSpeed(bool ifSlow){
        if(ifSlow)
        {
            GetComponent<NavMeshAgent>().speed = 0.7f;
        } else {
            GetComponent<NavMeshAgent>().speed = 0.1f;
        }
    }

    public void sendWorkerToEat(){
        GoToEat();
    }

    public void sendWorkerToSleep(){
        GoToSleep();
    }

    public void sendWorkerToKnowelge(){
        GoGetKnowledge();
    }

    public void sendToWork(Vector3 start, Vector3 end, GameObject material){
        print("sending to work");
        startPos = start;
        endPos = end;
        walkPoint = start;
        isWorking = true;
        isFirstPos = true;
        nav.SetDestination(walkPoint);
        child = material;
        isReady = false;
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag=="material" && transform.childCount==0 && other.gameObject.transform.parent== null && isWorking){
            other.gameObject.transform.parent = this.gameObject.transform;
            isFirstPos = false;
            walkPoint = endPos;
            nav.SetDestination(endPos);
        }
    }
    public void sendToWork(GameObject material){
        walkPoint = material.transform.position;
        isWorking = true;
        isFirstPos = true;
        nav.SetDestination(walkPoint);
        child = material;
        isReady = false;
    }

    void checkWorking(){
        if(isFirstPos){
            Vector3 distaneToPoint = transform.position - walkPoint;
            if (Vector3.Distance(transform.position, walkPoint) < 0.25f)
            {
                print(Vector3.Distance(transform.position, walkPoint));
                isFirstPos = false;
                walkPoint = endPos;
                nav.SetDestination(endPos);
                // child.transform.parent = this.gameObject.transform;
            }
        }else {
            Vector3 distaneToPoint = transform.position - walkPoint;
            print( walkPoint + " " + transform.position);
            if (Vector3.Distance(transform.position, walkPoint) < 0.6f)
            {
                isFirstPos = true;
                isWorking = false;
                walkPointSet = false;
                isReady = true;
                nav.SetDestination(new Vector3(0,0,0));
                // transform.DetachChildren();
            }
        }
    }


    // void checkWorking()
    // {
    //         Vector3 distaneToPoint = transform.position - walkPoint;
    //         print(Vector3.Distance(transform.position, walkPoint));
    //         if (Vector3.Distance(transform.position, walkPoint) < 1.2f)
    //         {
    //             isFirstPos = false;
    //             walkPoint = endPos;
    //             nav.SetDestination(endPos);
    //             child.transform.parent = this.gameObject.transform;
    //             GameObject chil = gameObject.transform.GetChild(0).gameObject;
    //             child.GetComponent<AutoMaterialController>().getNextLocation();

    //         }
    // }


    public bool isWorkerReady(){
        print(isReady);
        return isReady;
    }

    public void setIsBusy(){
        print("changing");
        walkPointSet = false;
        isWorking = false;
        isBusy = false;
    }
}

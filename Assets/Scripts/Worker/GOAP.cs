using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GOAP : MonoBehaviour
{
    Animator anim;
    AnimatorStateInfo info;
    TheQueue queueCon;
    WorkerManager wm;
    NavMeshAgent nav;
    public bool isBusy, isWandering, walkPointSet;
    public bool isLowSleep,isLowEat,isLowTrain;
    //for sleep
    bool hasBlanket, isBlanketOrdered;
    //for eat

    //for train
    bool hasBook, isBookOrdered;

    Vector3 walkPoint;
    public float walkPointRange;
    public LayerMask whatIsGround;
    GameObject dorm;
    public GameObject blanket;
    TruckManager tm;

    Vector3 target, dormPt;
    GameObject targetItem;
    // Start is called before the first frame update
    void Start()
    {
        walkPointRange = 10f;
        anim = GetComponent<Animator>();
        queueCon = GameObject.Find("Workers").GetComponent<TheQueue>();
        nav = GetComponent<NavMeshAgent>();
        isBusy = false;
        isWandering = false;
        walkPointSet = false;
        isLowSleep = false;
        isLowEat = false;
        isLowTrain = false;
        hasBlanket = false;
        isBlanketOrdered = false;
        dorm = GameObject.Find("dormitory");
        tm = GameObject.Find("Truck Manager").GetComponent<TruckManager>();
        dormPt = GameObject.Find("dormPt").transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        info = anim.GetCurrentAnimatorStateInfo(0);

        if(info.IsName("Work")){
            // look at queue for stuff to do
            if(isWandering){
                    //look for point
                    Patrolling();
                }
            else if(!isBusy){
                GameObject g = queueCon.getJob();
                //if queue has item
                if(g != null){
                    // go do it 
                    nav.SetDestination(g.transform.position);
                    isBusy = true;
                    //idk bro
                } else {
                    isWandering = true;
                    print("start wandering");
                }
            }
                //mill about
                //mabe feed other needs
        
        } else if (info.IsName("Eat")){
            // print("needs to eat");
            // if(!hasBlanket){
            //     //wait for bed to arrive
            //     if(isBookOrdered){
            //         //order (from truck)
            //     }
            //     GameObject g = GameObject.FindGameObjectWithTag("blanket");
            //     if(g!= null){
            //         //set Destination
            //     }
            // } else {
            //     //check loc to pos
            //     //wait X secs
            // }
        } else if( info.IsName("Sleep")){
            // go to sleep
            print("needs to sleep");
            if(!hasBlanket){
                //wait for bed to arrive
                if(!isBlanketOrdered){
                    //order (from truck)
                    tm.spawnInGOAP(blanket);
                    isBlanketOrdered = true;
                }
                GameObject g = GameObject.FindGameObjectWithTag("blanket");
                if(g!= null){
                    //set Destination
                    nav.SetDestination(g.transform.position);
                    target = g.transform.position;
                    targetItem = g;
                    if((transform.position - target).magnitude< 1f){
                    hasBlanket = true;
                    targetItem.transform.parent = this.gameObject.transform;
                }
                    
                }
            } else {
                //check loc to pos
                target = dormPt;
                nav.SetDestination(target);
                //wait X secs
                if((transform.position - target).magnitude< 1f){
                    //wait
                    targetItem.transform.parent = null;
                    Destroy(targetItem);
                    targetItem = null;
                    isLowSleep = false;
                    anim.SetBool("StartSleep", isLowSleep);
                }
            }
        } else if(info.IsName("Train")){
            print("needs training");
            // go to train
            
            //find point 
            //send

            //if train is high again move back
        }



    }

    void Patrolling()
    {
        print("Patrol");
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
            isWandering= false;
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

    public void ifLowSleep(bool ifLow){
        isLowSleep = ifLow;
        if(!isBusy)anim.SetBool("StartSleep", isLowSleep);
        else {
            //set to be done next
        }
    }


    public void ifLowEat(bool ifLow){

    }

    public void ifLowTrain(bool ifLow){

    }

    public void haveMaterial(Vector3 nextPos){
        isBusy = true;
        nav.SetDestination(nextPos);
    }

    public void finMaterial(){
        isBusy = false;
        nav.SetDestination(new Vector3(0,0,0));
    }

    public bool ifBusy() {
        return isBusy;
    }
}

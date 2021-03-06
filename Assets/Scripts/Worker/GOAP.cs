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
    public bool isBusy, isWandering, walkPointSet, ifcheckNeeded, isHaveMaterial;
    public bool isLowSleep,isLowEat,isLowTrain;
    //for sleep
    bool hasBlanket, isBlanketOrdered;
    //for eat
    bool hasFood, isFoodOrdered;
    //for train
    bool hasBook, isBookOrdered;

    public Vector3 walkPoint;
    public float walkPointRange;
    public LayerMask whatIsGround;
    GameObject dorm;
    public GameObject blanket, food, book;
    TruckManager tm;

    public Vector3 target, dormPt, canteinPt, trainingPt;
    public GameObject targetItem;
    Vector3 buildPos;
    // Start is called before the first frame update
    void Start()
    {
        walkPointRange = 10f;
        anim = GetComponent<Animator>();
        queueCon = GameObject.Find("Workers").GetComponent<TheQueue>();
        nav = GetComponent<NavMeshAgent>();
        isBusy = false;
        isWandering = false;
        walkPointSet = false; ifcheckNeeded= false; isHaveMaterial=false;
        isLowSleep = false; hasBlanket = false;   isBlanketOrdered = false;
        isLowEat = false; hasFood = false;  isFoodOrdered = false;
        isLowTrain = false; hasBook = false;  isBookOrdered = false;
        dorm = GameObject.Find("dormitory");
        tm = GameObject.Find("Truck Manager").GetComponent<TruckManager>();
        dormPt = GameObject.Find("dormPt").transform.position;
        canteinPt = GameObject.Find("CateainPt").transform.position;
        trainingPt = GameObject.Find("TrainPt").transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        info = anim.GetCurrentAnimatorStateInfo(0);
        if(isBusy && targetItem == null){
            isBusy = false;
        }
        if(info.IsName("Work")){
            // look at queue for stuff to do
            if(!isBusy){
                GameObject g = queueCon.getJob();
                //if queue has item
                if(g != null){
                    // go do it 
                    nav.SetDestination(g.transform.position);
                    isBusy = true;
                    isWandering = false;
                    targetItem = g;
                    //idk bro
                } else {
                    isWandering = true;
                }
            }  else {
                if(!isHaveMaterial) nav.SetDestination(targetItem.transform.position);
                else  nav.SetDestination(buildPos);
            }
            if(isWandering){
                    //look for point
                    Patrolling();
                    return;
            }
        
        } else if (info.IsName("Eat")){
            if(!hasFood){
                //wait for bed to arrive
                if(!isFoodOrdered){
                    //order (from truck)
                    tm.spawnInGOAP(food);
                    isFoodOrdered = true;
                    isBusy = true;
                    return;
                }
                GameObject[] gs =  GameObject.FindGameObjectsWithTag("food");
                GameObject g = checkParent(gs);
                if(g!= null){
                    //set Destination
                    nav.SetDestination(g.transform.position);
                    target = g.transform.position;
                    targetItem = g;
                    if((transform.position - target).magnitude< 0.3f &&transform.childCount==3 && targetItem.transform.parent==null){
                        hasFood = true;
                        targetItem.transform.parent = this.gameObject.transform;
                    }
                    
                }
            } else {
                //check loc to pos
                target = canteinPt;
                nav.SetDestination(target);
                //wait X secs
                if((transform.position - target).magnitude< 0.3f){
                    //wait
                    targetItem.transform.parent = null;
                    Destroy(targetItem);
                    targetItem = null;
                    isLowEat = false;
                    isFoodOrdered = false;
                    hasFood = false;
                    isBusy = false;
                    GetComponent<WorkerFeelings>().IncreaseEat(130);
                    anim.SetBool("StartFood",isLowEat );
                }
            }
        } else if( info.IsName("Sleep")){
            // go to sleep
            print("needs to sleep");
            if(!hasBlanket){
                //wait for bed to arrive
                if(!isBlanketOrdered){
                    //order (from truck)
                    tm.spawnInGOAP(blanket);
                    isBlanketOrdered = true;
                    isBusy = true;
                    return;
                }
                GameObject[] gs =  GameObject.FindGameObjectsWithTag("blanket");
                GameObject g = checkParent(gs);
                if(g!= null){
                    //set Destination
                    nav.SetDestination(g.transform.position);
                    target = g.transform.position;
                    targetItem = g;
                    if((transform.position - target).magnitude< 0.3f&& transform.childCount==3&& targetItem.transform.parent==null){
                        hasBlanket = true;
                        targetItem.transform.parent = this.gameObject.transform;
                    } 
                }
            } else {
                target = dormPt;
                nav.SetDestination(target);
                //wait X secs
                if((transform.position - target).magnitude< 0.3f){
                    //wait
                    targetItem.transform.parent = null;
                    Destroy(targetItem);
                    targetItem = null;
                    isLowSleep = false;
                    hasBlanket = false;
                    isBlanketOrdered = false;
                    isBusy = false;
                    GetComponent<WorkerFeelings>().IncreaseSleep(130);
                    anim.SetBool("StartSleep", isLowSleep);
                }
            }
        } else if(info.IsName("Train")){    
            if(!hasBook){
                //wait for bed to arrive
                if(!isBookOrdered){
                    //order (from truck)
                    tm.spawnInGOAP(book);
                    isBookOrdered = true;
                    isBusy = true;
                    return;
                }
                GameObject[] gs =  GameObject.FindGameObjectsWithTag("book");
                GameObject g = checkParent(gs);

                if(g!= null){
                    //set Destination
                    nav.SetDestination(g.transform.position);
                    target = g.transform.position;
                    targetItem = g;
                    
                    if((transform.position - target).magnitude< 0.3f && transform.childCount==3 &&targetItem.transform.parent==null){
                        hasBook = true;
                        targetItem.transform.parent = this.gameObject.transform;
                    }
                    
                }
            }else {
                //check loc to pos
                
                target = trainingPt;
                nav.SetDestination(target);
                //wait X secs
                if((transform.position - target).magnitude< 0.3f ){
                    //wait
                    targetItem.transform.parent = null;
                    Destroy(targetItem);
                    targetItem = null;
                    isLowTrain = false;
                    isFoodOrdered = false;
                    hasBook = false;
                    isBusy = false;
                    GetComponent<WorkerFeelings>().IncreaseKnowledge(130);
                    anim.SetBool("StartTrain",isLowEat );
                }
            }
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
        else ifcheckNeeded = true;
    }


    public void ifLowEat(bool ifLow){
        isLowEat = ifLow;
        if(!isBusy)anim.SetBool("StartEat", isLowEat);
        else ifcheckNeeded = true;
    }

    public void ifLowTrain(bool ifLow){
        isLowTrain = ifLow;
        if(!isBusy)anim.SetBool("StartTrain", isLowTrain);
        else ifcheckNeeded = true;
    }

    public void haveMaterial(Vector3 nextPos){
        isBusy = true;
        isHaveMaterial = true;
        buildPos = nextPos;
        nav.SetDestination(nextPos);
    }

    public void finMaterial(){
        isBusy = false;
        isHaveMaterial = false;
        // nav.SetDestination(new Vector3(0,0,0));
        if(ifcheckNeeded){
            anim.SetBool("StartTrain", isLowTrain);
            anim.SetBool("StartEat", isLowEat);
            anim.SetBool("StartSleep", isLowSleep);
            ifcheckNeeded= false;
        }
    }

    public bool ifBusy() {
        return isBusy;
    }

    public void checkChild(){
         foreach (Transform child in transform) {
            if (child.name.Contains("Tin")||child.name.Contains("Cardboard")||child.name.Contains("Plastic")) {
                // Debug.Log ("Child found. Mame: " + child.name);
                nav.SetDestination(buildPos);
            }
        }
    }

    GameObject checkParent(GameObject[] gs){
        foreach(GameObject g in gs){
            if(g.transform.parent == null && this.gameObject.transform.childCount == 3){
                return g;
            } 
        }
        return null;
    }
}


// ToDo add wait time
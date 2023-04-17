using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using FiniteStateMachine2;

public class EnemyPath : MonoBehaviour
{
    private NavMeshAgent agent;

    [SerializeField] GameObject navPoint;

    [SerializeField] GameObject player;

    [SerializeField] float stoppingDistance;

    [SerializeField] float detectionDistance;

    public StateMachine StateMachine { get; private set; }

    private void Awake()
    {
        StateMachine = new StateMachine();

        if(!TryGetComponent<NavMeshAgent>(out agent))
        {
            Debug.LogError("Need Navmesh Agent attached");
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        StateMachine.SetState(new IdleState(this));
        agent.isStopped = true;
    }

    // Update is called once per frame
    void Update()
    {
        StateMachine.OnUpdate();
    }

    public abstract class EnemyMoveState : IState
    {
        protected EnemyPath instance;

        public EnemyMoveState(EnemyPath _instance)
        {
            instance = _instance;

        }
        public virtual void OnEnter()
        {

        }

        public virtual void OnExit()
        {

        }

        public virtual void OnUpdate()
        { 

        }
    }

    public class MoveState : EnemyMoveState
    {
        public MoveState(EnemyPath _instance) : base(_instance)
        {

        }

        public override void OnEnter()
        {
            Debug.Log("moveState");
            //set agent to stopped
            instance.agent.isStopped = false;
        }
        public override void OnUpdate()
        {
            //update target object position
            //move towards it
            if(Vector3.Distance(instance.transform.position, instance.player.transform.position) < instance.detectionDistance)
            {
                instance.StateMachine.SetState(new ChaseState(instance));
            }
            else if(Vector3.Distance(instance.transform.position, instance.navPoint.transform.position) > instance.stoppingDistance)
            {
                instance.agent.SetDestination(instance.navPoint.transform.position);
            }
            else
            {
                // set to idle
                instance.StateMachine.SetState(new IdleState(instance));
            }
        }
    }

    public class IdleState : EnemyMoveState
    {
        public IdleState(EnemyPath _instance) : base(_instance)
        {

        }

        public override void OnEnter()
        {
            Debug.Log("IdleState");
            instance.agent.isStopped = true;
        }

        public override void OnUpdate()
        {
            if(Vector3.Distance(instance.transform.position, instance.player.transform.position) < instance.detectionDistance)
            {
                instance.StateMachine.SetState(new ChaseState(instance));
            }
            else if (Vector3.Distance(instance.transform.position, instance.navPoint.transform.position) > instance.stoppingDistance)
            {
                //switch to MoveState
                instance.StateMachine.SetState(new MoveState(instance));
            }
        }
    }

    public class ChaseState : MoveState
    {
        public ChaseState(EnemyPath _instance) : base(_instance)
        {

        }

        public override void OnEnter()
        {
            Debug.Log("ChaseState");
            instance.agent.isStopped = false;
        }

        public override void OnUpdate()
        {
            if(Vector3.Distance(instance.transform.position, instance.player.transform.position) < instance.detectionDistance)
            {
                instance.agent.SetDestination(instance.player.transform.position);
            }
            else
            {
                instance.StateMachine.SetState(new IdleState(instance));
            }
        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionDistance);
    }
}

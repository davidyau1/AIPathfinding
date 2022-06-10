using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieAgent : MonoBehaviour
{
    public NavMeshAgent agent;
    public GameObject collectable;
    public AgentStates agentState;
    [SerializeField] private Animator _anim;
    [SerializeField] private float _walkThreshold = 0.01f;

    // Start is called before the first frame update
    void Start()
    {
        agentState = AgentStates.find;
        NavMeshAgent agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        //if agent state is find go to collectable
        if (agentState == AgentStates.find)
        {
            agent.destination = collectable.transform.position;
            if (agent.destination == agent.transform.position)
            {
                Destroy(collectable);
                //update to roam state
                agentState = AgentStates.roam;

            }
        }
        if (agentState==AgentStates.roam)
        {
            //if (agent.destination == null)
            //{
            //    agent.destination = Random.insideUnitCircle;

            //}

            //if roaming state move randomly through map
            if (agent.remainingDistance> 0.1f)
                return;

            agent.destination = 25f*Random.insideUnitCircle;
        }
        UpdateAnimator();
    }
    //update animation based on velocity
    void UpdateAnimator()
    {
        if (agent.velocity.magnitude < _walkThreshold)
        {
            _anim.SetBool("IsWalking", false);
        }
        else
        {
            _anim.SetBool("IsWalking", true);
        }
    }
}

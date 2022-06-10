using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NinjaAgent : MonoBehaviour
{
    //agent
    public NavMeshAgent agent;
    //collectable
    public GameObject collectable; 
    //finish
    public GameObject finish;
    //animator
    [SerializeField] private Animator _anim;
    [SerializeField] private float _walkThreshold = 0.01f;

    // Start is called before the first frame update
    void Start()
    {//search
        NavMeshAgent agent = GetComponent<NavMeshAgent>();
        agent.destination = collectable.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //if collectable collected go to finsih
        if (agent.destination == agent.transform.position)
        {
            Destroy(collectable);
            
            agent.destination = finish.transform.position;
        }
        UpdateAnimator();
    }
    //update animations based on agent velocity
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

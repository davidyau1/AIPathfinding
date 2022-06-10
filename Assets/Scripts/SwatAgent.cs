using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SwatAgent : MonoBehaviour
{
    //agent
    public NavMeshAgent agent;
    //collectable
    public GameObject collectable;
    //finish
    public GameObject finish;
    //wall to be unlocked
    public GameObject wall;
    //
    [SerializeField] private Animator _anim;
    [SerializeField] private float _walkThreshold = 0.01f;



    // Start is called before the first frame update
    void Start()
    {
        //starts gagent moving to location
        NavMeshAgent agent = GetComponent<NavMeshAgent>();
        agent.destination = collectable.transform.position;
    }

  
    // Update is called once per frame
    void Update()
    {
        //if collectable collected move door and set to final position
        if (agent.destination==agent.transform.position)
        {
            Destroy(collectable);
            MoveWall();
            agent.destination = finish.transform.position;
        }

        
        UpdateAnimator();
    }

    //update animation if agent is moving
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
    //unlocks wall
    void MoveWall()
    {
        wall.transform.position = new Vector3(10, 0, 5);

    }
}

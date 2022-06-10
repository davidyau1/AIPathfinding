using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SwatAgent : MonoBehaviour
{
    public NavMeshAgent agent;
    public GameObject collectable;
    public GameObject finish;
    [SerializeField] private Animator _anim;
    [SerializeField] private float _walkThreshold = 0.01f;



    // Start is called before the first frame update
    void Start()
    {
        NavMeshAgent agent = GetComponent<NavMeshAgent>();
        if (true)
        {

        }
        agent.destination = collectable.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateAnimator();
    }

    private void DestroyCollectable()
    {
        
    }
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

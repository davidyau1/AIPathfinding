using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SwatAgent : MonoBehaviour
{
    public NavMeshAgent agent;
    public GameObject collectable;

   
    // Start is called before the first frame update
    void Start()
    {
        NavMeshAgent agent = GetComponent<NavMeshAgent>();
        agent.destination = collectable.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
